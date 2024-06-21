using Guider.Application.UseCases.Consultants.Query.GetAll;
using Guider.Application.UseCases.Consultants.Query.GetDetails;
using Guider.Application.UseCases.Consultants.Command.DeleteConsultant;
using Guider.Application.UseCases.Consultants.Command.UpdateBankAccount;
using Guider.Application.UseCases.Consultants.Command.UpdateConsultant;
using Guider.Application.UseCases.Consultants.Command.UpdateImage;
using Guider.Application.UseCases.Consultants.Query.ConsultantPagination;
using Guider.Application.UseCases.Consultants.Query.ConsultantSearch.Query;
using Guider.Application.UseCases.Consultants.Query.ConsultantPagination.Query;
using MediatR;
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

        [HttpGet]
        public async Task<ActionResult<List<ConsultantDto>>> GetConsultants()
        {
            var result = await _mediator.Send(new GetConsultantListQuery());
            return Ok(result);
        }

        [HttpGet("consultant")]
        public async Task<IActionResult> SearchConsultantsByName([FromQuery] string consultantName)
        {
            if (string.IsNullOrEmpty(consultantName))
            {
                return BadRequest("Consultant name cannot be empty.");
            }

            var consultants = await _mediator.Send(new ConsultantSearchQuery(consultantName));

            if (consultants.Count == 0)
            {
                return NotFound($"No consultants found matching the search query: {consultantName}");
            }

            return Ok(consultants);
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetConsultants([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            var query = new GetPaginatedConsultantsQuery(page, pageSize);
            var result = await _mediator.Send(query);

            if (result.Consultants == null || result.Consultants.Count == 0)
            {
                return NotFound("No consultants found for the specified page and page size.");
            }

            return Ok(result);
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


        [HttpPatch("edit/{id}")]
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
            var deletedConsultantId = await _mediator.Send(command);
            return Ok(deletedConsultantId);
        }

        [HttpPost("cons-img")]
        public async Task<IActionResult> UpdateConsultantImage(UpdateConsultantImageCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("cons-bAccount")]
        public async Task<IActionResult> UpdateConsultantBankAccount(UpdateConsultantBankAccountCommand command)
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

