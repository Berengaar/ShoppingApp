using ShoppingApp.Application.Common.Interfaces;
using ShoppingApp.Application.Common.Repositories.CountryRepositories;
using ShoppingApp.Application.Common.Repositories.ProductCategoryRepositories;
using ShoppingApp.Application.Common.Repositories.ProductRepositories;
using ShoppingApp.Application.Common.Repositories.RoleRepositories;
using ShoppingApp.Application.Common.Repositories.ShoplistCategoryRepositories;
using ShoppingApp.Application.Common.Repositories.ShoplistRepositories;
using ShoppingApp.Application.Common.Repositories.UserRepositories;
using ShoppingApp.Infrastructure.Persistance.Contexts;
using ShoppingApp.Infrastructure.Persistance.Repositories.CountryRepositories;
using ShoppingApp.Infrastructure.Persistance.Repositories.ProductCategoryRepositories;
using ShoppingApp.Infrastructure.Persistance.Repositories.ProductRepositories;
using ShoppingApp.Infrastructure.Persistance.Repositories.RoleRepositories;
using ShoppingApp.Infrastructure.Persistance.Repositories.ShoplistCategoryRepositories;
using ShoppingApp.Infrastructure.Persistance.Repositories.ShoplistRepositories;
using ShoppingApp.Infrastructure.Persistance.Repositories.UserRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Persistance.Helpers
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingAppPostgreSqlDbContext _context;
        private ProductReadRepository _productReadRepository;
        private ProductWriteRepository _productWriteRepository;
        private ProductCategoryReadRepository _productCategoryReadRepository;
        private ProductCategoryWriteRepository _productCategoryWriteRepository;
        private ShoplistReadRepository _shoplistReadRepository;
        private ShoplistWriteRepository _shoplistWriteRepository;
        private ShoplistCategoryReadRepository _shoplistCategoryReadRepository;
        private ShoplistCategoryWriteRepository _shoplistCategoryWriteRepository;
        private UserReadRepository _userReadRepository;
        private UserWriteRepository _userWriteRepository;
        private RoleReadRepository _roleReadRepository;
        private RoleWriteRepository _roleWriteRepository;
        private CountryReadRepository _countryReadRepository;
        private CountryWriteRepository _countryWriteRepository;

        public UnitOfWork(ShoppingAppPostgreSqlDbContext context)
        {
            _context = context;
        }

        public IProductReadRepository ProductReadRepository => _productReadRepository ?? (_productReadRepository = new ProductReadRepository(_context));

        public IProductWriteRepository ProductWriteRepository => _productWriteRepository ?? (_productWriteRepository = new ProductWriteRepository(_context));

        public IProductCategoryReadRepository ProductCategoryReadRepository => _productCategoryReadRepository ?? (_productCategoryReadRepository = new ProductCategoryReadRepository(_context));

        public IProductCategoryWriteRepository ProductCategoryWriteRepository => _productCategoryWriteRepository ?? (_productCategoryWriteRepository = new ProductCategoryWriteRepository(_context));

        public IShoplistReadRepository ShoplistReadRepository => _shoplistReadRepository ?? (_shoplistReadRepository = new ShoplistReadRepository(_context));

        public IShoplistWriteRepository ShoplistWriteRepository => _shoplistWriteRepository ?? (_shoplistWriteRepository = new ShoplistWriteRepository(_context));

        public IShoplistCategoryReadRepository ShoplistCategoryReadRepository => _shoplistCategoryReadRepository ?? (_shoplistCategoryReadRepository = new ShoplistCategoryReadRepository(_context));

        public IShoplistCategoryWriteRepository ShoplistCategoryWriteRepository => _shoplistCategoryWriteRepository ?? (_shoplistCategoryWriteRepository = new ShoplistCategoryWriteRepository(_context));

        public IUserReadRepository UserReadRepository => _userReadRepository ?? (_userReadRepository = new UserReadRepository(_context));

        public IUserWriteRepository UserWriteRepository => _userWriteRepository ?? (_userWriteRepository = new UserWriteRepository(_context));

        public IRoleReadRepository RoleReadRepository => _roleReadRepository ?? (_roleReadRepository = new RoleReadRepository(_context));

        public IRoleWriteRepository RoleWriteRepository => _roleWriteRepository ?? (_roleWriteRepository = new RoleWriteRepository(_context));

        public ICountryReadRepository CountryReadRepository => _countryReadRepository ?? (_countryReadRepository = new CountryReadRepository(_context));

        public ICountryWriteRepository CountryWriteRepository => _countryWriteRepository ?? (_countryWriteRepository = new CountryWriteRepository(_context));

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
