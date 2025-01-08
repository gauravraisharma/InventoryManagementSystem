using IMS.Core.Common.Helper;
using IMS.Core.RequestDto.Product;
using IMS.Infrastructure.Interface.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Features.Products.Queries
{
    public class GetAllProductsQuery : IRequest<GenericBaseResult<List<GetProductRequestDto>>>
    {
        public string? Department { get; set; }
        public string? Category { get; set; }
        public string? SearchText { get; set; }
        public string? SortBy { get; set; }
        public int? currentPage { get; set; }
        public int? pageSize { get; set; }
    }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, GenericBaseResult<List<GetProductRequestDto>>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //public async Task<GenericBaseResult<List<GetProductRequestDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        //{
        //    var products = await _productRepository.GetAllProductsAsync();
        //    return products;
        //}
        public async Task<GenericBaseResult<List<GetProductRequestDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProductsAsync(
                request.Department,
                request.Category,
                request.SearchText,
                request.SortBy,
                request.currentPage,
                request.pageSize);

            return products;
        }
    }

}
