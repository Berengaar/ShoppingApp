using ShoppingApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Domain.Entities
{
    public class ProductCategory : BaseEntity
    {
        public ProductCategory()
        {
            this.Products = new HashSet<Product>();
        }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
