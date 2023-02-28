using ShoppingApp.Application.Common.Model.Identity;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Common.Repositories.UserRepositories
{
    public interface IUserReadRepository:IReadRepository<User>
    {
        Task<bool> Any(LoginModel user);
        Task<User> GetUserModelAsync(string email);
        Task<User> GetUserDetailsByIdWithNestedAsync(int id);
    }
}
