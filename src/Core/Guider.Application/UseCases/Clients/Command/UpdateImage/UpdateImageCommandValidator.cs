using FluentValidation;

namespace Guider.Application.UseCases.Clients.Command.UpdateImage
{
    public class UpdateImageCommandValidator : AbstractValidator<UpdateClientImageCommand>
    {
        public UpdateImageCommandValidator()
        {
            RuleFor(w => w.Image)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
