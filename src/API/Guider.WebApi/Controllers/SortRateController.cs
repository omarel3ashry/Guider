using Guider.Application.UseCases.Appointments.AppointmentSort.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<List<SortAppointementByRateDto>>> SortRate([FromQuery]bool ascending)
        {
            var query = new SortAppointmentByRateQuery(ascending);
            return await _mediator.Send(query);
        }
    }
}
