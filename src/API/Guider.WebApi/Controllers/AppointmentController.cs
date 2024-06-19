using Guider.Application.UseCases.Appointments.Dto;
using Guider.Application.UseCases.Appointments.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentToReturnDto>> GetAppointment(int id)
        {
            var GetAppointmentQuery=new GetAppointmentQuery() { id=id};
            var result=await _mediator.Send(GetAppointmentQuery);
            return Ok(result);
        }


    }
}
