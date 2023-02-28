using ShoppingApp.Application.Common.Repositories.ShoplistRepositories;
using ShoppingApp.Domain.Entities;
using ShoppingApp.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Persistance.Repositories.ShoplistRepositories
{
    public class ShoplistWriteRepository : WriteRepository<Shoplist>, IShoplistWriteRepository
    {
        public ShoplistWriteRepository(ShoppingAppPostgreSqlDbContext context) : base(context)
        {
        }
    }
}
