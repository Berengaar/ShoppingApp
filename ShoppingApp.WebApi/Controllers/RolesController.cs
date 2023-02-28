using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Features;
using ShoppingApp.Application.Features.RoleFeature.Commands.AddRole;
using ShoppingApp.Infrastructure.Helpers;

namespace ShoppingApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
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
            int? userId = ClaimsHelper.GetClaimValueInt("nameidentifier", User);
            if (userId != null)
            {
                CommandResponse result = await _mediator.Send(request);
                if (result.IsSuccess)
                {
                    return StatusCode(201);
                }
                return BadRequest(result.Error);
            }
            return Unauthorized();
        }
    }
}
