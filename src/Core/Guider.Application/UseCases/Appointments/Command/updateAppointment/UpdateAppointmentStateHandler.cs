using AutoMapper;
using Guider.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.Command.updateAppointment
{
    public class UpdateAppointmentStateHandler : IRequestHandler<updateAppointmentStateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IConsultantRepository _consultantRepository;
        private readonly IAppointmentRepository _appointmentsRepository;
        public UpdateAppointmentStateHandler(IMapper mapper, IConsultantRepository consultantRepository, IAppointmentRepository appointmentsRepository)
        { 
            _mapper = mapper;
            _appointmentsRepository = appointmentsRepository;
            _consultantRepository = consultantRepository;
        }

        public async Task Handle(updateAppointmentStateCommand request, CancellationToken cancellationToken)
        {
            await _appointmentsRepository.UpdateAppointmentStateAsync(request.Id, request.State,request.Rate.Value);
            var appointment=await _appointmentsRepository.GetByIdAsync(request.Id);
            await _consultantRepository.UpdateConsultantAverageRate(appointment.ConsultantId);

            
        }
    }
}
