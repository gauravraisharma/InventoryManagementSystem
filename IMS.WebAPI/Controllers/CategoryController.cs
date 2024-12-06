using IMS.Application.Features.Category.Queries;
using IMS.Application.Features.Department.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetallCategories()
        {
            var query = new GetAllCategoriesQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
        }
    }
}
