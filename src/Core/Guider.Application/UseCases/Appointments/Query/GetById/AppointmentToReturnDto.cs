using Guider.Domain.Enums;

namespace Guider.Application.UseCases.Appointments.Query.GetById
{
    public class AppointmentToReturnDto
    {

        public int Id { get; set; }
        public AppointmentState State { get; set; }
        public float Duration { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int ConsultantId { get; set; }




    }
}
