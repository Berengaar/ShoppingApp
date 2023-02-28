using ShoppingApp.Application.Common.Repositories.RoleRepositories;
using ShoppingApp.Domain.Entities;
using ShoppingApp.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Persistance.Repositories.RoleRepositories
{
    public class RoleWriteRepository : WriteRepository<Role>, IRoleWriteRepository
    {
        public RoleWriteRepository(ShoppingAppPostgreSqlDbContext context) : base(context)
        {
        }
    }
}
