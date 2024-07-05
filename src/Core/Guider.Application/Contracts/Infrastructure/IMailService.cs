using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.Contracts.Infrastructure
{
    public interface IMailService
    {
         Task SendMailAsync(MailMessage mailMessage);
    }
}
