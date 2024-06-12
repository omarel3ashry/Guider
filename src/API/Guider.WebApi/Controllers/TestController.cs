using Guider.Application.UseCases.client.Query.GetAllClients;
using Guider.Application.UseCases.client.Query.GetClientDetails;
using Guider.Application.UseCases.consultant.Query.GetAll;
using Guider.Application.UseCases.consultant.Query.GetDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAnyRandomString")]
        public ActionResult<string> Get()
        {
            return Ok("any random string");
        }


    }
}
