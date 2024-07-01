using Guider.Application.UseCases.Appointments.Query.AppointmentSort;
using Guider.Application.UseCases.SubCategories.Query.sortbyAvgRate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortRateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SortRateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("sortRate")]
        public async Task<IActionResult> SortRate([FromQuery] bool ascending, int page = 1, int pagesize = 5)
        {
            var query = new SortAppointmentByRateQuery(ascending, page, pagesize);
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("sortRateBySubCategory")]
        public async Task<IActionResult> sortRateBySubCategory([FromQuery] bool ascending, int page = 1, int pagesize = 5, [FromQuery] int subcategoryId = 0)
        {
            var query = new sortByAvgRateQuery(ascending, page, pagesize, subcategoryId);
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
