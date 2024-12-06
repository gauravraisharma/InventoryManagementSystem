using IMS.Shared.Common;
using IMS.Shared.Constants;
using IMS.Shared.Interface.Product;
using IMS.Shared.RequestDto;
using IMS.Shared.RequestDto.ProductDTOs;
using IMS.WebApp.Client.Services.Base;
using System.Net.Http.Json;
using static IMS.Shared.Constants.ApiEndpoints;

namespace IMS.WebApp.Client.Services.Product
{
    public class ProductService : IProductService
    {
        //public ProductService(HttpClient httpClient) : base(httpClient) { }


        //public async Task<List<GetAllProductDto>> GetAllProductsAsync()
        //{
        //    var response = await GetAsync<List<GetAllProductDto>>(Products.Get);
        //    return response?.Result ?? new List<GetAllProductDto>();
        //}

        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<List<GetAllProductDto>>> GetAllProductsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(ApiEndpoints.Products.Get);
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

        //public async Task<ApiResponse<ProductResponse>> AddProductAsync(AddProductDto formData)
        //{
        //    try
        //    {
        //        var response = await _httpClient.PostAsJsonAsync(ApiEndpoints.Product.SaveProducts, formData);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var rawResponseContent = await response.Content.ReadAsStringAsync();
        //            Console.WriteLine("Raw response content: " + rawResponseContent);
        //            var result = await response.Content.ReadFromJsonAsync<ApiResponse<ProductResponse>>();
        //            return result;
        //        }
        //        return new ApiResponse<ProductResponse>
        //        {
        //            IsSuccess = false,
        //            Message = "Failed to add Prod"
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ApiResponse<ProductResponse>
        //        {
        //            IsSuccess = false,
        //            Message = ex.Message
        //        };
        //    }
        //}
        public async Task<ApiResponse<ProductResponse>> UpdateProductAsync(AddProductDto addProductDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(ApiEndpoints.Product.UpdateProducts, addProductDto);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<ProductResponse>>();
                    return result;
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
