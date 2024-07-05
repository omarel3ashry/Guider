using Guider.Application.UseCases.Categories.Query.GetById;
using Guider.Application.UseCases.SubCategories.Query.getSubCategoryList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubCategories()
        {
            var query = new getSubCategoryListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getbyId")]
        public async Task<IActionResult> getAllSubCategoriesByCategoryId(int categoryId)
        {
            var query = new GetCategoryByIdQuery() { Id = categoryId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
