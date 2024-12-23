using IMS.Shared.Common;
using System.Net.Http.Json;

namespace IMS.Shared.Services.Base
{
   
    public abstract class BaseHttpService
    {
        protected readonly HttpClient _httpClient;

        public BaseHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<ApiResponse<T>> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<ApiResponse<T>>();
                return data;
            }

            // Handle errors
            return new ApiResponse<T>
            {
                IsSuccess = false,
                Message = response.ReasonPhrase ?? "An error occurred."
            };
        }
    }

}
