using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using ShoppingApp.Application.Common.Interfaces;
using ShoppingApp.Domain.Common;
using ShoppingApp.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Services
{
    public class RedisCacheService<T> : IRedisCacheService<T> where T : BaseEntity, new()
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ShoppingAppPostgreSqlDbContext _context;
        public DbSet<T> Table => _context.Set<T>();

        public RedisCacheService(ShoppingAppPostgreSqlDbContext context, IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
            _context = context;
        }


        public async Task<List<T>> GetAllCacheAsync(string cacheKey, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            byte[] cache = await _distributedCache.GetAsync(cacheKey);
            string json;
            List<T> cachedList;
            IQueryable<T> query;
            if (cache != null)
            {
                json = Encoding.UTF8.GetString(cache);
                cachedList = JsonConvert.DeserializeObject<List<T>>(json);
            }
            else
            {
                query = Table;
                if (predicate != null)
                {
                    query = query.Where(predicate);
                }
                if (includeProperties.Any())
                {
                    foreach (Expression<Func<T, object>> includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                }
                cachedList = await query.ToListAsync();
                json = JsonConvert.SerializeObject(cachedList, Formatting.Indented);
                cache = Encoding.UTF8.GetBytes(json);
                var options = new DistributedCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(1))
                        .SetAbsoluteExpiration(DateTime.Now.AddMonths(1));
                await _distributedCache.SetAsync(cacheKey, cache, options);
            }
            return cachedList;
        }
    }
}
