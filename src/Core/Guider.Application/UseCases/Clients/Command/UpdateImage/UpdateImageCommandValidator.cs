using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Clients.Command.UpdateImage
{
    public class UpdateImageCommandValidator:AbstractValidator<UpdateClientImageCommand>
    {
        public UpdateImageCommandValidator()
        {
            RuleFor(w => w.Image)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
