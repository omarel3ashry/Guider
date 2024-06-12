using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.client.Command.CreateClient
{
    public class CreateClientCommandValidator:AbstractValidator<ClientCreateCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(v => v.UserId)
               .GreaterThan(0).WithMessage("User Id must be greater than zero.");
        }
    }
}
