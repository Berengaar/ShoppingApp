using AutoMapper;
using ShoppingApp.Application.Features.ProductCategoryFeature.Commands.AddProductCategory;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Mapping
{
    public class ProductCategoryProfile:Profile
    {
        public ProductCategoryProfile()
        {
            #region Commands
            CreateMap<AddProductCategoryCommandRequest, ProductCategory>().ReverseMap();
            #endregion
        }
    }
}
