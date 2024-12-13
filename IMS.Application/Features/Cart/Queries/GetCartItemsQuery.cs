using MediatR;

namespace IMS.Application.Features.Cart.Queries
{
    public class GetCartItemsQuery : IRequest<List<Core.RequestDto.CartDto>>
    {
        public string UserId { get; set; }
    }
}
