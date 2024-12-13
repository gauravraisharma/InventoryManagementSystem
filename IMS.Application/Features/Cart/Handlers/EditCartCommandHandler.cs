using IMS.Application.Features.Cart.Command;
using IMS.Infrastructure.Interface.Cart;
using MediatR;

namespace IMS.Application.Features.Cart.Handlers
{
    public class EditCartCommandHandler : IRequestHandler<EditCartCommand, bool>
    {
        private readonly ICartRepository _cartRepository;

        public EditCartCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<bool> Handle(EditCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _cartRepository.EditCartAsync(request.CartId, request.Quantity);

            if (!result.IsSuccess)
                throw new Exception(result.Message);

            return result.Result;
        }
    }
}
