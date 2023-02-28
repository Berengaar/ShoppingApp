using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Common.Model.Identity
{
    public class RegisterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; } = Guid.NewGuid().ToString();
        public int CountryId { get; set; }
    }
}
