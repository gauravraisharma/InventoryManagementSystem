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
    }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, GenericBaseResult<List<GetProductRequestDto>>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GenericBaseResult<List<GetProductRequestDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProductsAsync();
            return products;
        }
    }

}
