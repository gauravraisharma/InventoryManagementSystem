using Azure.Core;
using IMS.Core.Common.Helper;
using IMS.Core.Entities;
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
    public class AddEditProductCommand : IRequest<GenericBaseResult<AddProductRequestDto>>
    {
        //public string Id { get; set; }
        public AddProductRequestDto AddProductRequestDto { get; set; }
    }

    public class AddEditProductCommandHandler : IRequestHandler<AddEditProductCommand, GenericBaseResult<AddProductRequestDto>>
    {
        private readonly IProductRepository _productRepository;
            
        public AddEditProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<GenericBaseResult<AddProductRequestDto>> Handle(AddEditProductCommand request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.AddProductRequestDto.Id))
            {
             
                return await _productRepository.UpdateAsync(request.AddProductRequestDto);
            }
            else
            {
                return await _productRepository.AddAsync(request.AddProductRequestDto);

            }
           
        }
    }
}
