using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Application.UseCases.Appointments.Query.GetAllForConsultant;
using Guider.Domain.Common;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var appointments =await _appointmentRepository.GetStatsForUser<T>(request.Id);
            //response.Result = await PaginatedList<AppointmentListDto, Appointment>.CreateAsync(appointments, _mapper, request.Page, request.PageSize);
            return response;
        }
    }
}
