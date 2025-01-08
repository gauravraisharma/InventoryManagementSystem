using IMS.Application.Features.Products.Commands;
using IMS.Application.Features.Products.Queries;
using IMS.Core.RequestDto.Product;
using IMS.Core.RequestDto.ProductDTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts(string? department = null, string? category = null, string? searchText = null, string? sortBy = null, int? currentPage=1, int? pageSize=20)
        {
            var query = new GetAllProductsQuery
            {
                Department = department,
                Category = category,
                SearchText = searchText,
                SortBy = sortBy,
                currentPage = currentPage,
                pageSize = pageSize
            };

            var products = await _mediator.Send(query);
            return Ok(products);
        }



        [HttpGet]
        [Route("GetProductById")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var query = new GetProductByIdQuery(id);
            var product = await _mediator.Send(query);

            return Ok(product);
        }


        [HttpPost("add-edit")]
        public async Task<IActionResult> AddEditProduct([FromForm] AddProductRequestDto addProductRequestDto)
        {
            var command = new AddEditProductCommand { AddProductRequestDto = addProductRequestDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteProductById")]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            var command = new DeleteProductByIdCommand(id);
            var product = await _mediator.Send(command);

            return Ok(product);


        }

    }
}
