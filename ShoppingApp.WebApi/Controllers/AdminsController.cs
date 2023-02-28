using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Features.ShoplistFeature.Commands.AddProductToShoplist;
using ShoppingApp.Application.Features;
using ShoppingApp.Infrastructure.Helpers;
using MediatR;
using ShoppingApp.Application.Features.ShoplistFeature.Commands.AddCompletedShoplist;

namespace ShoppingApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddCompletedShoplistAsync(AddCompletedShoplistCommandRequest request)
        {
            int? userId = ClaimsHelper.GetClaimValueInt("nameidentifier", User);

            CommandResponse result = await _mediator.Send(request);
            if (result.IsSuccess)
            {
                return StatusCode(201);
            }
            return BadRequest(result.Error);
        }
    }
}
