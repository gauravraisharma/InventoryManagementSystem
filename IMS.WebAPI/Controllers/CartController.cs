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

        [HttpPost]
        [Route("AddToCart")]
        public async Task<GenericBaseResult<string>> AddToCart(AddToCartCommand command)
        {
            var cartId = await _mediator.Send(command);
            return new GenericBaseResult<string>(cartId);
        }

        [HttpPut]
        [Route("EditCart")]
        public async Task<GenericBaseResult<bool>> EditCart(EditCartCommand command)
        {
            var success = await _mediator.Send(command);
            return success ? new GenericBaseResult<bool>(true) : new GenericBaseResult<bool>(false);
        }

        [HttpGet]
        [Route("GetCartItems/{userId}")]
        public async Task<GenericBaseResult<List<CartDto>>> GetCartItems(string userId)
        {
            var query = new GetCartItemsQuery { UserId = userId };
            var cartItems = await _mediator.Send(query);
            return new GenericBaseResult<List<CartDto>>(cartItems);
        }

        [HttpDelete]
        [Route("DeleteCartItem/{cartId}")]
        public async Task<GenericBaseResult<bool>> DeleteCartItem(string cartId)
        {
            var command = new DeleteCartItemCommand { CartId = cartId };
            var success = await _mediator.Send(command);
            return new GenericBaseResult<bool>(success);
        }

        [HttpDelete]
        [Route("DeleteAllCartItemsByUserId/{userId}")]
        public async Task<GenericBaseResult<bool>> DeleteAllCartItemsByUserId(string userId)
        {
            var command = new DeleteAllCartItemsByUserIdCommand { UserId = userId };
            var success = await _mediator.Send(command);
            return new GenericBaseResult<bool>(success);
        }

    }
}
