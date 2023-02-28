using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Dtos.ProductDtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }
        public string ProductCategoryName { get; set; }

    }
}
