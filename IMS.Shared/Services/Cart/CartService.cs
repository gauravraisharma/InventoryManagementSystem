using IMS.Shared.Common;
using IMS.Shared.Constants;
using IMS.Shared.Interface.Cart;
using IMS.Shared.RequestDto.CartDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IMS.Shared.Services.Cart
{
    public class CartService:ICartService
    {
        private readonly HttpClient _httpClient;

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<List<CartDto>>> GetCartDetailsByUserIdAsync(string userId)
        {
            try
            {
                var requestUrl = $"{ApiEndpoints.Cart.GetCartItems}/{userId}";
                var response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<CartDto>>>();
                    return result;
                }

                return new ApiResponse<List<CartDto>>
                {
                    IsSuccess = false,
                    Message = "Failed to fetch cart details."
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<CartDto>>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
   
        public async Task<ApiResponse<string>> AddToCart(AddCartItemDto cartItem)
        {
            var content = new StringContent(JsonSerializer.Serialize(cartItem), Encoding.UTF8, "application/json");

            //var response = await _httpClient.PostAsync("api/cart/add", content);
            var response = await _httpClient.PostAsync(ApiEndpoints.Cart.AddToCart, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse<string>>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return apiResponse;
            }

            return new ApiResponse<string>
            {
                IsSuccess = false,
                Message = "Failed to add item to cart"
            };
        }

        public async Task<ApiResponse<bool>> UpdateCart(string CartItemId, int Quantity)
        {
            var loginPayload = new
            {
                CartId = CartItemId,
                Quantity = Quantity
            };

            var content = new StringContent(JsonSerializer.Serialize(loginPayload), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(ApiEndpoints.Cart.UpdateCart, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse<bool>>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return apiResponse;
            }

            return new ApiResponse<bool>
            {
                IsSuccess = false,
                Message = "Failed to add item to cart"
            };
        }

        public async Task<ApiResponse<bool>> DeleteCartItem(string cartItemId)
        {
            try
            {
                var requestUrl = $"{ApiEndpoints.Cart.DeleteCartItem}/{cartItemId}";
                var response = await _httpClient.DeleteAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<bool>>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return apiResponse ?? new ApiResponse<bool>
                    {
                        IsSuccess = false,
                        Message = "No response content from server"
                    };
                }

                return new ApiResponse<bool>
                {
                    IsSuccess = false,
                    Message = "Failed to delete cart item"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        public async Task<ApiResponse<bool>> DeleteAllCartItemsByUserId(string userId)
        {
            try
            {
                var requestUrl = $"{ApiEndpoints.Cart.DeleteAllCartItemsByUserId}/{userId}";
                var response = await _httpClient.DeleteAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<bool>>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return apiResponse ?? new ApiResponse<bool>
                    {
                        IsSuccess = false,
                        Message = "No response content from server"
                    };
                }

                return new ApiResponse<bool>
                {
                    IsSuccess = false,
                    Message = "Failed to delete cart items"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }


    }
}
