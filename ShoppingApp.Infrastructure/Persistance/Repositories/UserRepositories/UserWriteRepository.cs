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
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(ShoppingAppPostgreSqlDbContext context) : base(context)
        {
        }
    }
}
