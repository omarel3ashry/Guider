using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.UseCases.Appointments.Dto;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.command.insertAppointment
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
            var result=await _appointmentRepository.Addappointment(mappedappointment);
            return _mapper.Map<AppointmentToReturnDto>(result);
        }
    }
}