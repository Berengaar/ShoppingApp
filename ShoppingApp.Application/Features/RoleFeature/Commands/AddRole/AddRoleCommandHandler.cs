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

namespace ShoppingApp.Application.Features.RoleFeature.Commands.AddRole
{
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddRoleCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResponse> Handle(AddRoleCommandRequest request, CancellationToken cancellationToken)
        {
            Role addedRole = _mapper.Map<Role>(request);
            if (addedRole != null)
            {
                bool result = await _unitOfWork.RoleWriteRepository.AddAsync(addedRole);
                if (result)
                {
                    _unitOfWork.SaveChanges();
                    return new CommandResponse { IsSuccess = true, Error = null };
                }
                return new CommandResponse { IsSuccess = false, Error = Messages.ErrorAdd };
            }
            return new CommandResponse { IsSuccess = false, Error = Messages.ErrorAdd };
        }
    }
}
