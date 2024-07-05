using FluentValidation;

namespace Guider.Application.UseCases.Clients.Command.UpdateClient
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(x => x.FirstName)
           .NotEmpty().WithMessage("firstname is required.")
           .MaximumLength(30).WithMessage("firstname must not exceed 30 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("lastname is required.")
           .MaximumLength(300).WithMessage("lastname must not exceed 30 characters.");

        }
    }
}
