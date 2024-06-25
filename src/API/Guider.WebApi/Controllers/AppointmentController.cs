using Guider.Application.UseCases.Appointments.Command.AddAppointment;
using Guider.Application.UseCases.Appointments.Command.CancelAppointment;
using Guider.Application.UseCases.Appointments.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

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
        public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
        {
            var GetAppointmentQuery = new GetAppointmentQuery() { Id = id };
            var result = await _mediator.Send(GetAppointmentQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentDto>> AddAppointment(AddAppointmentCommand AddAppointmentCommand)
        {
            var result = await _mediator.Send(AddAppointmentCommand);
            return Ok(result);
        }

        [HttpPatch("cancel")]
        public async Task<ActionResult<AppointmentDto>> CancelAppointment(int appointmentId)
        {
            var cancelAppointCommand = new CancelAppointmentCommand()
            {
                AppointmentId = appointmentId,
                ClientUserId = int.Parse(User.Claims.FirstOrDefault(e => e.Type == JwtRegisteredClaimNames.Sid)?.Value ?? "0")
            };

            var result = await _mediator.Send(cancelAppointCommand);
            return Ok(result);
        }

    }
}