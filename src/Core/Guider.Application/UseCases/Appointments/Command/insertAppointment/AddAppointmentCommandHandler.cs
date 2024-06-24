using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.UseCases.Appointments.Query.GetById;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.Appointments.Command.InsertAppointment
{
    public class AddAppointmentCommandHandler : IRequestHandler<AddAppointmentCommand, AppointmentToReturnDto>
    {
        private readonly IRepository<Appointment> _appointmentRepo;
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;
        public AddAppointmentCommandHandler(IRepository<Appointment> appointmentRepo, IMapper mapper, IAppointmentRepository appointmentRepository)
        {

            _appointmentRepo = appointmentRepo;
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
        }
        public async Task<AppointmentToReturnDto> Handle(AddAppointmentCommand request, CancellationToken cancellationToken)
        {
            var mappedappointment = _mapper.Map<Appointment>(request);
            var result = await _appointmentRepository.AddAppointment(mappedappointment);
            return _mapper.Map<AppointmentToReturnDto>(result);
        }
    }
}