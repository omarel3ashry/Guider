using Guider.Domain.Enums;

namespace Guider.Application.UseCases.Clients.Query.GetClientDetails
{
    public class AppointmentDTO
    {
        
        public int Id { get; set; }
        public float Rate { get; set; }
        public AppointmentState State { get; set; }
        public float Duration { get; set; }
        public DateTime Date { get; set; }
        public int ConsultantId { get; set; }
        public string ConsultantName { get; set; }


    }
}