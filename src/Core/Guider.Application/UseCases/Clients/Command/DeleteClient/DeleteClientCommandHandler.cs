using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Exceptions;
using Guider.Domain.Enums;
using MediatR;

namespace Guider.Application.UseCases.Clients.Command.DeleteClient
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public DeleteClientCommandHandler(IMapper mapper, IClientRepository clientRepository, IAppointmentRepository appointmentRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
            _appointmentRepository = appointmentRepository;
        }
        public async Task<int> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetClientWithAppointments(request.ClientId);
            if (client == null)
            {
                throw new NotFoundException($"Client with ID {request.ClientId} not found.");
            }

            // Mark the associated user as deleted
            client.User.IsDeleted = true;


            await CancelFutureAppointments(client);

            // Update the consultant (and the associated user)
            await _clientRepository.UpdateAsync(client);

            return client.Id;
        }

        private async Task CancelFutureAppointments(Domain.Entities.Client client)
        {
            var now = DateTime.UtcNow; // Get the current date and time in UTC

            var futureAppointments = client.Appointments
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
