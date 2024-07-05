using FluentValidation;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Command.UpdateBankAccount
{
    public class UpdateBankAccountCommandHandler : IRequestHandler<UpdateConsultantBankAccountCommand, BaseResponse<string>>
    {
        private readonly IValidator<UpdateConsultantBankAccountCommand> _validator;
        private readonly IConsultantRepository _consultantRepository;

        public UpdateBankAccountCommandHandler(IValidator<UpdateConsultantBankAccountCommand> validator, IConsultantRepository consultantRepository)
        {
            _validator = validator;
            _consultantRepository = consultantRepository;
        }

        public async Task<BaseResponse<string>> Handle(UpdateConsultantBankAccountCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var consultantToUpdate = await _consultantRepository.GetByIdAsync(request.Id);

            if (consultantToUpdate == null)
            {
                return new BaseResponse<string> { Success = false, Message = "Consultant not found." };
            }

            consultantToUpdate.BankAccount = request.BankAccount;
            bool updated = await _consultantRepository.UpdateAsync(consultantToUpdate);

            var response = new BaseResponse<string>();

            if (updated)
            {
                response.Message = "Consultant bank account updated successfully.";
                response.Result = consultantToUpdate.BankAccount;
            }
            else
            {
                response.Success = false;
                response.Message = "Failed to update the bank account!";
            }
            return response;
        }
    }
}
