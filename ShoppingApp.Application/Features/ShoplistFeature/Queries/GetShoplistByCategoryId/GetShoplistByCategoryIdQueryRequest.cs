using MediatR;
using ShoppingApp.Application.Common.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistFeature.Queries.GetShoplistByCategoryId
{
    public class GetShoplistByCategoryIdQueryRequest : BaseAuthorizedQueryRequest, IRequest<IDataResult<GetShoplistByCategoryIdQueryResponse>>
    {
        public int ShoplistCategoryId { get; set; }
    }
}
