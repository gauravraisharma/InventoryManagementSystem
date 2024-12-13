using MediatR;

namespace IMS.Application.Features.Cart.Command
{
    public class DeleteCartItemCommand : IRequest<bool>
    {
        public string CartId { get; set; }
    }
}
