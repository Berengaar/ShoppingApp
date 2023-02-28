using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistFeature.Commands.AddCompletedShoplist
{
    public class AddCompletedShoplistCommandRequest : IRequest<CommandResponse>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
