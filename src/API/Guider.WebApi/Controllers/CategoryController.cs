using Guider.Application.UseCases.Categories.Query.GetListOfCategories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var query = new getCategoryListQuery();
            var result = await _mediator.Send(query);
            if (result == null || result.Count == 0)
            {
                return NotFound("No category found .");
            }
            return Ok(result);
        }
    }
}
