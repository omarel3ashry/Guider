using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Exceptions;
using MediatR;

namespace Guider.Application.UseCases.Appointments.Query.GetById
{
    public class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentQuery, AppointmentDto>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepo;
        public GetAppointmentQueryHandler(IMapper mapper, IAppointmentRepository appointmentRepo)
        {
            _mapper = mapper;
            _appointmentRepo = appointmentRepo;
        }

        public async Task<AppointmentDto> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepo.GetWithIncludesAsync(request.Id);
            if (appointment == null)
            {
                throw new NotFoundException("there is no appointment with this id");
            }
            return _mapper.Map<AppointmentDto>(appointment);
        }
    }
}
