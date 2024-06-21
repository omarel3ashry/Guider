using Guider.Application.UseCases.Categories.Query.GetListOfCategories;
using Guider.Application.UseCases.SubCategories.Query;
using Guider.Application.UseCases.SubCategories.Query.getSubCategoryByCategoryId;
using Guider.Application.UseCases.SubCategories.Query.getSubCategoryList;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        [HttpGet("consultants-by-subcategory")]
        public async Task<IActionResult> GetConsultantsBySubCategory([FromQuery] int subCategoryId, [FromQuery] string consultantName = null)
        {
            var query = new SearchConsultantsBySubCategoryQuery
            {
                SubCategoryId = subCategoryId,
                ConsultantName = consultantName
            };

            var result = await _mediator.Send(query);

            if (result == null || result.Count == 0)
            {
                return NotFound(new { Message = "No consultants found matching the search query." });
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubCategories()
        {
            var query = new getSubCategoryListQuery();
            var result = await _mediator.Send(query);
            if (result == null || result.Count == 0)
            {
                return NotFound("No SubCategory found .");
            }
            return Ok(result);
        }
        [HttpGet ("getbyId")]
        public async Task<IActionResult> getAllSubCategoriesByCategoryId(int categoryId)
        {
            var query = new getSubCategoryByCategoryIdQuery()
            {
                categoryId=categoryId
            };
            var result=await _mediator.Send(query);
            if (result == null || result.Count == 0)
            {
                return NotFound("No SubCategory found .");
            }
            return Ok(result);
        }
    }
}
