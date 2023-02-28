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
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistFeature.Queries.GetShoplistByCategoryId
{
    public class GetShoplistByCategoryIdQueryHandler : IRequestHandler<GetShoplistByCategoryIdQueryRequest, IDataResult<GetShoplistByCategoryIdQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetShoplistByCategoryIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<GetShoplistByCategoryIdQueryResponse>> Handle(GetShoplistByCategoryIdQueryRequest request, CancellationToken cancellationToken)
        {
            ICollection<Shoplist> shoplists = await _unitOfWork.ShoplistReadRepository.GetWhereAsync(w => w.UserId == request.UserId && w.ShoplistCategoryId==request.ShoplistCategoryId, true, w => w.Products, w => w.ShoplistCategory);
            if (shoplists != null)
            {
                List<ShoplistDto> result = _mapper.Map<List<ShoplistDto>>(shoplists);
                if (result != null)
                {
                    return new DataResult<GetShoplistByCategoryIdQueryResponse>(resultStatus: true, message: DataResultMessages.SuccessResult, data: new GetShoplistByCategoryIdQueryResponse { ShoplistDtos = result });
                }
                return new DataResult<GetShoplistByCategoryIdQueryResponse>(resultStatus: false, message: DataResultMessages.MapErrorResult, data: null);
            }
            return new DataResult<GetShoplistByCategoryIdQueryResponse>(resultStatus: false, message: DataResultMessages.NoContentResult, data: null);
        }
    }
}
