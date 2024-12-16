using IMS.Shared.Common;
using IMS.Shared.RequestDto.CartDTOs;
using IMS.Shared.RequestDto.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Shared.Interface.Cart
{
    public interface ICartService
    {
        Task<ApiResponse<List<CartDto>>> GetCartDetailsByUserIdAsync(string userId);
        Task<ApiResponse<string>> AddToCart(AddCartItemDto cartItem);
        Task<ApiResponse<bool>> UpdateCart(string CartItemId, int Quantity);
        Task<ApiResponse<bool>> DeleteCartItem(string CartItemId);

    }
}
