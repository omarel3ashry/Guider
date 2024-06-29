using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Clients.Command.UpdateBankAccount
{
    public class UpdateClientBankAccountCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string BankAccount { get; set; }
    }
}
