using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Common.Model.Identity
{
    public class LoginModel
    {
        [Required]
        [MinLength(3)]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
