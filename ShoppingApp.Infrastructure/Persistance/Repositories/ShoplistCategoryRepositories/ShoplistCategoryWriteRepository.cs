using ShoppingApp.Application.Common.Repositories.ShoplistCategoryRepositories;
using ShoppingApp.Domain.Entities;
using ShoppingApp.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Persistance.Repositories.ShoplistCategoryRepositories
{
    public class ShoplistCategoryWriteRepository : WriteRepository<ShoplistCategory>, IShoplistCategoryWriteRepository
    {
        public ShoplistCategoryWriteRepository(ShoppingAppPostgreSqlDbContext context) : base(context)
        {
        }
    }
}
