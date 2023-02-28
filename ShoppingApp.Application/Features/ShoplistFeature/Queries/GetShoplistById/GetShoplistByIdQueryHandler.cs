using AutoMapper;
using MediatR;
using ShoppingApp.Application.Common.Interfaces;
using ShoppingApp.Application.Common.Utilities.Abstract;
using ShoppingApp.Application.Common.Utilities.Concrete;
using ShoppingApp.Application.Dtos.ShoplistDtos;
using ShoppingApp.Domain.Consts;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistFeature.Queries.GetShoplistById
{
    public class GetShoplistByIdQueryHandler : IRequestHandler<GetShoplistByIdQueryRequest, IDataResult<GetShoplistByIdQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetShoplistByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<GetShoplistByIdQueryResponse>> Handle(GetShoplistByIdQueryRequest request, CancellationToken cancellationToken)
        {
            Shoplist shoplist = await _unitOfWork.ShoplistReadRepository.FindAsync(f => f.Id == request.ShoplistId && f.UserId == request.UserId, true);
            if (shoplist != null)
            {
                ShoplistDto result = _mapper.Map<ShoplistDto>(shoplist);
                if (result != null)
                {
                    return new DataResult<GetShoplistByIdQueryResponse>(resultStatus: true, message: DataResultMessages.SuccessResult, data: new GetShoplistByIdQueryResponse { ShoplistDto = result });
                }
                return new DataResult<GetShoplistByIdQueryResponse>(resultStatus: false, message: DataResultMessages.MapErrorResult, data: null);
            }
            return new DataResult<GetShoplistByIdQueryResponse>(resultStatus: false, message: DataResultMessages.NoContentResult, data: null);
        }
    }
}
