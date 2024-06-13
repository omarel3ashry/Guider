using Guider.Application.Responses;
using Guider.Application.UseCases.client.Command.CreateClient;

using Guider.Application.UseCases.consultant.Command.DeleteConsultant;
using Guider.Application.UseCases.consultant.Command.UpdateBankAccount;
using Guider.Application.UseCases.consultant.Command.UpdateConsultant;
using Guider.Application.UseCases.consultant.Command.UpdateImage;
using Guider.Application.UseCases.consultant.Query.GetAll;
using Guider.Application.UseCases.consultant.Query.GetDetails;
using Guider.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public async Task<ActionResult<List<ConsultantVM>>> GetAllConsultants()
        {
            var consultants = await _mediator.Send(new GetConsultantListQuery());
            return Ok(consultants);
        }
        [HttpGet("{id}", Name = "GetconsultantById")]
        public async Task<ActionResult> GetConsultantById(int id)
        {
            var consultant = await _mediator.Send(new GetConsultantDetailsQuery { Id = id });
           

            return Ok(consultant);

        }
        

        [HttpPatch("{id}")]
        public async Task<ActionResult<ConsultantUpdateDto>> UpdateConsultant(int id, UpdateConsultantCommand command)
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
        public async Task<IActionResult> DeleteConsultant([FromRoute] DeleteConsultantCommand command)
        {
            
                var deletedConsultantId = await _mediator.Send(command );
                return Ok(deletedConsultantId);
            
        }
        [HttpPost("update-image")]
        public async Task<IActionResult> UpdateImage([FromBody] UpdateImageCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update-bank-account")]
        public async Task<IActionResult> UpdateBankAccount([FromBody] UpdateBankAccountCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
