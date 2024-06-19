using FluentValidation;

namespace Guider.Application.UseCases.Users.Command.ConsultantRegister
{
    public class ConsultantRegisterCommandValidator : AbstractValidator<ConsultantRegisterCommand>
    {
        public ConsultantRegisterCommandValidator()
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
                .MaximumLength(50).WithMessage("{PropertyName} should not exceed 50 Charachers.");
            RuleFor(e=> e.Bio)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MinimumLength(50).WithMessage("{PropertyName} must be at least 50 Charachers.")
                .MaximumLength(300).WithMessage("{PropertyName} should not exceed 300 Charachers.");
            RuleFor(e => e.SubCategoryId)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("You must choose a vlaid Subcategory");
            RuleFor(e => e.HourlyRate)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("You must choose a vlaid {PropertyName}");




        }

    }
}
