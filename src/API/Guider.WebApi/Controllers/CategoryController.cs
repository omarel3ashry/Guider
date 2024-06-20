using Guider.Application.UseCases.Categories.CategorySearch.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorySearchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategorySearchController(IMediator mediator)
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
    }
}
