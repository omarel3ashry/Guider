using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Domain.Common;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.Appointments.Query.GetAllForConsultant
{
    internal class GetAllAppointmentsForUserHandler<T> : IRequestHandler<GetAllAppointmentsForUserQuery<T>, BaseResponse<PaginatedList<AppointmentListDto, Appointment>>> where T : Consumer
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public GetAllAppointmentsForUserHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<PaginatedList<AppointmentListDto, Appointment>>> Handle(GetAllAppointmentsForUserQuery<T> request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<PaginatedList<AppointmentListDto, Appointment>>();
            var appointments = _appointmentRepository.GetAllForUser<T>(request.Id, request.State);
            response.Result = await PaginatedList<AppointmentListDto, Appointment>.CreateWithProjectToAsync(appointments, _mapper, request.Page, request.PageSize);
            return response;
        }
    }
}
