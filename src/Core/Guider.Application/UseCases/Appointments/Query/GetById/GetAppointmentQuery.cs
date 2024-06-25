using MediatR;

namespace Guider.Application.UseCases.Appointments.Query.GetById
{
    public class GetAppointmentQuery : IRequest<AppointmentDto>
    {
        public int Id { get; set; }
    }

}
