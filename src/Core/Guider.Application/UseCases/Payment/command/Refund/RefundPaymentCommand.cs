using MediatR;

namespace Guider.Application.UseCases.Payment.Command.Refund
{
    public class RefundPaymentCommand : IRequest<Stripe.Refund>
    {
        public int AppointmentId { get; set; }
    }
}
