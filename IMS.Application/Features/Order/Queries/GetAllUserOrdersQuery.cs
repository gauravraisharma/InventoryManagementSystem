using IMS.Core.RequestDto;
using MediatR;

namespace IMS.Application.Features.Order.Queries
{
    public class GetAllUserOrdersQuery : IRequest<List<OrderDto>>
    {
        public string UserId { get; set; }
    }
}
