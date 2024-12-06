using IMS.Shared.Common;
using IMS.Shared.Constants;
using IMS.Shared.Interface.Category;
using IMS.Shared.RequestDto.CategoryDTOs;
using System.Net.Http.Json;

namespace IMS.WebApp.Client.Services.Category
{
    public class CategoryService:ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<List<GetAllCategoryDto>>> GetAllCategoryAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(ApiEndpoints.Category.GetAllCategories);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<GetAllCategoryDto>>>();
                    return result;
                }

                return new ApiResponse<List<GetAllCategoryDto>>
                {
                    IsSuccess = false,
                    Message = "Failed to fetch products"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<GetAllCategoryDto>>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
