using AutoMapper;
using ShoppingApp.Application.Dtos.ProductDtos;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Mapping
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            #region Commands
            CreateMap<AddProductDto, Product>().ReverseMap();
            #endregion
            #region Queries
            CreateMap<ProductDto, Product>().ReverseMap()
                .ForMember(dest => dest.ProductCategoryName, act => act.MapFrom(src => src.ProductCategory.Name));
            #endregion
        }
    }
}
