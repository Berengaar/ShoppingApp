using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Features.ShoplistFeature.Commands.AddShoplist;
using ShoppingApp.Application.Features;
using ShoppingApp.Infrastructure.Helpers;
using ShoppingApp.Application.Features.ProductCategoryFeature.Commands.AddProductCategory;

namespace ShoppingApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddProductCategoryCommandRequest request)
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
