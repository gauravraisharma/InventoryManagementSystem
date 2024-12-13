using IMS.Core.Common.Helper;
using IMS.Core.Common.ResponseModel;
using IMS.Core.Entities;
using IMS.Core.RequestDto;
using IMS.Infrastructure.Interface.Cart;
using IMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.Services.Cart
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GenericBaseResult<string>> AddToCartAsync(AddCartItemDto addCartItemDto)
        {
            try
            {
                var existingCart = await _context.Carts
                    .FirstOrDefaultAsync(c => c.UserId == addCartItemDto.UserId
                                           && c.ProductId == addCartItemDto.ProductId
                                           && c.ProductSizeId == addCartItemDto.ProductSizeName);

                if (existingCart == null)
                {
                    var cart = new Core.Entities.Cart
                    {
                        UserId = addCartItemDto.UserId,
                        ProductId = addCartItemDto.ProductId,
                        ProductSizeId = addCartItemDto.ProductSizeName,
                        Quantity = addCartItemDto.Quantity,
                        Created = DateTime.UtcNow,
                        CreatedBy = addCartItemDto.UserId
                    };

                    _context.Carts.Add(cart);
                    await _context.SaveChangesAsync();
                    return new GenericBaseResult<string>(cart.Id);
                }
                else
                {
                    existingCart.Quantity += addCartItemDto.Quantity;
                    existingCart.LastModified = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                    return new GenericBaseResult<string>(existingCart.Id);
                }
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<string>(null);
                result.AddExceptionLog(ex);
                return result;
            }
        }

        public async Task<GenericBaseResult<bool>> EditCartAsync(string cartId, int quantity)
        {
            try
            {
                var cart = await _context.Carts.FindAsync(cartId);
                if (cart == null)
                {
                    throw new Exception("Cart is not found");
                }

                cart.Quantity = quantity;
                cart.LastModified = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                return new GenericBaseResult<bool>(true);
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<bool>(false);
                result.AddExceptionLog(ex);
                return result;
            }
        }

        public async Task<GenericBaseResult<List<CartDto>>> GetCartItemsByUserIdAsync(string userId)
        {
            try
            {
                var cartItems = await _context.Carts
                    .Where(c => c.UserId == userId)
                    .Include(c => c.Product)
                    .Include(c => c.ProductSize)
                    .Include(c => c.Product.ProductImages) // Include product images
                    .ToListAsync();

                var cartDtoList = cartItems.Select(c => new CartDto
                {
                    CartId = c.Id,
                    UserId = c.UserId,
                    ProductId = c.ProductId,
                    ProductSizeId = c.ProductSizeId,
                    ProductName = c.Product?.Title,
                    ProductDescription = c.Product?.Description,
                    ProductSize = c.ProductSize?.Size,
                    Quantity = c.Quantity,
                    UnitPrice = c.Product?.UnitPrice ?? 0,
                    TotalPrice = c.Quantity * (c.Product?.UnitPrice ?? 0),
                    ProductImageUrls = c.Product?.ProductImages.Select(img => img.Base64Image).ToList() ?? new List<string>()
                }).ToList();

                return new GenericBaseResult<List<CartDto>>(cartDtoList);
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<List<CartDto>>(null);
                result.AddExceptionLog(ex);
                return result;
            }
        }

        public async Task<bool> DeleteCartItemAsync(string cartId)
        {
            var cartItem = await _context.Carts.FindAsync(cartId);
            if (cartItem == null) return false;
            _context.Carts.Remove(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}