using Guider.Application.Contracts.Infrastructure;
using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Infrastructure.Mail.Strategies
{
    public class ConfirmConsultantMailStrategy : IMailStrategy
    {
        private readonly string fromEmail;
        private readonly string toEmail;
        private readonly string subject;
        private readonly string body;

        public ConfirmConsultantMailStrategy(User user)
        {
            fromEmail = "mohamedbdelrahman2@gmail.com";
            toEmail = user.Email!;
            subject = "Your Guider Profile Has Been Verified!";
            body = $"Dear {user.FirstName},\r\n\r\nCongratulations! Your Guider profile has been verified." +
                " You can now offer your expertise and manage your availability for consultations.";
        }
        public MailMessage GetMailMessage()
        {
            return new MailMessage(from: fromEmail, to: toEmail, subject, body);
        }
    }
}
