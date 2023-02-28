using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Features;
using ShoppingApp.Application.Features.RoleFeature.Commands.AddRole;

namespace ShoppingApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddRoleCommandRequest request)
        {
            CommandResponse result = await _mediator.Send(request);
            if (result.IsSuccess)
            {
                return StatusCode(201);
            }
            return BadRequest(result.Error);
        }
    }
}
