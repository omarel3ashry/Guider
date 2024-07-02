using Guider.Application.UseCases.Appointments.Command.AddAppointment;
using Guider.Application.UseCases.Appointments.Command.CancelAppointment;
using Guider.Application.UseCases.Appointments.Command.RateAppointment;
using Guider.Application.UseCases.Appointments.Query.GetAllForConsultant;
using Guider.Application.UseCases.Appointments.Query.GetAppointmentsStatsForUser;
using Guider.Application.UseCases.Appointments.Query.GetById;
using Guider.Domain.Entities;
using Guider.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
        [HttpGet("Stats")]
        public async Task<ActionResult<AppointmentDto>> GetAppointmentsStats()
        {
            var id = HttpContext.User.Claims.FirstOrDefault(e => e.Type == "id");
            var role = HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.Role);
            Enum.TryParse(role!.Value, out UserRole parsedRole);
            object? result;
            if (parsedRole == UserRole.Client)
                result = await _mediator.Send(new GetAppointmentsStatsForUserQuery<Client> { Id = int.Parse(id!.Value) });
            else
                result = await _mediator.Send(new GetAppointmentsStatsForUserQuery<Consultant> { Id = int.Parse(id!.Value) });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<AppointmentDto>> GetUserAppointments(int state, int page = 1, int pageSize = 5)
        {
            var id = HttpContext.User.Claims.FirstOrDefault(e => e.Type == "id");
            var role = HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.Role);
            Enum.TryParse(role!.Value, out UserRole parsedRole);
            object? result;
            if (parsedRole == UserRole.Client)
                result = await _mediator.Send(new GetAllAppointmentsForUserQuery<Client> { Id = int.Parse(id!.Value), PageSize = pageSize, Page = page, State = state });
            else
                result = await _mediator.Send(new GetAllAppointmentsForUserQuery<Consultant> { Id = int.Parse(id!.Value), PageSize = pageSize, Page = page, State = state });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentDto>> AddAppointment(AddAppointmentCommand AddAppointmentCommand)
        {
            var result = await _mediator.Send(AddAppointmentCommand);
            return Ok(result);
        }

        [HttpPost("cancel")]
        public async Task<ActionResult<AppointmentDto>> CancelAppointment(CancelAppointmentCommand command)
        {
            command.ClientUserId = int.Parse(User.Claims.FirstOrDefault(e => e.Type == JwtRegisteredClaimNames.Sid)?.Value ?? "0");
            //var cancelAppointCommand = new CancelAppointmentCommand()
            //{
            //    AppointmentId = appointmentId,
            //    ClientUserId = int.Parse(User.Claims.FirstOrDefault(e => e.Type == JwtRegisteredClaimNames.Sid)?.Value ?? "0")
            //};

            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPatch("rate")]
        public async Task<ActionResult<AppointmentDto>> RateAppointment(RateAppointmentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}