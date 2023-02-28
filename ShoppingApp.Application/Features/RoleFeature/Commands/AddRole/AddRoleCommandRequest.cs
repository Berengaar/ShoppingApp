using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features.RoleFeature.Commands.AddRole
{
    public class AddRoleCommandRequest: IRequest<CommandResponse>
    {
        public string Name { get; set; }
    }
}
