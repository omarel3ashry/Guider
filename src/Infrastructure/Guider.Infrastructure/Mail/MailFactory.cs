using Guider.Application.Contracts.Infrastructure;
using Guider.Domain.Entities;
using Guider.Domain.Enums;
using Guider.Infrastructure.Mail.Strategies;
using System.Net.Mail;

namespace Guider.Infrastructure.Mail
{
    internal class MailFactory : IMailFactory
    {
        public MailMessage GenerateMailMssage(MailType mailType, User user)
        {
            IMailStrategy mailStrategy = mailType switch
            {
                MailType.Register => new RegisterMailStrategy(user),
                MailType.ConfirmConsultant => new ConfirmConsultantMailStrategy(user),
                MailType.MakeAppointment => new MakeAppointmentMailStrategy(user),
                _ => new DefaultMailStrategy(user),
            };
            return mailStrategy.GetMailMessage();
        }
    }
}
