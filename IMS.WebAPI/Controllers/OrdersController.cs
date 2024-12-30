using IMS.Application.Features.Order.Command;
using IMS.Application.Features.Order.Queries;
using IMS.Core.Common.Helper;
using IMS.Core.Identity;
using IMS.Core.RequestDto;
using MediatR;
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
            //return Ok(orders);
            return new GenericBaseResult<List<OrderDto>>(orders)
            {
                Message = "Orders retrieved successfully"
            };
        }
        [HttpPost]
        [Route("CreateStripeCheckoutSession")]
        public async Task<GenericBaseResult<string>> CreateStripeCheckoutSession([FromBody] CreateStripeCheckoutSessionCommand command)
        {
            try
            {
                var sessionId = await _mediator.Send(command);
                return new GenericBaseResult<string>(sessionId);
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<string>(null);
                result.AddExceptionLog(ex); 
                result.Message = "Error occurred while creating Stripe Checkout session."; 
                return result;
            }
        }

    }
}
