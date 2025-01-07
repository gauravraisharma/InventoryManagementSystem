using IMS.Infrastructure.Interface.Order;
using MediatR;

namespace IMS.Application.Features.Order.Command
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public AddOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {

            var order = new Orders
            {
                CustomerId = request.CustomerId,
                OrderDate = request.OrderDate,
                TotalAmount = request.TotalAmount,
                ProductDetails = request.ProductDetails,
                AddressId = request.AddressId
            };

            await _orderRepository.AddOrderAsync(order);
            await _orderRepository.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
