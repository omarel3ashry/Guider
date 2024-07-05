using Guider.Application.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Infrastructure.Mail
{
    public class MailService : IMailService
    {
        public async Task SendMailAsync(MailMessage mailMessage)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("mohamedbdelrahman2@gmail.com", "rjvt btzq tbmv oyge")
            };

            await client.SendMailAsync(mailMessage);
        }
    }
}
