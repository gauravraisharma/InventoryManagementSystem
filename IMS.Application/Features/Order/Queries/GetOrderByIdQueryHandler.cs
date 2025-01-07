using IMS.Core.Identity;
using IMS.Core.RequestDto;
using IMS.Infrastructure.Interface.Order;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IMS.Application.Features.Order.Queries
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository, UserManager<ApplicationUser> userManager)
        {
            _orderRepository = orderRepository;
            _userManager = userManager;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);
                if (order == null)
                    throw new Exception($"Order with ID {request.OrderId} not found.");

                var user = await _userManager.FindByIdAsync(order.CustomerId);
                if (user == null)
                    throw new Exception("User associated with this order not found.");

                var result = new OrderDto
                {
                    Address = order.AddressTbl,
                    OrderId = order.Id.ToString(),
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    OrderDate = order.OrderDate,
                    TotalAmount = order.TotalAmount,
                    ShipmentDate = order.ShipmentDate,
                    ProductDetails = order.ProductDetails
                };

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while fetching order {request.OrderId}", ex);
            }
        }
    }
}
