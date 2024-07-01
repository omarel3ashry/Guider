using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Domain.Common;
using Guider.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Guider.Application.UseCases.Appointments.Query.GetAppointmentsStatsForUser
{
    internal class GetAppointmentsStatsForUserQueryHandler<T> : IRequestHandler<GetAppointmentsStatsForUserQuery<T>, BaseResponse<AppointmentsStatsDto>> where T : Consumer
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAppointmentsStatsForUserQueryHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task<BaseResponse<AppointmentsStatsDto>> Handle(GetAppointmentsStatsForUserQuery<T> request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<AppointmentsStatsDto>();
            var statsQuery = _appointmentRepository.GetStatsForUser<T>(request.Id);
            var statsDto = await statsQuery.Select(e => new AppointmentsStatsDto()
            {
                CompletedCount = e.Where(e => e.State == AppointmentState.Completed).Count(),
                CompletedHours = e.Where(e => e.State == AppointmentState.Completed).Sum(e => e.Duration),
                UpcomingCount = e.Where(e => e.State == AppointmentState.Pending).Count(),
                UpcomingHours = e.Where(e => e.State == AppointmentState.Pending).Sum(e => e.Duration),
                CanceledCount = e.Where(e => e.State == AppointmentState.Canceled).Count(),
            }).FirstOrDefaultAsync();

            response.Result = statsDto;
            return response;
        }
    }
}
