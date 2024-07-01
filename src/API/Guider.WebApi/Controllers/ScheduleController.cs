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
            try
            {
                var success = await _mediator.Send(command);
                if (success)
                {
                    return Ok();
                }
                return StatusCode(500, "Failed to add schedules");
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpGet("{consultantId}")]
        public async Task<IActionResult> GetSchedulesForConsultant(int consultantId)
        {
            try
            {
                var query = new GetSchedulesForConsultantQuery(consultantId);
                var schedules = await _mediator.Send(query);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpPut("{consultantId}/{date}")]
        public async Task<IActionResult> UpdateSchedule(int consultantId, DateTime date, [FromBody] UpdateScheduleCommand command)
        {
            try
            {
                command.ConsultantId = consultantId;
                command.Date = date;
                var success = await _mediator.Send(command);
                if (success)
                {
                    return Ok();
                }
                return StatusCode(500, "Failed to update schedule");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{consultantId}/{date}")]
        public async Task<IActionResult> DeleteSchedule(int consultantId, DateTime date)
        {
            try
            {
                var command = new DeleteScheduleCommand { ConsultantId = consultantId, Date = date };
                var success = await _mediator.Send(command);

                if (success)
                    return Ok();

                return NotFound(); // Handle not found scenario if necessary
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}