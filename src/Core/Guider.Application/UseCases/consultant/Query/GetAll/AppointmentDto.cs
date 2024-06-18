using Guider.Domain.Entities;
using Guider.Domain.Enums;

namespace Guider.Application.UseCases.consultant.Query.GetAll
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