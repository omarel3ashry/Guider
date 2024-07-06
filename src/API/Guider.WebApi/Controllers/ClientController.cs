using Guider.Application.UseCases.Clients.Command.DeleteClient;
using Guider.Application.UseCases.Clients.Command.UpdateBankAccount;
using Guider.Application.UseCases.Clients.Command.UpdateClient;
using Guider.Application.UseCases.Clients.Command.UpdateImage;
using Guider.Application.UseCases.Clients.Query.GetAllClients;
using Guider.Application.UseCases.Clients.Query.GetClientDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _path = @"wwwroot\Images\";

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("allClient", Name = "GetAllClients")]
        public async Task<ActionResult<List<ClienttoReturnVM>>> GetAllClients()
        {
            var clients = await _mediator.Send(new GetAllClientsQuery());
            return Ok(clients);
        }

        [HttpGet("{id}", Name = "GetClientById")]
        public async Task<ActionResult<ClienttoReturnVM>> GetClientById(int id)
        {
            var client = await _mediator.Send(new GetClientDetailsQuery { Id = id });
            return Ok(client);

        }

        [HttpPatch("edit/{id}")]
        public async Task<ActionResult<UpdateClientDto>> UpdateClient(int id, UpdateClientCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Client ID mismatch.");
            }
            command.Id = id;
            var clientDto = await _mediator.Send(command);
            return Ok(clientDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {

            var deletedClient = await _mediator.Send(new DeleteClientCommand { ClientId = id });
            return Ok(deletedClient);

        }

        [HttpPost("client-img")]
        public async Task<IActionResult> UpdateClientImage(UpdateClientImageCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("client-bAccount")]
        public async Task<IActionResult> UpdateClientBankAccount(UpdateClientBankAccountCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("UploadProfileImage")]
        public async Task<IActionResult> UploadProfileImage(int Id, IFormFile formFile)
        {
            UpdateClientImageCommand command = new UpdateClientImageCommand() { Id = Id, Image = formFile };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
