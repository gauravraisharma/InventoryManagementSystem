using IMS.Application.Features.Products.Queries;
using IMS.Core.Common.Helper;
using IMS.Core.RequestDto.Product;
using IMS.Core.RequestDto.ProductDTOs;
using IMS.Infrastructure.Interface.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Features.Products.Commands
{
    public class DeleteProductByIdCommand : IRequest<GenericBaseResult<DeleteProductDto>>
    {
        public string ProductId { get; set; }
        public DeleteProductByIdCommand(string productId)
        {
            ProductId = productId;
        }

    }
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, GenericBaseResult<DeleteProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductByIdCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<GenericBaseResult<DeleteProductDto>> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.DeleteProductByIdAsync(request.ProductId);
            if (product == null)
            {

                var result = new GenericBaseResult<DeleteProductDto>(null);
                return result;
            }
            return product;
        }
    }
}
