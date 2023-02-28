using ShoppingApp.Application.Common.Model.Identity;
using ShoppingApp.Application.Common.Repositories.UserRepositories;
using ShoppingApp.Domain.Entities;
using ShoppingApp.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Persistance.Repositories.UserRepositories
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(ShoppingAppPostgreSqlDbContext context) : base(context)
        {
        }

        public Task<bool> Any(LoginModel user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserDetailsByIdWithNestedAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserModelAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
