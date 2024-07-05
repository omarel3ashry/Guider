using Guider.Application.Contracts.Infrastructure;
using Guider.Application.Contracts.Persistence;
using Guider.Domain.Enums;
using Guider.Infrastructure.Meeting;
using Hangfire;

namespace Guider.Infrastructure.Jobs
{
    public class BackgroundJobs : IBackgroundJob
    {
        private readonly IBackgroundJobClient _backgroundClient;
        //private readonly IRepository<Appointment> _appointmentRepository;

        public BackgroundJobs(IBackgroundJobClient backgroundClient)
        {
            _backgroundClient = backgroundClient;
            //_appointmentRepository = appointmentRepository;
        }

        public void ScheduleAppointment(DateTime time, int duration, int clientUserId, int consultantUserId, int appointmentId)
        {
            //_backgroundClient.Schedule<MeetingHub>(
            //    (hub) => StartMeeting(hub, clientUserId, consultantUserId, appointmentId),
            //    time - DateTime.Now
            //    );
            _backgroundClient.Schedule<IAppointmentRepository>((repo) => repo.UpdateAppointmentStateAsync(appointmentId, AppointmentState.Ongoing, 0), time - DateTime.Now);
            _backgroundClient.Schedule<MeetingHub>((hub) => hub.NotifiyMeetingStart(clientUserId, consultantUserId, appointmentId), time - DateTime.Now);
            _backgroundClient.Schedule<IAppointmentRepository>((repo) => repo.UpdateAppointmentStateAsync(appointmentId, AppointmentState.Completed, 0), time.AddHours(duration) - DateTime.Now);
            _backgroundClient.Schedule<MeetingHub>((hub) => hub.NotifiyMeetingEnd(clientUserId, consultantUserId), time - DateTime.Now);
        }
        //private async Task updateAppointment( int appointmentId)
        //{
        //    var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);
        //    if (appointment != null)
        //    {
        //        Debug.WriteLine("state before: " + appointment.State);
        //        appointment.State = AppointmentState.Ongoing;
        //        await _appointmentRepository.UpdateAsync(appointment);
        //        //await hub.MeetingNotification(clientUserId, consultantUserId, appointmentId);
        //    }
        //}
    }
}
