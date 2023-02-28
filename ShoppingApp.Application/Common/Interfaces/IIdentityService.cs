using ShoppingApp.Application.Common.Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> LoginAsync(LoginModel user);
        Task<bool> RegisterAsync(RegisterModel user);
        Task<bool> AddRoleAsync(UserRoleModel userRole);
        Task<bool> AddRolesAsync(UserRolesModel userRoles);
    }
}
