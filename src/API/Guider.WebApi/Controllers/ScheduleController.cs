using Guider.Application.UseCases.Schedules.Command.CreateSchedule;
using Guider.Application.UseCases.Schedules.Command.DeleteSchedule;
using Guider.Application.UseCases.Schedules.Command.UpdateSchedule;
using Guider.Application.UseCases.Schedules.Query.GetAllSchdeulesForConsultant;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ScheduleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddSchedules(CreateScheduleCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{consultantId}")]
        public async Task<IActionResult> GetSchedulesForConsultant(int consultantId)
        {
            var query = new GetSchedulesForConsultantQuery(consultantId);
            var schedules = await _mediator.Send(query);
            return Ok(schedules);
        }

        [HttpPut("{consultantId}/{date}")]
        public async Task<IActionResult> UpdateSchedule(int consultantId, DateTime date, [FromBody] UpdateScheduleCommand command)
        {
            command.ConsultantId = consultantId;
            command.Date = date;
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{consultantId}/{date}")]
        public async Task<IActionResult> DeleteSchedule(int consultantId, DateTime date)
        {
            var command = new DeleteScheduleCommand { ConsultantId = consultantId, Date = date };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}