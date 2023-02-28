using MediatR;
using ShoppingApp.Application.Common.Utilities.Abstract;
using ShoppingApp.Application.Dtos.ShoplistDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistFeature.Queries.GetAllShoplists
{
    public class GetAllShoplistsQueryRequest : BaseAuthorizedQueryRequest, IRequest<IDataResult<GetAllShoplistsQueryResponse>>
    {
    }
}
