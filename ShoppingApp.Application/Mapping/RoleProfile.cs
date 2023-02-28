using AutoMapper;
using ShoppingApp.Application.Features.RoleFeature.Commands.AddRole;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Mapping
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            #region Commands
            CreateMap<AddRoleCommandRequest, Role>().ReverseMap();
            #endregion
            #region Queries

            #endregion
        }
    }
}
