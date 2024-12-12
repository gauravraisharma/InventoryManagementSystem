using IMS.Core.Common.Helper;
using IMS.Core.RequestDto.Product;
using IMS.Core.RequestDto.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Interface.Products
{
    public interface IProductRepository
    {
       
        Task<GenericBaseResult<List<GetProductRequestDto>>> GetAllProductsAsync(
       string? department = null,
       string? category = null,
       string? searchText = null,
       string? sortBy = null);
        Task<GenericBaseResult<GetProductRequestDto>> GetProductByIdAsync(string productId);
        Task<GenericBaseResult<DeleteProductDto>> DeleteProductByIdAsync(string productId);
        Task<GenericBaseResult<AddProductRequestDto>> AddAsync(AddProductRequestDto product);
       Task<GenericBaseResult<AddProductRequestDto>> UpdateAsync(AddProductRequestDto product);
        
    }
}
