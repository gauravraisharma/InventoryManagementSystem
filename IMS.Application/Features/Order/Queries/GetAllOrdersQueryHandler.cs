using IMS.Core.Identity;
using IMS.Core.RequestDto;
using IMS.Infrastructure.Interface.Order;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IMS.Application.Features.Order.Queries
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository , UserManager<ApplicationUser> userManager)
        {
            _orderRepository = orderRepository;
            _userManager = userManager;
        }

        public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var orders = await _orderRepository.GetAllOrdersAsync();
                var users = await _userManager.GetUsersInRoleAsync("user");

                var result = orders.Join(users,
                                          order => order.CustomerId,
                                          user => user.Id,
                                          (order, user) => new OrderDto
                                          {
                                              OrderId = order.Id.ToString(),
                                              UserName = user.UserName,
                                              FirstName = user.FirstName,
                                              OrderDate = order.OrderDate,
                                              TotalAmount = order.TotalAmount,
                                              ShipmentDate = order.ShipmentDate,
                                              ProductDetails = order.ProductDetails
                                          })
                                    .OrderBy(o => o.UserName) 
                                    .ThenBy(o => o.OrderDate) 
                                    .ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while fetching orders", ex);
            }
        }
    }
}
