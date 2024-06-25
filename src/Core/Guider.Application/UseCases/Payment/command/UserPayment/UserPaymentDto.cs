using Guider.Domain.Enums;

namespace Guider.Application.UseCases.Payment.Command.UserPayment
{
    public class UserPaymentDto
    {
        public AppointmentState State { get; set; }
        public float Duration { get; set; }
        public int ClientId { get; set; }
        public int ConsultantId { get; set; }
        public string PaymentIntentId { get; set; }
        public string ClientSecretKey { get; set; }


    }
}