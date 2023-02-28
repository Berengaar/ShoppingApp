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

namespace ShoppingApp.Application.Features.ShoplistCategoryFeature.Commands.AddShoplistCategory
{
    public class AddShoplistCategoryCommandHandler : IRequestHandler<AddShoplistCategoryCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddShoplistCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResponse> Handle(AddShoplistCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            ShoplistCategory isExist = await _unitOfWork.ShoplistCategoryReadRepository.FindAsync(f => f.Name.Equals(request.Name) && f.UserId == request.UserId);
            if (isExist == null)
            {
                ShoplistCategory addedShoplistCategory = _mapper.Map<ShoplistCategory>(request);
                bool result = await _unitOfWork.ShoplistCategoryWriteRepository.AddAsync(addedShoplistCategory);
                if (result)
                {
                    _unitOfWork.SaveChanges();
                    return new CommandResponse { IsSuccess = true };
                }
                return new CommandResponse { IsSuccess = false, Error = Messages.ErrorAdd };
            }
            return new CommandResponse { IsSuccess = false, Error = Messages.ErrorIsExist };
        }
    }
}
