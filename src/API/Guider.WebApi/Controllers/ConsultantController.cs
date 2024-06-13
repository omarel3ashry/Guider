using Guider.Application.UseCases.Consultants.ConsultantPagination.Query;
using Guider.Application.UseCases.Consultants.ConsultantsAll.Query;
using Guider.Application.UseCases.Consultants.ConsultantSearch;
using Guider.Application.UseCases.Consultants.ConsultantSearch.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsultantController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<ConsultantDto>>> GetConsultants()
        {
            var result = await _mediator.Send(new GetAllConsultantsQuery());
            return Ok(result);
        }
        [HttpGet("consultant")]
        public async Task<IActionResult> SearchConsultantsByName([FromQuery] string consultantName)
        {
            if (string.IsNullOrEmpty(consultantName))
            {
                return BadRequest("Consultant name cannot be empty.");
            }

            var consultants = await _mediator.Send(new ConsultantSearchQuery(consultantName));

            if (consultants.Count == 0)
            {
                return NotFound($"No consultants found matching the search query: {consultantName}");
            }

            return Ok(consultants);
        }
        [HttpGet("api/pagination")]
        public async Task<IActionResult> GetConsultants([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            var query = new GetPaginatedConsultantsQuery(page, pageSize);
            var result = await _mediator.Send(query);

            if (result == null || result.Count == 0)
            {
                return NotFound("No consultants found for the specified page and page size.");
            }

            return Ok(result);
        }
    }
}
   
