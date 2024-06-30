using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.Contracts.Infrastructure
{
    public interface IBackgroundJob
    {
        void ScheduleAppointment(DateTime time,int clientUserId,int consultantUserId,int appointmentId);
    }
}
