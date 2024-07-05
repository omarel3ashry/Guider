using Guider.Application.UseCases.Consultants.Command.DeleteConsultant;
using Guider.Application.UseCases.Consultants.Command.UpdateBankAccount;
using Guider.Application.UseCases.Consultants.Command.UpdateConsultant;
using Guider.Application.UseCases.Consultants.Command.UpdateImage;
using Guider.Application.UseCases.Consultants.Query.ConsultantPagination;
using Guider.Application.UseCases.Consultants.Query.ConsultantSearch;
using Guider.Application.UseCases.Consultants.Query.GetAll;
using Guider.Application.UseCases.Consultants.Query.GetConsultantBySubCategoryId;
using Guider.Application.UseCases.Consultants.Query.GetConsultantsByCategoryId;
using Guider.Application.UseCases.Consultants.Query.GetConsultantsCountByCategory;
using Guider.Application.UseCases.Consultants.Query.GetDetails;
using Guider.Application.UseCases.Consultants.Query.GetFiltered;
using Guider.Application.UseCases.Consultants.Query.GetFilteredByName;
using Guider.Application.UseCases.Consultants.Query.TopConsultants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _path = @"wwwroot\Images\";
        public ConsultantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetConsultants()
        {
            var result = await _mediator.Send(new GetConsultantListQuery());
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<PaginatedConsultantDto>> SearchConsultants([FromQuery] string searchQuery, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var query = new ConsultantSearchQuery(searchQuery, page, pageSize);
            var result = await _mediator.Send(query);
            return Ok(result);
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
        [HttpGet("getConsultantsByCategoryId")]
        public async Task<IActionResult> getConsultantsByCategoryId(int categoryId, int page, int pageSize)
        {
            var query = new getConsultantsByCategoryIdQuery()
            {
                categoryId = categoryId,
                Page = page,
                PageSize = pageSize
            };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("getConsultantsBySubCategoryId")]
        public async Task<IActionResult> getConsultantsBySubCategoryId(int subCategoryId, int page, int pageSize)
        {
            var query = new GetConsultantBySubCategoryIdQuery()
            {
                SubCategoryId = subCategoryId,
                Page = page,
                PageSize = pageSize
            };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterConsultants(int categoryId, int subCategoryId, bool sortByPrice = true, bool sortAsc = true, int page = 1, int pageSize = 10)
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

        [HttpGet("consultants-count")]
        public async Task<ActionResult> GetConsultantsCountByCategory()
        {
            var result = await _mediator.Send(new GetConsultantsCountByCategoryQuery());
            return Ok(result);
        }

        [HttpGet("top")]
        public async Task<ActionResult<List<ConsultantDto>>> GetTopConsultants()
        {
            var topConsultants = await _mediator.Send(new GetTopConsultantsQuery());
            return Ok(topConsultants);
        }


        [HttpPut("UploadProfileImage")]
        public async Task<IActionResult> UploadProfileImage(int Id, IFormFile formFile)
        {
            UpdateConsultantImageCommand command = new UpdateConsultantImageCommand() { Id = Id};
            string fileExe = formFile.FileName.Split('.').Last();
            string imagePath = $"consultant\\{command.Id}_img.{fileExe}";
            string fullPath = _path + imagePath;
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            using (FileStream stream = System.IO.File.Create(fullPath))
            {
                await formFile.CopyToAsync(stream);
            }
            Console.WriteLine("successful upload ! " + imagePath);
            command.Image = imagePath;
            var response = await _mediator.Send(command);
            return Ok(imagePath);
        }
    }
}

