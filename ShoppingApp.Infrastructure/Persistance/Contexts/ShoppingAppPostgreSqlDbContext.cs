using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShoppingApp.Domain.Common;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Persistance.Contexts
{
    public class ShoppingAppPostgreSqlDbContext : DbContext
    {
        public DbSet<Shoplist> Shoplists { get; set; }
        public DbSet<ShoplistCategory> ShoplistCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public ShoppingAppPostgreSqlDbContext(DbContextOptions<ShoppingAppPostgreSqlDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<EntityEntry<BaseEntity>> datas = ChangeTracker.Entries<BaseEntity>();
            DateController(datas);
            return await base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {
            IEnumerable<EntityEntry<BaseEntity>> datas = ChangeTracker.Entries<BaseEntity>();
            DateController(datas);
            return base.SaveChanges();
        }
        private void DateController(IEnumerable<EntityEntry<BaseEntity>> datas)
        {
            foreach (EntityEntry<BaseEntity> data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Modified:
                        data.Entity.ModifiedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.UtcNow;
                        data.Entity.ModifiedDate = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
