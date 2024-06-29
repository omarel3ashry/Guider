using FluentValidation;

namespace Guider.Application.UseCases.Users.Command.ClientRegister
{
    public class ClientRegisterCommandValidator : AbstractValidator<ClientRegisterCommand>
    {
        public ClientRegisterCommandValidator()
        {
            RuleFor(e => e.FirstName)
               .NotNull().WithMessage("{PropertyName} is required.")
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .MaximumLength(50).WithMessage("{PropertyName} should not exceed 50 Charachers.");
            RuleFor(e => e.LastName)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} should not exceed 50 Charachers.");
            RuleFor(e => e.Email)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .EmailAddress().WithMessage("{PropertyName} in wrong format.")
                .MaximumLength(50).WithMessage("{PropertyName} should not exceed 50 Charachers.");
            RuleFor(e => e.Password)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MinimumLength(8).WithMessage("{PropertyName} must be at least 8 Charachers.")
                .MaximumLength(50).WithMessage("{PropertyName} should not exceed 50 Charachers.")
                .Matches(@"[A-Z]").WithMessage("Passwords must have at least one uppercase ('A'-'Z').")
                .Matches(@"[0-9]").WithMessage("Passwords must have at least one digit ('0'-'9').")
                .Matches(@"[\W]").WithMessage("Passwords must have at least one non alphanumeric character.");

        }
    }
}
