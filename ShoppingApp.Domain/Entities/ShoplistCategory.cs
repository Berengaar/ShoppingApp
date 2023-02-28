using ShoppingApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Domain.Entities
{
    public class ShoplistCategory : BaseEntity
    {
        public ShoplistCategory()
        {
            this.Shoplists = new HashSet<Shoplist>();
        }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Shoplist> Shoplists { get; set; }
    }
}
