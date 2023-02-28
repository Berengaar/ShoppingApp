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

namespace ShoppingApp.Application.Features.ShoplistFeature.Commands.UpdateProductInShoplist
{
    public class UpdateProductInShoplistCommandHandler : IRequestHandler<UpdateProductInShoplistCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductInShoplistCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CommandResponse> Handle(UpdateProductInShoplistCommandRequest request, CancellationToken cancellationToken)
        {
            Shoplist shoplist = await _unitOfWork.ShoplistReadRepository.FindAsync(f => f.Id == request.ShoplistId & f.UserId == request.UserId, false, f => f.Products);
            if (shoplist != null)
            {
                ProductCategory productCategory = await _unitOfWork.ProductCategoryReadRepository.FindAsync(f => f.Id == request.ProductCategoryId && f.UserId == request.UserId);
                if (productCategory != null)
                {
                    Product product = await _unitOfWork.ProductReadRepository.FindAsync(f => f.Id == request.ProductId && f.UserId == request.UserId && f.ShoplistId == shoplist.Id, false);
                    if (product != null)
                    {
                        List<string> withOutSelectedProductShoplist = shoplist.Products.Where(w => w.Id != request.ProductId).Select(w => w.Name).ToList();
                        if (!withOutSelectedProductShoplist.Contains(request.Name))
                        {
                            if (Units.ProductUnits.Contains(request.Unit))
                            {
                                product.Name = request.Name;
                                product.ProductCategoryId = request.ProductCategoryId;
                                product.Description = request.Description;
                                product.Amount = request.Amount;
                                product.Unit = request.Unit;
                                await _unitOfWork.ProductWriteRepository.UpdateAsync(product);
                                _unitOfWork.SaveChanges();
                                return new CommandResponse { IsSuccess= true };
                            }
                            return new CommandResponse { IsSuccess = false, Error = Messages.ErrorUnit };
                        }
                        return new CommandResponse { IsSuccess = false, Error = Messages.ErrorIsExist };
                    }
                    return new CommandResponse { IsSuccess = false, Error = Messages.ErrorNoContent };
                }
                return new CommandResponse { IsSuccess = false, Error = Messages.ErrorNoContent };
            }
            return new CommandResponse { IsSuccess = false, Error = Messages.ErrorNoContent };
        }
    }
}
