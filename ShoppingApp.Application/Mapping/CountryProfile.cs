using AutoMapper;
using ShoppingApp.Application.Features.CountryFeature.Commands.AddCountry;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Mapping
{
    public class CountryProfile:Profile
    {
        public CountryProfile()
        {
            #region Commands
            CreateMap<AddCountryCommandRequest, Country>().ReverseMap();
            #endregion
            #region Queries

            #endregion
        }
    }
}
