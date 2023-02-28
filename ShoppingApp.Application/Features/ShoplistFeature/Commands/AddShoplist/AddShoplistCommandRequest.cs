using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistFeature.Commands.AddShoplist
{
    public class AddShoplistCommandRequest : BaseCommandRequest,IRequest<CommandResponse>
    {
        public string Name { get; set; }
        public int ShoplistCategoryId { get; set; }
    }
}
