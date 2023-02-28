using Microsoft.Extensions.Caching.Distributed;
using ShoppingApp.Application.Common.Repositories.ShoplistRepositories;
using ShoppingApp.Domain.Entities;
using ShoppingApp.Infrastructure.Persistance.Contexts;
using ShoppingApp.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Persistance.Repositories.ShoplistRepositories
{
    internal class ShoplistCacheRepository : RedisCacheService<Shoplist>, IShoplistCacheRepository
    {
        public ShoplistCacheRepository(ShoppingAppPostgreSqlDbContext context, IDistributedCache distributedCache) : base(context, distributedCache)
        {
        }
    }
}
