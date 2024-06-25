using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Appointments.Command.CancelAppointment
{
    public class CancelAppointmentCommand : IRequest<BaseResponse>
    {
        public int AppointmentId { get; set; }
        public int ClientUserId { get; set; }
    }
}
