using MediatR;
using ShoppingApp.Application.Common.Repositories.AdminRepositories;
using ShoppingApp.Domain.Consts;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.ShoplistFeature.Commands.AddCompletedShoplist
{
    public class AddCompletedShoplistCommandHandler : IRequestHandler<AddCompletedShoplistCommandRequest, CommandResponse>
    {
        private readonly IAdminWriteRepository _adminRepository;

        public AddCompletedShoplistCommandHandler(IAdminWriteRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<CommandResponse> Handle(AddCompletedShoplistCommandRequest request, CancellationToken cancellationToken)
        {
            AdminShoplist adminShoplist = new()
            {
                Id = request.Id,
                Name = request.Name,
                UserId = request.UserId,
            };
            bool result=await _adminRepository.AddAsync(adminShoplist);
            if(result)
            {
                return new CommandResponse { IsSuccess= true };
            }
            return new CommandResponse { IsSuccess = false, Error = Messages.ErrorAdd };
        }
    }
}
