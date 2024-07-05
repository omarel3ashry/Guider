using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Exceptions;
using Guider.Application.Responses;
using Guider.Domain.Entities;
using Guider.Domain.Enums;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Command.DeleteConsultant
{
    internal class DeleteConsultantCommandHandler : IRequestHandler<DeleteConsultantCommand, BaseResponse<int>>
    {

        private readonly IConsultantRepository _consultantRepository;
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;

        public DeleteConsultantCommandHandler(IConsultantRepository consultantRepository, IMapper mapper, IAppointmentRepository appointmentRepository)
        {

            _consultantRepository = consultantRepository;
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
        }
        public async Task<BaseResponse<int>> Handle(DeleteConsultantCommand request, CancellationToken cancellationToken)
        {
            var consultant = await _consultantRepository.GetWithUserAsync(request.ConsultantId);
            if (consultant == null)
            {
                throw new NotFoundException($"Consultant with ID {request.ConsultantId} not found.");
            }

            // Mark the associated user as deleted
            consultant.User.IsDeleted = true;
            consultant.IsActive = false;

            await CancelFutureAppointments(consultant);

            // Update the consultant (and the associated user)
            var deleted = await _consultantRepository.UpdateAsync(consultant);

            var response = new BaseResponse<int>();
            response.Result = consultant.Id;
            response.Success = deleted; // Concise assignment

            if (!response.Success) // More descriptive check
            {
                response.Message = "unable to update."; // Or a more specific message
            }

            return response;
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
