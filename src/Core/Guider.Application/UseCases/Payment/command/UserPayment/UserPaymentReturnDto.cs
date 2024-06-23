﻿using Guider.Domain.Enums;

namespace Guider.Application.UseCases.Payment.command.UserPayment
{
    public class UserPaymentReturnDto
    {
        public AppointmentState State { get; set; }

        public DateTime Date { get; set; }
        public float Duration { get; set; }
        public int ClientId { get; set; }
        public int ConsultantId { get; set; }
        public string PaymentIntentId { get; set; }
        public string ClientSecretKey { get; set; }


    }
}