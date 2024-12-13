using IMS.Application.Features.Cart.Command;
using IMS.Infrastructure.Interface.Cart;
using MediatR;

namespace IMS.Application.Features.Cart.Handlers
{
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, bool>
    {
        private readonly ICartRepository _cartRepository;

        public DeleteCartItemCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<bool> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            return await _cartRepository.DeleteCartItemAsync(request.CartId);
        }
    }
}
