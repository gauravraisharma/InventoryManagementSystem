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
    public class GetProductByIdQuery : IRequest<GenericBaseResult<GetProductRequestDto>>
    {
        public string ProductId { get; set; }

        public GetProductByIdQuery(string productId)
        {
            ProductId = productId;
        }
    }
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GenericBaseResult<GetProductRequestDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<GenericBaseResult<GetProductRequestDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.ProductId);
            if (product == null)
            {
                
                var result = new GenericBaseResult<GetProductRequestDto>(null);
                return result;
            }
            return product;
        }
    }
}
