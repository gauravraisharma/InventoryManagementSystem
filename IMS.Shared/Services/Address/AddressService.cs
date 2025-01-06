using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using IMS.Shared.Common;
using IMS.Shared.Constants;
using IMS.Shared.Interface.Address;
using IMS.Shared.RequestDto;

namespace IMS.Shared.Services.Address
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<List<AddressDTO>>> GetAddressesByUserIdAsync(string userId)
        {
            try
            {
                var requestUrl = $"{ApiEndpoints.AddressEndpoints.GetAddressByUserID}/{userId}";
                var response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<AddressDTO>>>();
                    return result;
                }

                return new ApiResponse<List<AddressDTO>>
                {
                    IsSuccess = false,
                    Message = "Failed to fetch addresses."
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<AddressDTO>>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse<string>> AddAddressAsync(string userId,string city, string country, string street)
        {

            var addAddressPayload = new
            {
               UserId = userId,
               City = city,
               Country = country,
               Street = street
            };
            var content = new StringContent(JsonSerializer.Serialize(addAddressPayload), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(ApiEndpoints.AddressEndpoints.AddAddress, content);

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
                Message = "Failed to add address."
            };
        }

        public async Task<ApiResponse<bool>> UpdateAddressAsync(string userId, string addressId, string city, string country, string street,bool isActive)
        {
            var updateAddressPayload = new
            {
                Id= addressId,
                UserId= userId,
                City = city,
                Country = country,
                Street = street,
                IsActive = isActive
            };

            var content = new StringContent(JsonSerializer.Serialize(updateAddressPayload), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(ApiEndpoints.AddressEndpoints.UpdateAddress, content);

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
                Message = "Failed to update address."
            };
        }

        public async Task<ApiResponse<bool>> DeleteAddressAsync(string addressId)
        {
            try
            {
                var requestUrl = $"{ApiEndpoints.AddressEndpoints.DeleteAddress}/{addressId}";
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
                    Message = "Failed to delete address"
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
