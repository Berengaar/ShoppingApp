using ShoppingApp.Application.Dtos.ShoplistDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistFeature.Queries.GetAllShoplists
{
    public class GetAllShoplistsQueryResponse
    {
        public ICollection<ShoplistDto> ShoplistDtos { get; set; }
    }
}
