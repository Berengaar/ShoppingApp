﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Common.Model.Identity
{
    public class UserRolesModel
    {
        public int UserId { get; set; }
        public int[] Roles { get; set; }
    }
}
