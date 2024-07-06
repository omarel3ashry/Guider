using System.Net.Mail;

namespace Guider.Application.Contracts.Infrastructure
{
    public interface IMailService
    {
        Task SendMailAsync(MailMessage mailMessage);
    }
}
