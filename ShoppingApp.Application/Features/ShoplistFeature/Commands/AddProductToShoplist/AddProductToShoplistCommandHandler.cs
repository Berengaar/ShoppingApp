using AutoMapper;
using MediatR;
using ShoppingApp.Application.Common.Interfaces;
using ShoppingApp.Application.Dtos.ProductDtos;
using ShoppingApp.Domain.Consts;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistFeature.Commands.AddProductToShoplist
{
    public class AddProductToShoplistCommandHandler : IRequestHandler<AddProductToShoplistCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddProductToShoplistCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CommandResponse> Handle(AddProductToShoplistCommandRequest request, CancellationToken cancellationToken)
        {
            Shoplist shoplist = await _unitOfWork.ShoplistReadRepository.FindAsync(f => f.Id == request.ShoplistId & f.UserId == request.UserId, false, f => f.Products);
            if (shoplist != null)
            {
                ProductCategory productCategory = await _unitOfWork.ProductCategoryReadRepository.FindAsync(f => f.Id == request.ProductCategoryId && f.UserId == request.UserId);
                if (productCategory != null)
                {
                    if (Units.ProductUnits.Contains(request.Unit))
                    {
                        Product product = await _unitOfWork.ProductReadRepository.FindAsync(f => f.Name == request.ProductName && f.UserId == request.UserId);
                        if (product == null)
                        {
                            AddProductDto mappedProduct = new AddProductDto()
                            {
                                Amount = request.Amount,
                                Description = request.Description,
                                Name = request.ProductName,
                                Unit = request.Unit,
                                ProductCategoryId = request.ProductCategoryId,
                                UserId=(int)request.UserId
                            };
                            Product addedProduct = _mapper.Map<Product>(mappedProduct);
                            await _unitOfWork.ProductWriteRepository.AddAsync(addedProduct);
                            shoplist.Products.Add(addedProduct);
                            _unitOfWork.SaveChanges();
                            return new CommandResponse { IsSuccess = true };
                        }
                        return new CommandResponse { IsSuccess = false, Error = Messages.ErrorIsExist };
                    }
                    return new CommandResponse { IsSuccess = false, Error = Messages.ErrorUnit };
                }
                return new CommandResponse { IsSuccess = false, Error = Messages.ErrorNoContent };
            }
            return new CommandResponse { IsSuccess = false, Error = Messages.ErrorNoContent };
        }
    }
}
