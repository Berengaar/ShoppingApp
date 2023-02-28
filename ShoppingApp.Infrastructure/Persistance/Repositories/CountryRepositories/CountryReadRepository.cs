using ShoppingApp.Application.Common.Repositories.CountryRepositories;
using ShoppingApp.Domain.Entities;
using ShoppingApp.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Persistance.Repositories.CountryRepositories
{
    public class CountryReadRepository : ReadRepository<Country>, ICountryReadRepository
    {
        public CountryReadRepository(ShoppingAppPostgreSqlDbContext context) : base(context)
        {
        }
    }
}
