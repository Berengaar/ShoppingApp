using Microsoft.EntityFrameworkCore;
using ShoppingApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Common.Interfaces
{
    public interface IRedisCacheService<T> where T : BaseEntity,new()
    {
        Task<List<T>> GetAllCacheAsync(string cacheKey,Expression<Func<T,bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        DbSet<T> Table { get; }
    }
}
