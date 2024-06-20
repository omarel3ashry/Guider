using Guider.Application.UseCases.Users.Command.ClientRegister;
using Guider.Application.UseCases.Users.Command.ConsultantRegister;
using Guider.Application.UseCases.Users.Command.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login", Name ="UserLogin")]
        public async Task<IActionResult> Login(LoginCommand loginCommand)
        {
            var response = await _mediator.Send(loginCommand);
            return Ok(response);
        }

        [HttpPost("Register/client")]
        public async Task<IActionResult> ClientRegister(ClientRegisterCommand clientRegisterCommand)
        {
            var response = await _mediator.Send(clientRegisterCommand);
            return Ok(response);
        }

        [HttpPost("Register/consultant")]
        public async Task<IActionResult> ConsultantRegister(ConsultantRegisterCommand consultantRegisterCommand)
        {
            var response = await _mediator.Send(consultantRegisterCommand);
            return Ok(response);
        }
    }
}
