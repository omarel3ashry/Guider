using Guider.Application.UseCases.Consultants.Command.DeleteConsultant;
using Guider.Application.UseCases.Consultants.Command.UpdateBankAccount;
using Guider.Application.UseCases.Consultants.Command.UpdateConsultant;
using Guider.Application.UseCases.Consultants.Command.UpdateImage;
using Guider.Application.UseCases.Consultants.Query.GetDetails;
using Guider.Application.UseCases.Consultants.Query.GetFiltered;
using Guider.Application.UseCases.Consultants.Query.GetFilteredByName;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConsultantController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _path = @"wwwroot\Images\";
        public ConsultantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}", Name = "GetconsultantById")]
        public async Task<ActionResult> GetConsultantById(int id)
        {
            var consultant = await _mediator.Send(new GetConsultantDetailsQuery { Id = id });
            return Ok(consultant);

        }

        [HttpPatch("edit/{id}")]
        public async Task<ActionResult<ConsultantUpdateDto>> UpdateConsultant(int id, UpdateConsultantCommand command)
        {
            if (id != command.id)
            {
                return BadRequest("Consultant ID mismatch.");
            }
            command.id = id;
            var consultantDto = await _mediator.Send(command);
            return Ok(consultantDto);
        }

        [HttpDelete("{id:int}")]
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

        [HttpGet("filter")]
        public async Task<IActionResult> FilterConsultants(int categoryId, int subCategoryId,
                                                           bool sortByPrice = true, bool sortAsc = true,
                                                           int page = 1, int pageSize = 10)
        {
            var query = new GetFilteredQuery()
            {
                CategoryId = categoryId,
                SubCategoryId = subCategoryId,
                SortByPrice = sortByPrice,
                SortAsc = sortAsc,
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> FilterConsultantsByName(string name, int page = 1, int pageSize = 10)
        {
            var query = new GetByNameQuery()
            {
                Name = name,
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("UploadProfileImage")]
        public async Task<IActionResult> UploadProfileImage(int Id, IFormFile formFile)
        {
            var command = new UpdateConsultantImageCommand() { Id = Id, Image = formFile };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}

