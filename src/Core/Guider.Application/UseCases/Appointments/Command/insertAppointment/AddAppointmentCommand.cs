using Guider.Application.UseCases.Appointments.Query.GetById;
using Guider.Domain.Enums;
using MediatR;

namespace Guider.Application.UseCases.Appointments.Command.InsertAppointment
{
    public class AddAppointmentCommand : IRequest<AppointmentToReturnDto>
    {
        public AppointmentState State { get; set; }
        public DateTime Date { get; set; }
        public float Duration { get; set; }
        public int ClientId { get; set; }
        public int ConsultantId { get; set; }

    }
}