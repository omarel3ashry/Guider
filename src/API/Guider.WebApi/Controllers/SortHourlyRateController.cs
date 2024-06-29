using Guider.Application.UseCases.Consultants.Query.ConsultantPagination;
using Guider.Application.UseCases.Consultants.Query.ConsultantSort;
using Guider.Application.UseCases.SubCategories.Query.sortbyhourlyRate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortHourlyRateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SortHourlyRateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("sortHourlyRate")]
        public async Task<ActionResult<PaginatedConsultantDto>> SortHourlyRate([FromQuery] bool ascending, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var query = new SortByHourlyRateQuery(ascending, page, pageSize);
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpGet("sortHourlyRateBySubCategory")]
        public async Task<ActionResult<PaginatedConsultantDto>> sortHourlyRateBySubCategory([FromQuery] bool ascending, [FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] int subcategoryId = 0)
        {
            var query = new sortByHourlyRateQuery(ascending, page, pageSize, subcategoryId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
