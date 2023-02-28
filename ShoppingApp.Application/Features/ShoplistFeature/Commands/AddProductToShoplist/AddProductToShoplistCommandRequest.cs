using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistFeature.Commands.AddProductToShoplist
{
    public class AddProductToShoplistCommandRequest : BaseCommandRequest, IRequest<CommandResponse>
    {
        public int ShoplistId { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductName { get; set;}
        public string Unit { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
    }
}
