using Guider.Application.Responses;
using Guider.Application.UseCases.client.Command.CreateClient;
using Guider.Application.UseCases.consultant.Command.CreateConsultant;
using Guider.Application.UseCases.consultant.Command.DeleteConsultant;
using Guider.Application.UseCases.consultant.Command.UpdateConsultant;
using Guider.Application.UseCases.consultant.Query.GetAll;
using Guider.Application.UseCases.consultant.Query.GetDetails;
using Guider.Domain.Entities;
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
        [HttpGet("all", Name = "GetAllConsultants")]
        public async Task<ActionResult<List<ConsultantListVM>>> GetAllConsultants()
        {
            var consultants = await _mediator.Send(new GetConsultantListQuery());
            return Ok(consultants);
        }
        [HttpGet("{id}", Name = "GetconsultantById")]
        public async Task<ActionResult<ConsultantDetailsVM>> GetbussnissById(int id)
        {
            var bussnissresult = await _mediator.Send(new GetConsultantDetailsQuery { Id = id });
            return Ok(bussnissresult);

        }
        [HttpPost]
        public async Task<IActionResult> CreateConsultant(CreateConsultantCommand command)
        {
            var consultantDto = await _mediator.Send(command);
            return StatusCode(201, consultantDto);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ConsultantCreateOrUpdateDto>> UpdateConsultant(int id, UpdateConsultantCommand command)
        {
            if (id != command.ConsultantId)
            {
                return BadRequest("Consultant ID mismatch.");
            }
            command.ConsultantId = id;
            var consultantDto = await _mediator.Send(command);
            return Ok(consultantDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultant(int id)
        {
            
                var deletedConsultantId = await _mediator.Send(new DeleteConsultantCommand { ConsultantId = id });
                return Ok(deletedConsultantId);
            
        }
    }
}
