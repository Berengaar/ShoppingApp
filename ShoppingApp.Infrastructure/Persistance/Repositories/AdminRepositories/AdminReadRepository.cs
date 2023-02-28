using Microsoft.EntityFrameworkCore;
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
    public class AdminReadRepository : IAdminReadRepository
    {
        private AdminShoppingAppPostgreSqlDbContext _context;

        public AdminReadRepository(AdminShoppingAppPostgreSqlDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<AdminShoplist>> GetAllAsync() => await _context.AdminShoplists.ToListAsync();
        
    }
}
