using ShoppingApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string? Unit { get; set; }
        public decimal? Amount { get; set; }
        public string? Description { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ShoplistId { get; set; }
        public Shoplist Shoplist { get; set; }
    }
}
