using Guider.Domain.Enums;

namespace Guider.Application.UseCases.Consultants.Query
{
    public class AppointmentDto
    {
        public float Rate { get; set; }
        public AppointmentState State { get; set; }
        public float Duration { get; set; }
        public DateTime Date { get; set; }


        public string ClientName { get; set; }
    }
}