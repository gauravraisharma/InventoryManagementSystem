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
     private int _cartItemCount;
     public int CartItemCount
     {
         get => _cartItemCount;
         private set
         {
             if (_cartItemCount != value)
             {
                 _cartItemCount = value;
                 NotifyStateChanged();
             }
         }
     }

     public event Action OnChange;

     private void NotifyStateChanged() => OnChange?.Invoke();
     public event Action OnCartUpdated;
     public void SetCartItemCount(int count)
     {
         CartItemCount = count;
     }
     private List<CartDto> _cartItems = new();

     public List<CartDto> GetCartItems()
     {
         return _cartItems;
     }

     public void SetCartItems(List<CartDto> items)
     {
         _cartItems = items;
         SetCartItemCount(items.Count);
     }
 }
}
