using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Shared.RequestDto.CartDTOs;
namespace IMS.Shared.Services.Shared
{
    public class CartStateService
    {
        private List<CartDto> _cartItems = new();

        public List<CartDto> GetCartItems()
        {
            return _cartItems;
        }

        public void SetCartItems(List<CartDto> items)
        {
            _cartItems = items;
        }
    }
}
