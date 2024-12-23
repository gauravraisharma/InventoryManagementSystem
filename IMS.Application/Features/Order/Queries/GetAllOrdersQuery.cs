using IMS.Core.RequestDto;
using MediatR;

namespace IMS.Application.Features.Order.Queries
{
    public class GetAllOrdersQuery : IRequest<List<OrderDto>>
    {
    }
}
