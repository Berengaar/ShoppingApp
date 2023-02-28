using MediatR;
using ShoppingApp.Application.Common.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistFeature.Queries.GetShoplistById
{
    public class GetShoplistByIdQueryRequest : BaseAuthorizedQueryRequest, IRequest<IDataResult<GetShoplistByIdQueryResponse>>
    {
        public int ShoplistId { get; set; }
    }
}
