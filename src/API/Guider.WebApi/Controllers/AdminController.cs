using Guider.Application.UseCases.Admin.Command.VerifyConsultant;
using Guider.Application.UseCases.Admin.Query.GetUnVerifiedConsultantDetailes;
using Guider.Application.UseCases.Admin.Query.GetUnVerifiedConsultants;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Guider.Application.Contracts.Infrastructure;
using Guider.Domain.Entities;
using Guider.Domain.Enums;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMailFactory _mailFactory;
        private readonly IMailService _mailService;

        public AdminController(IMediator mediator, IMailFactory mailFactory, IMailService mailService)
        {
            _mediator = mediator;
            _mailFactory = mailFactory;
            _mailService = mailService;
        }

        [HttpGet("UnVerifiedConsultants", Name = "GetAllUnVerifiedConsultants")]
        public async Task<ActionResult> GetAll()
        {
            var res = await _mediator.Send(new GetUnVerifiedConsultantsRequest());
            return Ok(res);
        }

        [HttpGet("UnVerifiedConsultant/{id}", Name = "GetUnVerifiedConsultantById")]
        public async Task<ActionResult> GetById(int id)
        {
            var request = new GetUnVerifiedConsultantDetailesRequest{ Id = id };
            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpPost("ConsultantVerification", Name = "VerifyConsultant")]
        public async Task<ActionResult> VerifyConsultant(VerifyConsultantCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpGet("mail", Name = "SendMail")]
        public async Task<ActionResult> SendMail()
        {
            var user = new User { Email = "mohamed3bdelrahman99@gmail.com", FirstName = "Moahmed" };
            var mes =_mailFactory.GenerateMailMssage(MailType.ConfirmConsultant,user);
            await _mailService.SendMailAsync(mes);

            return Ok();
        }





    }
}
