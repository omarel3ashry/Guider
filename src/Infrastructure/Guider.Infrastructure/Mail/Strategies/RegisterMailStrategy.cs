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
    public class RegisterMailStrategy : IMailStrategy
    {
        private readonly string fromEmail;
        private readonly string toEmail;
        private readonly string subject;
        private readonly string body;

        public RegisterMailStrategy(User user)
        {
            fromEmail = "mohamedbdelrahman2@gmail.com";
            toEmail = user.Email!;
            subject = "Successful Registeration";
            body = $"Hello {user.FirstName}! \\n Let's discover Guider world!";
        }
        public MailMessage GetMailMessage()
        {           
            return new MailMessage(from: fromEmail , to: toEmail, subject, body );
        }
    }
}
