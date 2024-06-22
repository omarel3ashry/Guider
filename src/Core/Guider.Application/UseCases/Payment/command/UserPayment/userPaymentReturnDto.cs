using Guider.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Payment.command.UserPayment
{
    public class userPaymentReturnDto
    {
        public AppointmentState State { get; set; }

        public DateTime Date { get; set; }
        public float Duration { get; set; }
        public int ClientId { get; set; }
        public int ConsultantId { get; set; }
        public string PaymentIntentId {  get; set; }
        public string clientSecretKey { get; set;}


    }
}
