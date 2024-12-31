using IMS.Core.Identity;
using IMS.Core.RequestDto;
using IMS.Infrastructure.Interface.Order;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IMS.Application.Features.Order.Queries
{
    public class GetAllUserOrdersQueryHandler : IRequestHandler<GetAllUserOrdersQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetAllUserOrdersQueryHandler(IOrderRepository orderRepository, UserManager<ApplicationUser> userManager)
        {
            _orderRepository = orderRepository;
            _userManager = userManager;
        }

        public async Task<List<OrderDto>> Handle(GetAllUserOrdersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user == null)
                    throw new Exception("User not found.");

                var orders = await _orderRepository.GetOrdersByCustomerIdAsync(request.UserId);

                var result = orders.Select(order => new OrderDto
                {
                    OrderId = order.Id.ToString(),
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    OrderDate = order.OrderDate,
                    TotalAmount = order.TotalAmount,
                    ShipmentDate = order.ShipmentDate,
                    ProductDetails = order.ProductDetails
                })
                .OrderBy(o => o.OrderDate)
                .ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while fetching orders for user {request.UserId}", ex);
            }
        }
    }
}
