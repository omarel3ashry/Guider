using Guider.Domain.Enums;
using MediatR;

namespace Guider.Application.UseCases.Payment.command.UserPayment
{
    public class CreateOrUpdatePaymentIntentCommand : IRequest<CreateOrUpdatePaymentIntentCommand>
    {
        public AppointmentState State { get; set; }

        public DateTime Date { get; set; }
        public float Duration { get; set; }
        public int ClientId { get; set; }
        public int ConsultantId { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? ClientSecretKey { get; set; }

    }
}