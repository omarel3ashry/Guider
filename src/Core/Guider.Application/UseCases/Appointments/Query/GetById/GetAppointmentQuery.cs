using MediatR;

namespace Guider.Application.UseCases.Appointments.Query.GetById
{
    public class GetAppointmentQuery : IRequest<AppointmentToReturnDto>
    {
        public int Id { get; set; }
    }

}
