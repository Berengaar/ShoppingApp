using Microsoft.EntityFrameworkCore;
using ShoppingApp.Application.Common.Repositories;
using ShoppingApp.Domain.Common;
using ShoppingApp.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
    {
        private readonly ShoppingAppPostgreSqlDbContext _context;

        public WriteRepository(ShoppingAppPostgreSqlDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
            return true;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return true;
        }
    }
}
