using IMS.Application.Features.Order.Command;
using IMS.Application.Features.Order.Queries;
using IMS.Core.Common.Helper;
using IMS.Core.Identity;
using IMS.Core.RequestDto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("AddOrder")]
        public async Task<GenericBaseResult<bool>> AddOrder([FromBody] AddOrderCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return new GenericBaseResult<bool>(true);
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<bool>(false);
                result.AddExceptionLog(ex);
                return result;
            }
        }

        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<GenericBaseResult<List<OrderDto>>> GetAllOrders()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            return new GenericBaseResult<List<OrderDto>>(orders)
            {
                Message = "Orders retrieved successfully"
            };
        }

        [HttpGet]
        [Route("GetOrderById/{orderId}")]
        public async Task<GenericBaseResult<OrderDto>> GetOrderById(string orderId)
        {
            try
            {
                var order = await _mediator.Send(new GetOrderByIdQuery { OrderId = orderId });
                return new GenericBaseResult<OrderDto>(order)
                {
                    Message = "Order retrieved successfully"
                };
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<OrderDto>(null);
                result.AddExceptionLog(ex);
                return result;
            }
        }

        [HttpGet]
        [Route("GetUserOrderById/{userId}")]
        public async Task<GenericBaseResult<List<OrderDto>>> GetUserOrderById(string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    throw new Exception("User ID not found in the token");
                }

                var order = await _mediator.Send(new GetAllUserOrdersQuery {UserId = userId });
                return new GenericBaseResult<List<OrderDto>>(order)
                {
                    Message = "User's order retrieved successfully"
                };
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<List<OrderDto>>(null);
                result.AddExceptionLog(ex);
                return result;
            }
        }
    }
}
