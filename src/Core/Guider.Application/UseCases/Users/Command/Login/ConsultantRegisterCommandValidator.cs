using FluentValidation;
using Guider.Application.UseCases.Users.Command.Login;

namespace Guider.Application.UseCases.Users.Command.ConsultantRegister
{
    public class LoginCommandCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandCommandValidator()
        {
            RuleFor(e => e.Email)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} should not exceed 50 Charachers.");
            RuleFor(e => e.Password)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MinimumLength(8).WithMessage("{PropertyName} must be at least 8 Charachers.")
                .MaximumLength(50).WithMessage("{PropertyName} should not exceed 50 Charachers.");




        }

    }
}
