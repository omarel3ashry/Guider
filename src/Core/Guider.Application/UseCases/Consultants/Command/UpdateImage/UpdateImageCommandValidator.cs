using FluentValidation;

namespace Guider.Application.UseCases.Consultants.Command.UpdateImage
{
    public class UpdateImageCommandValidator : AbstractValidator<UpdateConsultantImageCommand>
    {
        public UpdateImageCommandValidator()
        {
            RuleFor(w => w.Image)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
