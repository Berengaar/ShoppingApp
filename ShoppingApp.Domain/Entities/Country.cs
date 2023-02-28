using ShoppingApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Domain.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneCode { get; set; }
    }
}
