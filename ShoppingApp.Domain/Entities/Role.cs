﻿using ShoppingApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Domain.Entities
{
    public class Role : BaseEntity
    {
        public Role()
        {
            this.Users=new HashSet<User>();
        }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
