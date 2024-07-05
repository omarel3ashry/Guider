using Guider.Domain.Enums;
using MediatR;

namespace Guider.Application.UseCases.Payment.Command.UserPayment
{
    public class CreateOrUpdatePaymentIntentCommand : IRequest<UserPaymentDto>
    {
        public AppointmentState State { get; set; }
        public int Duration { get; set; }
        public int ClientId { get; set; }
        public int ConsultantId { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? ClientSecretKey { get; set; }

    }
}