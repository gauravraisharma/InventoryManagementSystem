using IMS.Shared.Common;
using IMS.Shared.Constants;
using IMS.Shared.Interface.Product;
using IMS.Shared.RequestDto;
using IMS.Shared.RequestDto.ProductDTOs;
using IMS.Shared.Services.Base;
using System.Net.Http.Json;
using static IMS.Shared.Constants.ApiEndpoints;

namespace IMS.Shared.Services.Product
{
    public class ProductService : IProductService
    {
       

        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<ApiResponse<List<GetAllProductDto>>> GetAllProductsAsync(string department, string category,string searchText, string sortBy)
        {
            try
            {
                // Construct the query string
                var query = $"?department={department}&category={category}&searchText={searchText}&sortBy={sortBy}";

                var response = await _httpClient.GetAsync($"{ApiEndpoints.Product.Get}{query}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<GetAllProductDto>>>();
                    return result;
                }
                return new ApiResponse<List<GetAllProductDto>>
                {
                    IsSuccess = false,
                    Message = "Failed to fetch products"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<GetAllProductDto>>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }


        public async Task<ApiResponse<GetAllProductDto>> GetProductByIdAsync(string Id)
        {
            try
            {
                var requestUrl = $"{ApiEndpoints.Product.GetById}?id={Id}";
                var response = await _httpClient.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<GetAllProductDto>>();
                    return result;
                }
                return new ApiResponse<GetAllProductDto>
                {
                    IsSuccess = false,
                    Message = "Failed to fetch products"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<GetAllProductDto>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse<DeleteProductDto>> DeleteProductByIdAsync(string Id)
        {
            try
            {
                var requestUrl = $"{ApiEndpoints.Product.DeleteById}?id={Id}";
                var response = await _httpClient.DeleteAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<DeleteProductDto>>();
                    return result;
                }
                return new ApiResponse<DeleteProductDto>
                {
                    IsSuccess = false,
                    Message = "Failed to Delete product"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<DeleteProductDto>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        public async Task<ApiResponse<ProductResponse>> AddProductAsync(MultipartFormDataContent formData)
        {
            try
            {
                var response = await _httpClient.PostAsync(ApiEndpoints.Product.SaveProducts, formData);
                if (response.IsSuccessStatusCode)
                {
                    var rawResponseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Raw response content: " + rawResponseContent);
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<ProductResponse>>();
                    return result;
                }
                return new ApiResponse<ProductResponse>
                {
                    IsSuccess = false,
                    Message = "Failed to add Prod"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<ProductResponse>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }


        public async Task<ApiResponse<ProductResponse>> UpdateProductAsync( MultipartFormDataContent content)
        {
            try
            {
                // Build the URL for the update operation (e.g., "api/products/{id}")
                var response = await _httpClient.PostAsync(ApiEndpoints.Product.UpdateProducts, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<ProductResponse>>();
                    return result; // Return the updated product details
                }

                return new ApiResponse<ProductResponse>
                {
                    IsSuccess = false,
                    Message = "Failed to update product"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<ProductResponse>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }



    }

}
