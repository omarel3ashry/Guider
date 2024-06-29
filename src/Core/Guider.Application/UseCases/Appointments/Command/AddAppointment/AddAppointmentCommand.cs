using Guider.Application.Responses;
using Guider.Application.UseCases.Appointments.Query.GetById;
using MediatR;

namespace Guider.Application.UseCases.Appointments.Command.AddAppointment
{
    public class AddAppointmentCommand : IRequest<BaseResponse<AppointmentDto>>
    {
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int ClientId { get; set; }
        public int ConsultantId { get; set; }

    }
}