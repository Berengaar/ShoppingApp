using AutoMapper;
using MediatR;
using ShoppingApp.Application.Common.Interfaces;
using ShoppingApp.Domain.Consts;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistFeature.Commands.AddShoplist
{
    public class AddShoplistCommandHandler : IRequestHandler<AddShoplistCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddShoplistCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CommandResponse> Handle(AddShoplistCommandRequest request, CancellationToken cancellationToken)
        {
            ShoplistCategory shoplistCategoryControl = await _unitOfWork.ShoplistCategoryReadRepository.FindAsync(f => f.Id == request.ShoplistCategoryId && f.UserId == request.UserId);
            if (shoplistCategoryControl != null)
            {
                Shoplist shoplistControl = await _unitOfWork.ShoplistReadRepository.FindAsync(f => f.Name == request.Name && f.UserId == request.UserId);
                if (shoplistControl == null)
                {
                    Shoplist addedShoplist = _mapper.Map<Shoplist>(request);
                    bool result = await _unitOfWork.ShoplistWriteRepository.AddAsync(addedShoplist);
                    if (result)
                    {
                        _unitOfWork.SaveChanges();
                        return new CommandResponse { IsSuccess = true };
                    }
                    return new CommandResponse { IsSuccess = false, Error = Messages.ErrorAdd };
                }
                return new CommandResponse { IsSuccess = false, Error = Messages.ErrorIsExist };
            }
            return new CommandResponse { IsSuccess = false, Error = Messages.ErrorNoContent };
        }
    }
}
