using ShoppingApp.Application.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Dtos.ShoplistDtos
{
    public class ShoplistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShoplistCategoryName { get; set; }
        public bool IsCompleted { get; set; }
        public ICollection<ProductDto> ProductDtos { get; set; }
    }
}
