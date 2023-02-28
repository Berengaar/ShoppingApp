using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Common.Interfaces;
using ShoppingApp.Application.Common.Model.Identity;

namespace ShoppingApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IMediator _mediator;

        public UsersController(IIdentityService identityService, IMediator mediator)
        {
            _identityService = identityService;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginModel loginModel)
        {
            string token = await _identityService.LoginAsync(loginModel);
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Giriş başarısız");
            }
            return Ok(token);
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterModel registerModel)
        {
            bool result = await _identityService.RegisterAsync(registerModel);
            if (result)
            {
                return StatusCode(201);
            }
            return BadRequest();
        }
    }
}
