using MediatR;

namespace Guider.Application.UseCases.Payment.command.Refund
{
    public class RefundPaymentCommand : IRequest<Stripe.Refund>
    {


        public int AppointmentId { get; set; }
    }
}
