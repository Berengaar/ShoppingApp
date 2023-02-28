using ShoppingApp.Application.Dtos.ShoplistDtos;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistFeature.Queries.GetAllShoplistWithCache
{
    public class GetAllShoplistWithCacheCommandResponse
    {
        public ICollection<CacheShoplistDto> CacheShoplistDtos { get; set; }
    }
}
