using MediatR;

namespace IMS.Application.Features.Cart.Command
{
    public class AddToCartCommand : IRequest<string> 
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public string? ProductSizeId { get; set; }
        public int Quantity { get; set; }
    }
}
