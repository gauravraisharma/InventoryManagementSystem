using IMS.Application.Features.Department.Queries;
using IMS.Application.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetallDepartments()
        {
            var query = new GetAllDepartmentsQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
        }
    }
}
