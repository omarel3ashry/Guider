namespace Guider.Application.UseCases.Appointments.Query.GetAppointmentsStatsForUser
{
    public class AppointmentsStatsDto
    {
        public int CompletedCount { get; set; }
        public int CompletedHours { get; set; }
        public int UpcomingCount { get; set; }
        public int UpcomingHours { get; set; }
        public int CanceledCount { get; set; }

    }
}
