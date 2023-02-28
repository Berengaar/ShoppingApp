using Microsoft.Extensions.DependencyInjection;
using ShoppingApp.Application.Common.Interfaces;
using ShoppingApp.Application.Common.Repositories.AdminRepositories;
using ShoppingApp.Application.Common.Repositories.CountryRepositories;
using ShoppingApp.Application.Common.Repositories.ProductCategoryRepositories;
using ShoppingApp.Application.Common.Repositories.ProductRepositories;
using ShoppingApp.Application.Common.Repositories.RoleRepositories;
using ShoppingApp.Application.Common.Repositories.ShoplistCategoryRepositories;
using ShoppingApp.Application.Common.Repositories.ShoplistRepositories;
using ShoppingApp.Application.Common.Repositories.UserRepositories;
using ShoppingApp.Infrastructure.Identity;
using ShoppingApp.Infrastructure.Persistance.Helpers;
using ShoppingApp.Infrastructure.Persistance.Repositories.AdminRepositories;
using ShoppingApp.Infrastructure.Persistance.Repositories.CountryRepositories;
using ShoppingApp.Infrastructure.Persistance.Repositories.ProductCategoryRepositories;
using ShoppingApp.Infrastructure.Persistance.Repositories.ProductRepositories;
using ShoppingApp.Infrastructure.Persistance.Repositories.RoleRepositories;
using ShoppingApp.Infrastructure.Persistance.Repositories.ShoplistCategoryRepositories;
using ShoppingApp.Infrastructure.Persistance.Repositories.ShoplistRepositories;
using ShoppingApp.Infrastructure.Persistance.Repositories.UserRepositories;
using ShoppingApp.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Persistance.DIContainer
{
    public static class DIServiceRegistration
    {
        public static void AddDIServices(this IServiceCollection services)
        {
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IRoleReadRepository, RoleReadRepository>();
            services.AddScoped<IRoleWriteRepository, RoleWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductCategoryReadRepository, ProductCategoryReadRepository>();
            services.AddScoped<IProductCategoryWriteRepository, ProductCategoryWriteRepository>();
            services.AddScoped<IShoplistReadRepository, ShoplistReadRepository>();
            services.AddScoped<IShoplistWriteRepository, ShoplistWriteRepository>();
            services.AddScoped<IShoplistCategoryReadRepository, ShoplistCategoryReadRepository>();
            services.AddScoped<IShoplistCategoryWriteRepository, ShoplistCategoryWriteRepository>();
            services.AddScoped<ICountryReadRepository, CountryReadRepository>();
            services.AddScoped<ICountryWriteRepository, CountryWriteRepository>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IShoplistCacheRepository, ShoplistCacheRepository>();
            services.AddScoped<IAdminReadRepository, AdminReadRepository>();
            services.AddScoped<IAdminWriteRepository, AdminWriteRepository>();
        }
    }
}
