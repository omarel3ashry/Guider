using Guider.Application.UseCases.client.Command.DeleteClient;
using Guider.Application.UseCases.client.Command.UpdateBankAccount;
using Guider.Application.UseCases.client.Command.UpdateClient;
using Guider.Application.UseCases.client.Command.UpdateImage;
using Guider.Application.UseCases.client.Query.GetAllClients;
using Guider.Application.UseCases.client.Query.GetClientDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

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
    }
}
