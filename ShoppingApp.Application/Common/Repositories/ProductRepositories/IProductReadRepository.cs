﻿using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Common.Repositories.ProductRepositories
{
    public interface IProductReadRepository : IReadRepository<Product>
    {
    }
}
