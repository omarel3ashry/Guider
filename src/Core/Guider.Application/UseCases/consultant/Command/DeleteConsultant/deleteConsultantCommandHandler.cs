using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Exceptions;
using Guider.Domain.Entities;
using Guider.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.consultant.Command.DeleteConsultant
{
    internal class deleteConsultantCommandHandler : IRequestHandler<DeleteConsultantCommand, int>
    {

        private readonly IConsultantRepository _consultantRepository;
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;

        public deleteConsultantCommandHandler(IConsultantRepository consultantRepository, IMapper mapper, IAppointmentRepository appointmentRepository)
        {

            _consultantRepository = consultantRepository;
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
        }
        public async Task<int> Handle(DeleteConsultantCommand request, CancellationToken cancellationToken)
        {
            var consultant = await _consultantRepository.GetConsultantWithUserByIdAsync(request.ConsultantId);
            if (consultant == null)
            {
                throw new NotFoundException($"Consultant with ID {request.ConsultantId} not found.");
            }

            // Mark the associated user as deleted
            consultant.User.IsDeleted = true;
            consultant.IsActive = false;

            await CancelFutureAppointments(consultant);

            // Update the consultant (and the associated user)
            await _consultantRepository.UpdateAsync(consultant);

            return consultant.Id;
        }

        private async Task CancelFutureAppointments(Consultant consultant)
        {
            var now = DateTime.UtcNow; // Get the current date and time in UTC

            var futureAppointments = consultant.Appointments
                .Where(a => a.Date > now);

            foreach (var appointment in futureAppointments)
            {
                appointment.State = AppointmentState.Canceled;
            }
            //we should return the money back 
            await _appointmentRepository.UpdateRangeAsync(futureAppointments);

        }
    }
}
