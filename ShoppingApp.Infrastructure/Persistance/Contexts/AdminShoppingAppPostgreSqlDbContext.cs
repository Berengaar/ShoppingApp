using Microsoft.EntityFrameworkCore;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Persistance.Contexts
{
    public class AdminShoppingAppPostgreSqlDbContext: DbContext
    {
        public DbSet<AdminShoplist> AdminShoplists { get; set; }
        public AdminShoppingAppPostgreSqlDbContext(DbContextOptions<AdminShoppingAppPostgreSqlDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
