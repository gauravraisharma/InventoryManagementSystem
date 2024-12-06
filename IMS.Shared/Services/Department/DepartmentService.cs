using IMS.Shared.Common;
using IMS.Shared.Constants;
using IMS.Shared.Interface.Department;
using IMS.Shared.RequestDto.DepartmentDTOs;
using IMS.Shared.RequestDto.ProductDTOs;
using System.Net.Http.Json;

namespace IMS.WebApp.Client.Services.Department
{
    public class DepartmentService:IDepartmentService
    {
        private readonly HttpClient _httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<List<GetAllDepartmentDto>>> GetAllDepartmentAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(ApiEndpoints.Department.GetAllDepartments);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<GetAllDepartmentDto>>>();
                    return result;
                }

                return new ApiResponse<List<GetAllDepartmentDto>>
                {
                    IsSuccess = false,
                    Message = "Failed to fetch products"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<GetAllDepartmentDto>>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
     

    }
}
