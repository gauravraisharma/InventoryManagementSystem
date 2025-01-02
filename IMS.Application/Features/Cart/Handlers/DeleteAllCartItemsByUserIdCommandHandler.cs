using IMS.Application.Features.Cart.Command;
using IMS.Infrastructure.Interface.Cart;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Features.Cart.Handlers
{
    public class DeleteAllCartItemsByUserIdCommandHandler : IRequestHandler<DeleteAllCartItemsByUserIdCommand, bool>
    {
        private readonly ICartRepository _cartRepository;

        public DeleteAllCartItemsByUserIdCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<bool> Handle(DeleteAllCartItemsByUserIdCommand request, CancellationToken cancellationToken)
        {
            return await _cartRepository.DeleteAllCartItemsByUserIdAsync(request.UserId);
        }
    }

}
