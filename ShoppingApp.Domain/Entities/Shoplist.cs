using ShoppingApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Domain.Entities
{
    public class Shoplist : BaseEntity
    {
        public Shoplist()
        {
            this.Products = new HashSet<Product>();
        }
        public string Name { get; set; }
        public bool IsCompleted { get; set; } = false;
        public int ShoplistCategoryId { get; set; }
        public ShoplistCategory ShoplistCategory { get; set; }
        public ICollection<Product>? Products { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
