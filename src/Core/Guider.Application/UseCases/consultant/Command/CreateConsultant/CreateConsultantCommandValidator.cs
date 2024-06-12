using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.consultant.Command.CreateConsultant
{
    public class CreateConsultantCommandValidator:AbstractValidator<CreateConsultantCommand>
    {
        public CreateConsultantCommandValidator()
        {
            RuleFor(v => v.Bio)
           .NotEmpty().WithMessage("Bio is required.")
           .MaximumLength(300).WithMessage("Bio must not exceed 300 characters.");

            RuleFor(v => v.HourlyRate)
                .GreaterThan(0).WithMessage("Hourly rate must be greater than zero.");

            RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("User Id must be greater than zero.");

            RuleFor(v => v.SubCategoryId)
                .GreaterThan(0).WithMessage("SubCategory Id must be greater than zero.");

        }
    }
}
