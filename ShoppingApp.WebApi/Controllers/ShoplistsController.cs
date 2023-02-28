using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Features.ShoplistCategoryFeature.Commands.AddShoplistCategory;
using ShoppingApp.Application.Features;
using ShoppingApp.Infrastructure.Helpers;
using ShoppingApp.Application.Features.ShoplistFeature.Commands.AddShoplist;
using ShoppingApp.Application.Features.ShoplistFeature.Commands.AddProductToShoplist;
using ShoppingApp.Application.Features.ShoplistFeature.Commands.UpdateProductInShoplist;
using ShoppingApp.Application.Features.ShoplistFeature.Commands.RemoveProductInShoplist;
using ShoppingApp.Application.Common.Utilities.Abstract;
using ShoppingApp.Application.Features.ShoplistFeature.Queries.GetShoplistByCategoryId;
using ShoppingApp.Application.Features.ShoplistFeature.Queries.GetAllShoplists;
using ShoppingApp.Application.Features.ShoplistFeature.Queries.GetAllShoplistWithCache;
using RabbitMQ.Client;
using System.Text;
using ShoppingApp.Application.Features.ShoplistFeature.Commands.CompleteShoplist;
using ShoppingApp.Application.Features.ShoplistFeature.Queries.GetShoplistById;
using Microsoft.AspNetCore.Authorization;
using ShoppingApp.Domain.Consts;

namespace ShoppingApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Member")]
    public class ShoplistsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoplistsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllShoplistsQueryRequest request)
        {
            int? userId = ClaimsHelper.GetClaimValueInt("nameidentifier", User);
            if (userId != null)
            {
                request.UserId = (int)userId;
                IDataResult<GetAllShoplistsQueryResponse> result = await _mediator.Send(request);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            return Unauthorized();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWithCacheAsync([FromQuery] GetAllShoplistWithCacheCommandRequest request)
        {
            int? userId = ClaimsHelper.GetClaimValueInt("nameidentifier", User);
            if (userId != null)
            {
                request.UserId = (int)userId;
                IDataResult<GetAllShoplistWithCacheCommandResponse> result = await _mediator.Send(request);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            return Unauthorized();
        }
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetShoplistByIdQueryRequest request)
        {
            int? userId = ClaimsHelper.GetClaimValueInt("nameidentifier", User);
            if (userId != null)
            {
                request.UserId = (int)userId;
                IDataResult<GetShoplistByIdQueryResponse> result = await _mediator.Send(request);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            return Unauthorized();
        }
        [HttpGet]
        public async Task<IActionResult> GetByCategoryIdAsync([FromQuery] GetShoplistByCategoryIdQueryRequest request)
        {
            int? userId = ClaimsHelper.GetClaimValueInt("nameidentifier", User);
            if (userId != null)
            {
                request.UserId = (int)userId;
                IDataResult<GetShoplistByCategoryIdQueryResponse> result = await _mediator.Send(request);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            return Unauthorized();
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddShoplistCommandRequest request)
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
        [HttpPost]
        public async Task<IActionResult> AddProductToShoplistAsync(AddProductToShoplistCommandRequest request)
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
        [HttpPut]
        public async Task<IActionResult> UpdateProductInShoplistAsync(UpdateProductInShoplistCommandRequest request)
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
        [HttpPatch]
        public async Task<IActionResult> CompleteShoplistAsync(CompleteShoplistCommandRequest request)
        {
            int? userId = ClaimsHelper.GetClaimValueInt("nameidentifier", User);
            if (userId != null)
            {
                request.UserId = userId;
                IDataResult<CompleteShoplistCommandResponse> response = await _mediator.Send(request);
                if (response.Success)
                {
                    ConnectionFactory connectionFactory = new ConnectionFactory() { HostName = "localhost", UserName = "admin", Password = "123456" };
                    //Channel yaratmak için
                    using (IConnection connection = connectionFactory.CreateConnection())
                    using (IModel channel = connection.CreateModel())
                    {
                        string message = System.Text.Json.JsonSerializer.Serialize(response.Data.AdminShoplist);
                        byte[] body = Encoding.UTF8.GetBytes(message);

                        //Queue ya atmak için kullanılır.
                        channel.BasicPublish(exchange: "",//mesajın alınıp bir veya birden fazla queue ya konmasını sağlıyor.
                            routingKey: "ShoplistQueue", //Hangi queue ya atanacak.
                            body: body);//Mesajın içeriği
                    }
                    return Ok();
                }
                return BadRequest();
            }
            return Unauthorized();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveProductInShoplistAsync(RemoveProductInShoplistCommandRequest request)
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
