using Microsoft.EntityFrameworkCore;
using ShoppingApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Common.Repositories
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        public DbSet<T> Table { get; }
    }
}
