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

namespace ShoppingApp.Application.Features.ShoplistFeature.Commands.CompleteShoplist
{
    public class CompleteShoplistCommandHandler : IRequestHandler<CompleteShoplistCommandRequest, IDataResult<CompleteShoplistCommandResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompleteShoplistCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<CompleteShoplistCommandResponse>> Handle(CompleteShoplistCommandRequest request, CancellationToken cancellationToken)
        {
            Shoplist shoplist = await _unitOfWork.ShoplistReadRepository.FindAsync(f => f.Id == request.ShoplistId && f.UserId == request.UserId, false, f => f.ShoplistCategory, f => f.Products);
            if (shoplist != null)
            {
                if (!shoplist.IsCompleted)
                {
                    shoplist.IsCompleted = true;
                    AdminShoplist shoplistDto = _mapper.Map<AdminShoplist>(shoplist);
                    await _unitOfWork.ShoplistWriteRepository.UpdateAsync(shoplist);
                    _unitOfWork.SaveChanges();
                    return new DataResult<CompleteShoplistCommandResponse>(resultStatus: true, message: DataResultMessages.SuccessResult, data: new CompleteShoplistCommandResponse { AdminShoplist=shoplistDto});
                }
                return new DataResult<CompleteShoplistCommandResponse>(resultStatus: true, message: DataResultMessages.NoContentResult, data: null);
            }
            return new DataResult<CompleteShoplistCommandResponse>(resultStatus: true, message: DataResultMessages.NoContentResult, data: null);
        }
    }
}
