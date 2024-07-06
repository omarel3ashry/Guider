using Guider.Domain.Entities;
using Guider.Domain.Enums;
using System.Net.Mail;

namespace Guider.Application.Contracts.Infrastructure
{
    public interface IMailFactory
    {
        MailMessage GenerateMailMssage(MailType mailType, User user);
    }
}
