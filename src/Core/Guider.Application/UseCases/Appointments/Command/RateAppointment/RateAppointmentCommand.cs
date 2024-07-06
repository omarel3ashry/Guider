using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Appointments.Command.RateAppointment
{
    public class RateAppointmentCommand : IRequest<BaseResponse>
    {
        public int AppointmentId { get; set; }
        public int Rate { get; set; }
    }
}
