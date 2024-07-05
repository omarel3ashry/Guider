using MediatR;

namespace Guider.Application.UseCases.Transactions.Query.GetTransactionQuery
{
    public class getTransactionByUserIdQuery : IRequest<List<TransactionReturnDto>>
    {

        public int UserId { get; set; }



    }
}
