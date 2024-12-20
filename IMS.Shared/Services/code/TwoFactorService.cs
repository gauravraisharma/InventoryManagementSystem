using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using IMS.Shared.Common;
using IMS.Shared.Constants;
using IMS.Shared.Interface.Code;

namespace IMS.Shared.Services.code
{
    public class TwoFactorService : ITwoFactorService
    {
        private readonly HttpClient _httpClient;

        public TwoFactorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ApiResponse<string>> SendCodeAsync(string email)
        {
            try
            {
                var requestUrl = $"{ApiEndpoints.TwoFactor.SendCode}?email={email}";
                var response = await _httpClient.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();
                    return result;
                }
                return new ApiResponse<string>
                {
                    IsSuccess = false,
                    Message = "Failed to fetch products"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse<bool>> ValidateCode(string email, string code)
        {
            var loginPayload = new
            {
                Email = email,
                Code = code
            };

            var content = new StringContent(JsonSerializer.Serialize(loginPayload), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(ApiEndpoints.TwoFactor.ValidateCode, content);

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
                Message = "Failed to login"
            };
        }
    }
}
