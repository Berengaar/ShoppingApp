using AutoMapper;
using ShoppingApp.Application.Common.Model.Identity;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Mapping
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            #region Commands
            CreateMap<RegisterModel,User>().ReverseMap();
            #endregion
            #region Queries

            #endregion
        }
    }
}
