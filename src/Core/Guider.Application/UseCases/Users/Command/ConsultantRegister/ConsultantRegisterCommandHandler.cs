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
        private readonly IMapper _mapper;
        private readonly IValidator<ConsultantRegisterCommand> _validator;
        private readonly IRegisterUserRepository<Consultant> _userRepository;
        private readonly IRepository<Consultant> _consultantRepository;

        public ConsultantRegisterCommandHandler(IMapper mapper, IValidator<ConsultantRegisterCommand> validator,
                                                IRegisterUserRepository<Consultant> userRepository,
                                                IRepository<Consultant> consultantRepository)
        {
            _mapper = mapper;
            _validator = validator;
            _userRepository = userRepository;
            _consultantRepository = consultantRepository;
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
            bool created = await _consultantRepository.AddAsync(consultant);
            if (!created)
                throw new Exceptions.BadRequestException("Error in create Consultant");
            return result;
        }
    }
}
