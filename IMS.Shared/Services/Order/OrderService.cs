using IMS.Shared.Common;
using IMS.Shared.Constants;
using IMS.Shared.Interface.Order;
using IMS.Shared.RequestDto.orderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IMS.Shared.Services.Order
{
    public class OrderService:IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<ApiResponse<bool>> SaveOrderAsync(AddOrderDto orderRequest)
        {
            var content = new StringContent(JsonSerializer.Serialize(orderRequest), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(ApiEndpoints.Order.SaveOrder, content);

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
                Message = "Failed to save the order"
            };
        }

        public async Task<ApiResponse<List<GetOrderDto>>> GetAllOrdersAsync()
        {
            try
            {
                var requestUrl = $"{ApiEndpoints.Order.GetAllOrders}";
                var response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<GetOrderDto>>>();
                    return result;
                }

                return new ApiResponse<List<GetOrderDto>>
                {
                    IsSuccess = false,
                    Message = "Failed to fetch order details."
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<GetOrderDto>>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        public async Task<ApiResponse<string>> CreateStripeCheckoutSessionAsync(AddOrderDto orderRequest)
        {
            var content = new StringContent(JsonSerializer.Serialize(orderRequest), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(ApiEndpoints.Order.CreateStripeCheckoutSession, content);
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
                Message = "Failed to create Stripe Checkout session"
            };
        }
        public async Task<ApiResponse<List<GetOrderDto>>> GetAllUserOrdersAsync(string userId)
        {
            try
            {
                var requestUrl = $"{ApiEndpoints.Order.GetAllUserOrders}/{userId}";
                var response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<GetOrderDto>>>();
                    return result;
                }

                return new ApiResponse<List<GetOrderDto>>
                {
                    IsSuccess = false,
                    Message = "Failed to fetch order details."
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<GetOrderDto>>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse<GetOrderDto>> GetOrderByIdAsync(string orderId)
        {
            try
            {
                var requestUrl = $"{ApiEndpoints.Order.GetOrderById}/{orderId}";
                var response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<GetOrderDto>>();
                    return result;
                }

                return new ApiResponse<GetOrderDto>
                {
                    IsSuccess = false,
                    Message = "Failed to fetch order details."
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetOrderDto>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

          
    }
}
