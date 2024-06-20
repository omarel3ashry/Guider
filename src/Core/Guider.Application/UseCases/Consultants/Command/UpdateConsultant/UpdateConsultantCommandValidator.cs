using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.Command.UpdateConsultant
{
    public class UpdateConsultantCommandValidator : AbstractValidator<UpdateConsultantCommand>
    {
        public UpdateConsultantCommandValidator()
        {
            RuleFor(x => x.Bio)
            .NotEmpty().WithMessage("Bio is required.")
            .MaximumLength(300).WithMessage("Bio must not exceed 300 characters.");

            RuleFor(x => x.HourlyRate)
                .GreaterThan(0).WithMessage("Hourly rate must be greater than zero.");
        }
    }
}
