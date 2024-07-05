namespace Guider.Application.Contracts.Infrastructure
{
    public interface IBackgroundJob
    {
        void ScheduleAppointment(DateTime time, int duration, int clientUserId, int consultantUserId, int appointmentId);
    }
}
