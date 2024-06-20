using FluentValidation;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.client.Command.UpdateBankAccount
{
    public class UpdateBankAccountCommandHandler : IRequestHandler<UpdateClientBankAccountCommand, BaseResponse<string>>
    {
        private readonly IValidator<UpdateClientBankAccountCommand> _validator;
        private readonly IClientRepository _clientRepository;

        public UpdateBankAccountCommandHandler(IValidator<UpdateClientBankAccountCommand> validator, IClientRepository clientRepository)
        {
            _validator = validator;
            _clientRepository = clientRepository;

        }
        public async Task<BaseResponse<string>> Handle(UpdateClientBankAccountCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var clientToUpdate = await _clientRepository.GetByIdAsync(request.Id);

            if (clientToUpdate == null)
            {
                return new BaseResponse<string> { Success = false, Message = "Client not found." };
            }

            clientToUpdate.BankAccount = request.BankAccount;
            bool updated = await _clientRepository.UpdateAsync(clientToUpdate);

            var response = new BaseResponse<string>();

            if (updated)
            {
                response.Message = "Client bank account updated successfully.";
                response.Result = clientToUpdate.BankAccount;
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
