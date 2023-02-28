using ShoppingApp.Application.Common.Pagination;
using ShoppingApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Common.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        Task<ICollection<T>> GetAllAsync(bool noTracking = true, params Expression<Func<T, object>>[] includeProperties);
        Task<(ICollection<T>, PaginationResponse)> GetAllWithPaginationAsync(PaginatedParameters paginatedParameters, bool noTracking = true, params Expression<Func<T, object>>[] includeProperties);
        Task<ICollection<T>> GetWhereAsync(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includeProperties);
        Task<(ICollection<T>, PaginationResponse)> GetWhereWithPaginationAsync(PaginatedParameters paginatedParameters, Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includeProperties);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includeProperties);
    }
}
