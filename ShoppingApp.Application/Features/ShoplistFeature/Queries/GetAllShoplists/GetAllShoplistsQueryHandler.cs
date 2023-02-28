using AutoMapper;
using MediatR;
using ShoppingApp.Application.Common.Interfaces;
using ShoppingApp.Application.Common.Utilities.Abstract;
using ShoppingApp.Application.Common.Utilities.Concrete;
using ShoppingApp.Application.Dtos.ShoplistDtos;
using ShoppingApp.Application.Features.ShoplistFeature.Queries.GetShoplistByCategoryId;
using ShoppingApp.Domain.Consts;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistFeature.Queries.GetAllShoplists
{
    public class GetAllShoplistsQueryHandler : IRequestHandler<GetAllShoplistsQueryRequest, IDataResult<GetAllShoplistsQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllShoplistsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<GetAllShoplistsQueryResponse>> Handle(GetAllShoplistsQueryRequest request, CancellationToken cancellationToken)
        {
            ICollection<Shoplist> shoplists = await _unitOfWork.ShoplistReadRepository.GetWhereAsync(w => w.UserId == request.UserId, true, w => w.Products, w => w.ShoplistCategory);
            if (shoplists != null)
            {
                List<ShoplistDto> result = _mapper.Map<List<ShoplistDto>>(shoplists);
                if (result != null)
                {
                    return new DataResult<GetAllShoplistsQueryResponse>(resultStatus: true, message: DataResultMessages.SuccessResult, data: new GetAllShoplistsQueryResponse { ShoplistDtos = result });
                }
                return new DataResult<GetAllShoplistsQueryResponse>(resultStatus: false, message: DataResultMessages.MapErrorResult, data: null);
            }
            return new DataResult<GetAllShoplistsQueryResponse>(resultStatus: false, message: DataResultMessages.NoContentResult, data: null);
        }
    }
}
