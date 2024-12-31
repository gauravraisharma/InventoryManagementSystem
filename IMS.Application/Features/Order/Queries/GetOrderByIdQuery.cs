using IMS.Core.RequestDto;
using MediatR;

namespace IMS.Application.Features.Order.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public string OrderId { get; set; }
    }
}
