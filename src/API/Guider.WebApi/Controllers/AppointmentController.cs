using Guider.Application.UseCases.Appointments.Command.CancelAppointment;
using Guider.Application.UseCases.Appointments.Command.InsertAppointment;
using Guider.Application.UseCases.Appointments.Query;
using Guider.Application.UseCases.Appointments.Query.GetById;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentToReturnDto>> GetAppointment(int id)
        {
            var GetAppointmentQuery = new GetAppointmentQuery() { Id = id };
            var result = await _mediator.Send(GetAppointmentQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentToReturnDto>> addAppointment(AddAppointmentCommand AddAppointmentCommand)
        {
            var result = await _mediator.Send(AddAppointmentCommand);
            return Ok(result);
        }

        [HttpPost("cancel")]
        public async Task<ActionResult<AppointmentToReturnDto>> CancelAppointment(int appointmentId)
        {
            var cancelAppointCommand = new CancelAppointmentCommand()
            {
                AppointmentId = appointmentId,
                ClientUserId = int.Parse(User.Claims.FirstOrDefault(e => e.Type == "sid")?.Value ?? "0"),
                ClientId = int.Parse(User.Claims.FirstOrDefault(e => e.Type == "clientId")?.Value ?? "0")
            };
            var result = await _mediator.Send(cancelAppointCommand);
            return Ok(result);
        }

    }
}