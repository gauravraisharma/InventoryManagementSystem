using IMS.Application.Features.Order.Command;
using IMS.Application.Features.Order.Queries;
using IMS.Core.Common.Helper;
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
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(orders);
        }
    }
}
