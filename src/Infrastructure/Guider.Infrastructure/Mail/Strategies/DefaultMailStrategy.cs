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
    public class DefaultMailStrategy : IMailStrategy
    {
        private readonly string fromEmail;
        private readonly string toEmail;
        private readonly string subject;
        private readonly string body;

        public DefaultMailStrategy(User user)
        {
            fromEmail = "mohamedbdelrahman2@gmail.com";
            toEmail = user.Email!;
            subject = "Guider";
            body = $"Hi {user.FirstName},Hello in Our Family";
        }
        public MailMessage GetMailMessage()
        {
            return new MailMessage(from: fromEmail, to: toEmail, subject, body);
        }
    }
}
