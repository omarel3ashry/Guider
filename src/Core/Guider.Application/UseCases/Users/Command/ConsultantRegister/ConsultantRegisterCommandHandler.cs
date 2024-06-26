using AutoMapper;
using FluentValidation;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.Users.Command.ConsultantRegister
{
    public class ConsultantRegisterCommandHandler : IRequestHandler<ConsultantRegisterCommand, AuthenticationResponse>
    {
        private readonly IConsultantRepository _consultantRepository;
        private readonly IRegisterUserRepository<Consultant> _userRepository;
        private readonly IValidator<ConsultantRegisterCommand> _validator;
        private readonly IMapper _mapper;

        public ConsultantRegisterCommandHandler(IConsultantRepository consultantRepository,
                                                IRegisterUserRepository<Consultant> userRepository,
                                                IValidator<ConsultantRegisterCommand> validator,
                                                IMapper mapper)
        {
            _consultantRepository = consultantRepository;
            _userRepository = userRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse> Handle(ConsultantRegisterCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var user = _mapper.Map<User>(request);
            var result = await _userRepository.RegisterAsync(user, request.Password);

            if (!result.Success)
                return result;
            var consultant = _mapper.Map<Consultant>(request);
            consultant.UserId = result.Id;

            await _consultantRepository.AddAsync(consultant);

            return result;
        }
    }
}
