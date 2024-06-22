using Guider.Application.UseCases.Appointments.Command.updateAppointment;
using Guider.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppointmentState( [FromBody] updateAppointmentStateCommand request)
        {
            
             await _mediator.Send(request);
            return NoContent();
        }
    }

}

