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

namespace ShoppingApp.Application.Features.CountryFeature.Commands.AddCountry
{
    public class AddCountryCommandHandler : IRequestHandler<AddCountryCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddCountryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResponse> Handle(AddCountryCommandRequest request, CancellationToken cancellationToken)
        {
            Country addedCountry = _mapper.Map<Country>(request);
            if (addedCountry != null)
            {
                bool result = await _unitOfWork.CountryWriteRepository.AddAsync(addedCountry);
                if (result)
                {
                    _unitOfWork.SaveChanges();
                    return new CommandResponse { IsSuccess = true };
                }
                return new CommandResponse { IsSuccess = false, Error = Messages.ErrorAdd };
            }
            return new CommandResponse { IsSuccess = false, Error = Messages.ErrorAdd };
        }
    }
}
