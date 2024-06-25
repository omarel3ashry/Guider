using AutoMapper;
using FluentValidation;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.Users.Command.ClientRegister
{
    public class ClientRegisterCommandHandler : IRequestHandler<ClientRegisterCommand, AuthenticationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<ClientRegisterCommand> _validator;
        private readonly IRegisterUserRepository<Domain.Entities.Client> _userRepository;

        public ClientRegisterCommandHandler(IMapper mapper, IValidator<ClientRegisterCommand> validator,
                                            IRegisterUserRepository<Domain.Entities.Client> userRepository)
        {
            _mapper = mapper;
            _validator = validator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResponse> Handle(ClientRegisterCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var user = _mapper.Map<User>(request);

            var result = await _userRepository.RegisterAsync(user, request.Password);

            if (!result.Success)
                return result;
            var client = _mapper.Map<Domain.Entities.Client>(request);
            client.UserId = result.Id;
            //save into database using client repository
            return result;

        }
    }
}