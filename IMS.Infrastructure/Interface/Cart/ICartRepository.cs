using IMS.Core.Common.Helper;
using IMS.Core.Entities;
using IMS.Core.RequestDto;

namespace IMS.Infrastructure.Interface.Cart
{
    public interface ICartRepository
    {
        Task<GenericBaseResult<string>> AddToCartAsync(AddCartItemDto addCartItemDto);
        Task<GenericBaseResult<bool>> EditCartAsync(string cartId, int quantity);
        Task<GenericBaseResult<List<CartDto>>> GetCartItemsByUserIdAsync(string userId);
        Task<bool> DeleteCartItemAsync(string cartId);
    }
}
