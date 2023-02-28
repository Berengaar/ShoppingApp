using AutoMapper;
using ShoppingApp.Application.Features.ShoplistCategoryFeature.Commands.AddShoplistCategory;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Mapping
{
    public class ShoplistCategoryProfile : Profile
    {
        public ShoplistCategoryProfile()
        {
            #region Commands
            CreateMap<AddShoplistCategoryCommandRequest, ShoplistCategory>().ReverseMap();
            #endregion
            #region Queries

            #endregion
        }
    }
}
