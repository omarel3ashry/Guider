using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.command.insertAppointment
{
    public class AddAppointmentCommandHandler : IRequestHandler<AddAppointmentCommand, bool>
    {
        private readonly IRepository<Appointment> _appointmentRepo;
        private readonly IMapper _mapper;
        public AddAppointmentCommandHandler(IRepository<Appointment> appointmentRepo, IMapper mapper)
        {
         
            _appointmentRepo = appointmentRepo;
            _mapper = mapper;
        }
        public  async  Task<bool> Handle(AddAppointmentCommand request, CancellationToken cancellationToken)
        {
            var mappedappointment=_mapper.Map<Appointment>(request);
            return await _appointmentRepo.AddAsync(mappedappointment);
        }
    }
}
