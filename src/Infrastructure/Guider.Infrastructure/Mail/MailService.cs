using Guider.Application.Contracts.Infrastructure;
using System.Net;
using System.Net.Mail;

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
