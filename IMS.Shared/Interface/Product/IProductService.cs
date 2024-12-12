using IMS.Shared.Common;
using IMS.Shared.RequestDto.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Shared.Interface.Product
{
    public interface IProductService
    {
        Task<ApiResponse<GetAllProductDto>> GetProductByIdAsync(string Id);
      
        Task<ApiResponse<List<GetAllProductDto>>> GetAllProductsAsync(string department,string category,string searchText,string sortBy);
        Task<ApiResponse<ProductResponse>> AddProductAsync(MultipartFormDataContent addProductDto);
    
        Task<ApiResponse<ProductResponse>> UpdateProductAsync( MultipartFormDataContent content);
        Task<ApiResponse<DeleteProductDto>> DeleteProductByIdAsync(string Id);
    }
}
    