using AutoMapper;
using ShoppingApp.Application.Dtos.ShoplistDtos;
using ShoppingApp.Application.Features.ShoplistFeature.Commands.AddShoplist;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Mapping
{
    public class ShoplistProfile:Profile
    {
        public ShoplistProfile()
        {
            #region Commands
            CreateMap<AddShoplistCommandRequest, Shoplist>().ReverseMap();
            #endregion
            #region Queries
            CreateMap<ShoplistDto, Shoplist>().ReverseMap()
                .ForMember(dest => dest.ProductDtos, act => act.MapFrom(src => src.Products))
                .ForMember(dest => dest.ShoplistCategoryName, act => act.MapFrom(src => src.ShoplistCategory.Name));

            CreateMap<CacheShoplistDto, Shoplist>().ReverseMap();
            CreateMap<AdminShoplist, Shoplist>().ReverseMap();
            #endregion
        }
    }
}
