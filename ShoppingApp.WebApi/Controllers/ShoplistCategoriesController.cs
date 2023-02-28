using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Features.CountryFeature.Commands.AddCountry;
using ShoppingApp.Application.Features;
using Microsoft.AspNetCore.Authorization;
using ShoppingApp.Domain.Consts;
using ShoppingApp.Infrastructure.Helpers;
using ShoppingApp.Application.Features.ShoplistCategoryFeature.Commands.AddShoplistCategory;

namespace ShoppingApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Member)]
    public class ShoplistCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoplistCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddShoplistCategoryCommandRequest request)
        {
            int? userId = ClaimsHelper.GetClaimValueInt("nameidentifier", User);
            if (userId != null)
            {
                request.UserId = userId;
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
