using IMS.Application.Features.Products.Commands;
using IMS.Application.Features.Products.Queries;
using IMS.Core.RequestDto.Product;
using IMS.Core.RequestDto.ProductDTOs;
using IMS.WebAPI.Model;
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
        //[HttpGet]
        //public IActionResult GetProducts()
        //{
        //    var products = new List<string>
        //{
        //    "Product 1",
        //    "Product 2",
        //    "Product 3"
        //};
        //    return Ok(products);
        //}

        //[HttpGet]
        //public IActionResult GetProducts()
        //{
        //    var products = new List<Product>
        //{
        //    new Product { Name = "Product 1" },
        //    new Product { Name = "Product 2" },
        //    new Product { Name = "Product 3" }
        //};
        //    return Ok(products);
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
        }



        [HttpGet("{id}")]
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
      
    }
}
