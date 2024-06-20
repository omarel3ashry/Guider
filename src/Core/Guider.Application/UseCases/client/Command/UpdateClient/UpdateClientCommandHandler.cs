using AutoMapper;
using FluentValidation;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Exceptions;
using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.client.Command.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, BaseResponse<UpdateClientDto>>
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        private readonly IValidator<UpdateClientCommand> _validator;

        public UpdateClientCommandHandler(IMapper mapper, IClientRepository clientRepository, IValidator<UpdateClientCommand> validator)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
            _validator = validator;
        }
        public async Task<BaseResponse<UpdateClientDto>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            // Get the existing consultant
            var client = await _clientRepository.GetClientWithAppointments(request.Id);
            if (client == null)
            {
                throw new NotFoundException($"Client with ID {request.Id} not found.");
            }

            // Update the consultant properties
            client.User.LastName = request.LastName;
            client.User.FirstName = request.FirstName;

            // Save the changes
            await _clientRepository.UpdateAsync(client);



            // Return the updated consultant
            var ClientToReturn = _mapper.Map<UpdateClientDto>(client);
            var response = new BaseResponse<UpdateClientDto>();
            response.Result = ClientToReturn;
            response.Success = ClientToReturn != null; // Concise assignment

            if (!response.Success) // More descriptive check
            {
                response.Message = "unable to update."; // Or a more specific message
            }

            return response;
        }
    }
}
