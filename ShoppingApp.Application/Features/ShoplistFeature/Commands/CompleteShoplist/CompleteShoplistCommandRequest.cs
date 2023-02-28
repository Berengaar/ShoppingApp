using MediatR;
using ShoppingApp.Application.Common.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistFeature.Commands.CompleteShoplist
{
    public class CompleteShoplistCommandRequest : BaseCommandRequest, IRequest<IDataResult<CompleteShoplistCommandResponse>>
    {
        public int ShoplistId { get; set; }
    }
}
