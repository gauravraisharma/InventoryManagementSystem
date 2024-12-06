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
        Task<ApiResponse<List<GetAllProductDto>>> GetAllProductsAsync();
        Task<ApiResponse<ProductResponse>> AddProductAsync(MultipartFormDataContent addProductDto);
        Task<ApiResponse<ProductResponse>> UpdateProductAsync(AddProductDto addProductDto);
    }
}
    