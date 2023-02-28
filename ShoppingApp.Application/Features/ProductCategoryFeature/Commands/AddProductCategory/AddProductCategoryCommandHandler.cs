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

namespace ShoppingApp.Application.Features.ProductCategoryFeature.Commands.AddProductCategory
{
    public class AddProductCategoryCommandHandler : IRequestHandler<AddProductCategoryCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddProductCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CommandResponse> Handle(AddProductCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            ProductCategory isExist = await _unitOfWork.ProductCategoryReadRepository.FindAsync(f=>f.Name.Equals(request.Name) && f.UserId==request.UserId);
            if (isExist == null)
            {
                ProductCategory addedProductCategory = _mapper.Map<ProductCategory>(request);
                bool result = await _unitOfWork.ProductCategoryWriteRepository.AddAsync(addedProductCategory);
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
