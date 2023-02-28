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
    public class ProductCategoryWriteRepository : WriteRepository<ProductCategory>, IProductCategoryWriteRepository
    {
        public ProductCategoryWriteRepository(ShoppingAppPostgreSqlDbContext context) : base(context)
        {
        }
    }
}
