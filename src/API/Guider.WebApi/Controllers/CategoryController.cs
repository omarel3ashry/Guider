using Guider.Application.UseCases.Categories.CategorySearch.Query;
using Guider.Application.UseCases.Categories.Query.GetListOfCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
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

        [HttpGet("search")]
        public async Task<IActionResult> SearchCategory([FromQuery] int categoryId, [FromQuery] string consultantName = null)
        {
            var query = new CategorySearchQuery(categoryId, consultantName);
            var result = await _mediator.Send(query);
            if (result == null || result.Count == 0)
            {
                return NotFound("No category found matching the search query.");
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var query = new getCategoryListQuery();
            var result=await _mediator.Send(query);
            if (result == null || result.Count == 0)
            {
                return NotFound("No category found .");
            }
            return Ok(result);
        }
    }
}
