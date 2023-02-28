using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Dtos.ProductDtos
{
    public class AddProductDto
    {
        public string Name { get; set; }
        public int ProductCategoryId { get; set; }
        public string Unit { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
