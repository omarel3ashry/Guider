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
    public class MakeAppointmentMailStrategy : IMailStrategy
    {
        private readonly string fromEmail;
        private readonly string toEmail;
        private readonly string subject;
        private readonly string body;

        public MakeAppointmentMailStrategy(User user)
        {
            fromEmail = "mohamedbdelrahman2@gmail.com";
            toEmail = user.Email!;
            subject = "Session Appointment";
            body = $"Hello {user.FirstName}, You have a new Appointment.";
        }
        public MailMessage GetMailMessage()
        {
            return new MailMessage(from: fromEmail, to: toEmail, subject, body);
        }
    }
}
