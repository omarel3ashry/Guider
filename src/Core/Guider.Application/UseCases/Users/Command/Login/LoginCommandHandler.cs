using FluentValidation;
using Guider.Application.Contracts.Identity;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Exceptions;
using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Users.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, BaseResponse<string>>
    {
        private readonly ITokenFactory _tokenFactory;
        private readonly IValidator<LoginCommand> _validator;
        private readonly IUserRepository _userRepository;

        public LoginCommandHandler(IValidator<LoginCommand> validator, IUserRepository userRepository,
                                   ITokenFactory tokenFactory)
        {
            _validator = validator;
            _userRepository = userRepository;
            _tokenFactory = tokenFactory;
        }

        public async Task<BaseResponse<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var validLogin = await _userRepository.LoginAsync(request.Email, request.Password);

            if (!validLogin)
                throw new BadRequestException("Invalid Email/UserName or password!");

            var user = await _userRepository.GetByEmailAsync(request.Email);

            var token = await _tokenFactory.GenerateToken(user);
            return new BaseResponse<string> { Message = $"{user.UserName} Authenticated Successfully", Result = token };

        }
    }
}
