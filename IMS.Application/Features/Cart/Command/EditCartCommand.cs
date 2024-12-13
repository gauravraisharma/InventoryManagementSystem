using MediatR;

namespace IMS.Application.Features.Cart.Command
{
    public class EditCartCommand : IRequest<bool> 
    {
        public string CartId { get; set; }
        public int Quantity { get; set; }
    }
}
