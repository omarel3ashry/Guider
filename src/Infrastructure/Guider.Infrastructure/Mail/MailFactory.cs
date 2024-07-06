using Guider.Application.Contracts.Infrastructure;
using Guider.Domain.Entities;
using Guider.Domain.Enums;
using System.Net.Mail;

namespace Guider.Infrastructure.Mail
{
    internal class MailFactory : IMailFactory
    {
        public MailMessage GenerateMailMssage(MailType mailType, User user)
        {
            string body = $"Dear {user.FirstName},\r\n\r\nCongratulations! Your Guider profile has been verified. You can now offer your expertise and manage your availability for consultations.";

            switch (mailType)
            {
                case MailType.ConfirmConsultant:
                    return new MailMessage(from: "mohamedbdelrahman2@gmail.com", to: user.Email!, "Your Guider Profile Has Been Verified!", body);
                case MailType.MakeAppointment:
                    return new MailMessage(from: "mohamedbdelrahman2@gmail.com", to: user.Email!, "Session Appointment", $"Hello {user.FirstName}, you have a new Appointment.");
                case MailType.Register:
                    return new MailMessage(from: "mohamedbdelrahman2@gmail.com", to: user.Email!, "Successful Registeration", $"Hello {user.FirstName}! ");
                default:
                    return new MailMessage(from: "mohamedbdelrahman2@gmail.com", to: user.Email!, "Hello!", "Hello in Our Family");
            }
        }
    }
}
