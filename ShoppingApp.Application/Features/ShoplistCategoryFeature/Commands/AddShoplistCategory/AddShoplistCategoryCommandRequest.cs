using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistCategoryFeature.Commands.AddShoplistCategory
{
    public class AddShoplistCategoryCommandRequest : BaseCommandRequest, IRequest<CommandResponse>
    {
        public string Name { get; set; }
    }
}
