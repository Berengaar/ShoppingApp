using Microsoft.EntityFrameworkCore;
using ShoppingApp.Application.Common.Repositories.ShoplistRepositories;
using ShoppingApp.Domain.Entities;
using ShoppingApp.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Persistance.Repositories.ShoplistRepositories
{
    public class ShoplistReadRepository : ReadRepository<Shoplist>, IShoplistReadRepository
    {
        public ShoplistReadRepository(ShoppingAppPostgreSqlDbContext context) : base(context)
        {
        }
    }
}
