using Guider.Application.Contracts.Infrastructure;
using Guider.Infrastructure.Meeting;
using Hangfire;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Infrastructure.Jobs
{
    public class BackgroundJobs : IBackgroundJob
    {
        private readonly IBackgroundJobClient _backgroundClient;

        public BackgroundJobs(IBackgroundJobClient backgroundClient)
        {
            _backgroundClient = backgroundClient;
        }

        public void ScheduleAppointment(DateTime time, int clientUserId, int consultantUserId, int appointmentId)
        {
            _backgroundClient.Schedule<MeetingHub>(
                (h) =>  h.MeetingNotification(clientUserId, consultantUserId,appointmentId),
                time-DateTime.Now
                );
        }
    }
}
