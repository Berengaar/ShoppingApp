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

namespace ShoppingApp.Application.Features.ShoplistFeature.Commands.RemoveProductInShoplist
{
    public class RemoveProductInShoplistCommandHandler : IRequestHandler<RemoveProductInShoplistCommandRequest, CommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveProductInShoplistCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CommandResponse> Handle(RemoveProductInShoplistCommandRequest request, CancellationToken cancellationToken)
        {
            Shoplist shoplist = await _unitOfWork.ShoplistReadRepository.FindAsync(f => f.Id == request.ShoplistId & f.UserId == request.UserId, false, f => f.Products);
            if(shoplist != null)
            {
                if (shoplist.Products.FirstOrDefault(f => f.Id == request.ProductId) != null)
                {
                    Product product = await _unitOfWork.ProductReadRepository.FindAsync(f => f.Id == request.ProductId,false);
                    if(product != null)
                    {
                        shoplist.Products.Remove(product);
                        await _unitOfWork.ProductWriteRepository.DeleteAsync(product);
                        _unitOfWork.SaveChanges();
                        return new CommandResponse { IsSuccess = true };
                    }
                    return new CommandResponse { IsSuccess = false, Error = Messages.ErrorNoContent };
                }
                return new CommandResponse { IsSuccess = false, Error = Messages.ErrorNoContent };
            }
            return new CommandResponse { IsSuccess = false, Error = Messages.ErrorNoContent };
        }
    }
}
