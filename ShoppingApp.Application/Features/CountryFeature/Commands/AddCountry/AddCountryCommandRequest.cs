using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.CountryFeature.Commands.AddCountry
{
    public class AddCountryCommandRequest: IRequest<CommandResponse>
    {
        public string Name { get; set; }
        public string PhoneCode { get; set; }
    }
}
