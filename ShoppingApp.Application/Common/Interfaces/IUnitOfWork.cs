using ShoppingApp.Application.Common.Repositories.CountryRepositories;
using ShoppingApp.Application.Common.Repositories.ProductCategoryRepositories;
using ShoppingApp.Application.Common.Repositories.ProductRepositories;
using ShoppingApp.Application.Common.Repositories.RoleRepositories;
using ShoppingApp.Application.Common.Repositories.ShoplistCategoryRepositories;
using ShoppingApp.Application.Common.Repositories.ShoplistRepositories;
using ShoppingApp.Application.Common.Repositories.UserRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Common.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IProductReadRepository ProductReadRepository { get; }
        IProductWriteRepository ProductWriteRepository { get; }
        IProductCategoryReadRepository ProductCategoryReadRepository { get; }
        IProductCategoryWriteRepository ProductCategoryWriteRepository { get; }
        IShoplistReadRepository ShoplistReadRepository { get; }
        IShoplistWriteRepository ShoplistWriteRepository { get; }
        IShoplistCategoryReadRepository ShoplistCategoryReadRepository { get; }
        IShoplistCategoryWriteRepository ShoplistCategoryWriteRepository { get; }
        IUserReadRepository UserReadRepository { get; }
        IUserWriteRepository UserWriteRepository { get; }   
        IRoleReadRepository RoleReadRepository { get; }
        IRoleWriteRepository RoleWriteRepository { get; }
        ICountryReadRepository CountryReadRepository { get; }
        ICountryWriteRepository CountryWriteRepository { get; }

        int SaveChanges();
    }
}
