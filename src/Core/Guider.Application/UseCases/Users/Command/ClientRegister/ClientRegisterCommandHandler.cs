using AutoMapper;
using FluentValidation;
using Guider.Application.Contracts.Infrastructure;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Domain.Entities;
using Guider.Domain.Enums;
using MediatR;

namespace Guider.Application.UseCases.Users.Command.ClientRegister
{
    public class ClientRegisterCommandHandler : IRequestHandler<ClientRegisterCommand, AuthenticationResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<ClientRegisterCommand> _validator;
        private readonly IRegisterUserRepository<Client> _userRepository;
        private readonly IMailFactory _mailFactory;
        private readonly IMailService _mailService;


        public ClientRegisterCommandHandler(IClientRepository clientRepository,
                                            IRegisterUserRepository<Client> userRepository,
                                            IValidator<ClientRegisterCommand> validator,
                                            IMapper mapper,
                                            IMailFactory mailFactory,
                                            IMailService mailService)
        {
            _clientRepository = clientRepository;
            _userRepository = userRepository;
            _validator = validator;
            _mapper = mapper;
            _mailFactory = mailFactory;
            _mailService = mailService;
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

            var client = _mapper.Map<Client>(request);
            client.UserId = result.Id;

            bool created = await _clientRepository.AddAsync(client);
            if (!created)
                throw new Exceptions.BadRequestException("Error in create Client");

            var mes = _mailFactory.GenerateMailMssage(MailType.Register, user);
            await _mailService.SendMailAsync(mes);

            return result;

        }
    }
}