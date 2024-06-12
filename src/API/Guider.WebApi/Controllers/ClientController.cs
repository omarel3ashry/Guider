
using Guider.Application.UseCases.client.Command.CreateClient;
using Guider.Application.UseCases.client.Command.DeleteClient;
using Guider.Application.UseCases.client.Query.GetAllClients;
using Guider.Application.UseCases.client.Query.GetClientDetails;
using Guider.Application.UseCases.consultant.Command.DeleteConsultant;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        [HttpPost]
        public async Task<IActionResult> CreateUser(ClientCreateCommand command)
        {
            var clientDto = await _mediator.Send(command);
            return StatusCode(201, clientDto);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteClient(int id)
        {

            var deletedClient = await _mediator.Send(new DeleteClientCommand { ClientId = id });
            return Ok(deletedClient);

        }
    }
}
