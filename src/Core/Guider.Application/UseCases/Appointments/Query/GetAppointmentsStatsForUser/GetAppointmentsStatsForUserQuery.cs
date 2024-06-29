using Guider.Application.Responses;
using Guider.Domain.Common;
using MediatR;

namespace Guider.Application.UseCases.Appointments.Query.GetAppointmentsStatsForUser
{
    public class GetAppointmentsStatsForUserQuery<T> : IRequest<BaseResponse<AppointmentsStatsDto>> where T : Consumer
    {
        public int Id { get; set; }
    }
}
