using ShoppingApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
            this.Shoplists = new HashSet<Shoplist>();
            this.ShoplistCategories = new HashSet<ShoplistCategory>();
            this.Products = new HashSet<Product>();
            this.ProductCategories = new HashSet<ProductCategory>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordSalt { get; set; } = Guid.NewGuid().ToString();
        public string Password { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Shoplist> Shoplists { get; set; }
        public ICollection<ShoplistCategory> ShoplistCategories { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
