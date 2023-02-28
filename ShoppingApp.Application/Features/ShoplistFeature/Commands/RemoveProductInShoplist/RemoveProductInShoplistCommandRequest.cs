using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistFeature.Commands.RemoveProductInShoplist
{
    public class RemoveProductInShoplistCommandRequest : BaseCommandRequest, IRequest<CommandResponse>
    {
        public int ShoplistId { get; set; }
        public int ProductId { get; set; }
    }
}
