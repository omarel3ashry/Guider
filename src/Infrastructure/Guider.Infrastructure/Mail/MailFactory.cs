using Guider.Application.Contracts.Infrastructure;
using Guider.Domain.Entities;
using Guider.Domain.Enums;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Infrastructure.Mail
{
    internal class MailFactory : IMailFactory
    {
        public MailMessage GenerateMailMssage(MailType mailType, User user)
        {
            var mes = new MailMessage();
            switch(mailType)
            {
                case MailType.ConfirmConsultant:
                    return new MailMessage(from:"admin@guider.com",to:user.Email!,"Confirm Consultant Profile", "Your Profil Was Verified");
                case MailType.MakeAppointment:
                    return new MailMessage(from: "admin@guider.com", to: user.Email!, "Session Appointment", $"Hello {user.FirstName}, you have a new Appointment.");
                case MailType.Register:
                    return new MailMessage(from: "admin@guider.com", to: user.Email!, "Successful Registeration", $"Hello {user.FirstName}! ");
                default: 
                    return new MailMessage(from: "admin@guider.com", to: user.Email!, "Hello!", "Hello in Our Family");
            }
        }
    }
}
