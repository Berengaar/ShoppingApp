using MediatR;
using ShoppingApp.Application.Common.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistFeature.Queries.GetAllShoplistWithCache
{
    public class GetAllShoplistWithCacheCommandRequest:BaseAuthorizedQueryRequest,IRequest<IDataResult<GetAllShoplistWithCacheCommandResponse>>
    {
    }
}
