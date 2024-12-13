using IMS.Application.Features.Cart.Command;
using IMS.Application.Features.Cart.Queries;
using IMS.Core.Common.Helper;
using IMS.Core.RequestDto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart(AddToCartCommand command)
        {
            var cartId = await _mediator.Send(command);
            return Ok(new { CartId = cartId });
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditCart(EditCartCommand command)
        {
            var success = await _mediator.Send(command);
            return success ? Ok() : NotFound();
        }

        [HttpGet("user/{userId}")]
        public async Task<GenericBaseResult<List<CartDto>>> GetCartItems(string userId)
        {
            var query = new GetCartItemsQuery { UserId = userId };
            var cartItems = await _mediator.Send(query);
            return new GenericBaseResult<List<CartDto>>(cartItems);
        }
    }
}
