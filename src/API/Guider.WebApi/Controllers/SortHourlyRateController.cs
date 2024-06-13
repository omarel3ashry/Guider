using Guider.Application.UseCases.Consultants.ConsultantSortt.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<List<SortByHourlyRateDto>>> SortHourlyRate([FromQuery] bool ascending)
        {
            var query = new SortByHourlyRateQuery(ascending);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
