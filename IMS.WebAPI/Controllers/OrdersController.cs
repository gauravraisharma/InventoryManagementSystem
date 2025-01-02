using IMS.Application.Features.Cart.Command;
using IMS.Application.Features.Order.Command;
using IMS.Application.Features.Order.Queries;
using IMS.Core.Common.Entities;
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
       
        [HttpGet]
        [Route("StripeSuccess")]
        public async Task<IActionResult> StripeSuccess([FromQuery] string orderDetails, [FromQuery] string userId, [FromQuery] string totalAmount)
        {
            try
            {
                if (string.IsNullOrEmpty(orderDetails) || string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(totalAmount))
                {
                    return BadRequest("Missing required parameters.");
                }
                var decodedOrderDetails = System.Web.HttpUtility.UrlDecode(orderDetails);
                var productDetails = System.Text.Json.JsonSerializer.Deserialize<List<OrderProductDetails>>(decodedOrderDetails);
                var parsedTotalAmount = decimal.Parse(totalAmount);
                var orderDate = DateTime.Now;
                var addOrderCommand = new AddOrderCommand(userId, orderDate, parsedTotalAmount, productDetails);
                await _mediator.Send(addOrderCommand);
                var deleteUserCartCommand = new DeleteAllCartItemsByUserIdCommand();
                deleteUserCartCommand.UserId = userId;  
                await _mediator.Send(deleteUserCartCommand);
                return Redirect("https://localhost:7093/success");
            }
            catch(Exception e)
            {
                return Redirect("https://localhost:7093/success");
            }
        }

    }
}
