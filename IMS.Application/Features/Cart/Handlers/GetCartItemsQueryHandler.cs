using IMS.Application.Features.Cart.Queries;
using IMS.Core.RequestDto;
using IMS.Infrastructure.Interface.Cart;
using MediatR;

namespace IMS.Application.Features.Cart.Handlers
{
    public class GetCartItemsQueryHandler : IRequestHandler<GetCartItemsQuery, List<CartDto>>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartItemsQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<List<CartDto>> Handle(GetCartItemsQuery request, CancellationToken cancellationToken)
        {
            var result = await _cartRepository.GetCartItemsByUserIdAsync(request.UserId);

            if (!result.IsSuccess)
                throw new Exception(result.Message);

            return result.Result;
        }
    }
}
