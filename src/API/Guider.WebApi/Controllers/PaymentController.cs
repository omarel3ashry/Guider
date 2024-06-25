using Guider.Application.UseCases.Payment.Command.PayToConsultant;
using Guider.Application.UseCases.Payment.Command.Refund;
using Guider.Application.UseCases.Payment.Command.UserPayment;
using Guider.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateOrUpdatePaymentIntentCommand>> CreateOrUpdatePaymentIntent(CreateOrUpdatePaymentIntentCommand CreateOrUpdatePaymentIntentCommand)
     {
            try
            {

                var result = await _mediator.Send(CreateOrUpdatePaymentIntentCommand);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("refund")]
        public async Task<IActionResult> CreateRefund(int appointmentId)
        {
            var refund = await _mediator.Send(new RefundPaymentCommand() { AppointmentId = appointmentId });
            return Ok(refund);
        }

        [HttpPost("completePayment")]
        public async Task<IActionResult> completePayment(int appointmentId)
        {

            var payment = await _mediator.Send(new PayToConsultantCommand() { appointmentId = appointmentId });
            return Ok(payment);
        }

    }
}