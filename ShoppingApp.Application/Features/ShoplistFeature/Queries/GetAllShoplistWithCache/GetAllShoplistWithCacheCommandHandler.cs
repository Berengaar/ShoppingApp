using AutoMapper;
using MediatR;
using ShoppingApp.Application.Common.Interfaces;
using ShoppingApp.Application.Common.Repositories.ShoplistRepositories;
using ShoppingApp.Application.Common.Utilities.Abstract;
using ShoppingApp.Application.Common.Utilities.Concrete;
using ShoppingApp.Application.Dtos.ShoplistDtos;
using ShoppingApp.Application.Features.ShoplistFeature.Queries.GetAllShoplists;
using ShoppingApp.Domain.Consts;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistFeature.Queries.GetAllShoplistWithCache
{
    public class GetAllShoplistWithCacheCommandHandler : IRequestHandler<GetAllShoplistWithCacheCommandRequest, IDataResult<GetAllShoplistWithCacheCommandResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IShoplistCacheRepository _shoplistCacheRepository;

        public GetAllShoplistWithCacheCommandHandler(IMapper mapper, IShoplistCacheRepository shoplistCacheRepository)
        {
            _mapper = mapper;
            _shoplistCacheRepository = shoplistCacheRepository;
        }
        public async Task<IDataResult<GetAllShoplistWithCacheCommandResponse>> Handle(GetAllShoplistWithCacheCommandRequest request, CancellationToken cancellationToken)
        {
            ICollection<Shoplist> shoplists = await _shoplistCacheRepository.GetAllCacheAsync("getall2_shoplist", f => f.UserId == request.UserId);
            if (shoplists != null)
            {
                List<CacheShoplistDto> result = _mapper.Map<List<CacheShoplistDto>>(shoplists);
                if (result != null)
                {
                    return new DataResult<GetAllShoplistWithCacheCommandResponse>(resultStatus: true, message: DataResultMessages.SuccessResult, data: new GetAllShoplistWithCacheCommandResponse { CacheShoplistDtos = result });
                }
                return new DataResult<GetAllShoplistWithCacheCommandResponse>(resultStatus: false, message: DataResultMessages.MapErrorResult, data: null);
            }
            return new DataResult<GetAllShoplistWithCacheCommandResponse>(resultStatus: false, message: DataResultMessages.NoContentResult, data: null);
        }
    }
}
