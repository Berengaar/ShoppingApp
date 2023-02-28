using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ProductCategoryFeature.Commands.AddProductCategory
{
    public class AddProductCategoryCommandRequest : BaseCommandRequest, IRequest<CommandResponse>
    {
        public string Name { get; set; }
    }
}
