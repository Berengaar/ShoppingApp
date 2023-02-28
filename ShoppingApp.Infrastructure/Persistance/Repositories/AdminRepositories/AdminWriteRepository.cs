using ShoppingApp.Application.Common.Repositories.AdminRepositories;
using ShoppingApp.Domain.Entities;
using ShoppingApp.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Persistance.Repositories.AdminRepositories
{
    public class AdminWriteRepository : IAdminWriteRepository
    {
        private readonly AdminShoppingAppPostgreSqlDbContext _context;

        public AdminWriteRepository(AdminShoppingAppPostgreSqlDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(AdminShoplist adminShoplist)
        {
            _context.AdminShoplists.Add(adminShoplist);
            _context.SaveChanges();
            return true;
        }
    }
}
