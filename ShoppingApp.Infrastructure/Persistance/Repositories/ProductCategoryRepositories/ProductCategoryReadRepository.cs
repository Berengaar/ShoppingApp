using ShoppingApp.Application.Common.Repositories.ProductCategoryRepositories;
using ShoppingApp.Domain.Entities;
using ShoppingApp.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Persistance.Repositories.ProductCategoryRepositories
{
    public class ProductCategoryReadRepository : ReadRepository<ProductCategory>, IProductCategoryReadRepository
    {
        public ProductCategoryReadRepository(ShoppingAppPostgreSqlDbContext context) : base(context)
        {
        }
    }
}
