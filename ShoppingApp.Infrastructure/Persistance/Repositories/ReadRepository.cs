using Microsoft.EntityFrameworkCore;
using ShoppingApp.Application.Common.Pagination;
using ShoppingApp.Application.Common.Repositories;
using ShoppingApp.Domain.Common;
using ShoppingApp.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
    {
        private readonly ShoppingAppPostgreSqlDbContext _context;

        public ReadRepository(ShoppingAppPostgreSqlDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (Expression<Func<T, object>> includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            if (noTracking)
                return await query.AsNoTracking().FirstOrDefaultAsync();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(bool noTracking = true, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (includeProperties.Any())
            {
                foreach (Expression<Func<T, object>> includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            if (noTracking)
                return await query.AsNoTracking().ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<(ICollection<T>, PaginationResponse)> GetAllWithPaginationAsync(PaginatedParameters paginatedParameters, bool noTracking = true, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (noTracking)
            {
                query = query.AsNoTracking();
            }
            if (includeProperties.Any())
            {
                foreach (Expression<Func<T, object>> includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            List<T> paginatedList = PaginatedList<T>.ToPagedList(query, paginatedParameters).ToList();

            return (paginatedList, new PaginationResponse { PageNumber = paginatedParameters.PageNumber, PageSize = paginatedParameters.PageSize, TotalCount = query.Count() });
        }

        public async Task<ICollection<T>> GetWhereAsync(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (Expression<Func<T, object>> includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            if (noTracking)
                return await query.AsNoTracking().ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<(ICollection<T>, PaginationResponse)> GetWhereWithPaginationAsync(PaginatedParameters paginatedParameters, Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (noTracking)
            {
                query = query.AsNoTracking();
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (Expression<Func<T, object>> includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            List<T> paginatedList = PaginatedList<T>.ToPagedList(query, paginatedParameters);

            return (paginatedList, new PaginationResponse { PageNumber = paginatedParameters.PageNumber, PageSize = paginatedParameters.PageSize, TotalCount = query.Count() });
        }
    }
}
