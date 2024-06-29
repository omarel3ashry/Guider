using FluentValidation;

namespace Guider.Application.UseCases.Clients.Command.UpdateBankAccount
{
    public class UpdateBankAccountCommandValidator : AbstractValidator<UpdateClientBankAccountCommand>
    {
        public UpdateBankAccountCommandValidator()
        {

            RuleFor(x => x.BankAccount)
                .NotEmpty().WithMessage("Bank account number is required.")
                .Matches(@"^\d{10,}$").WithMessage("Bank account number must be at least 10 digits.");
        }
    }

}
