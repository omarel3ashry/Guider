using Guider.Domain.Enums;

namespace Guider.Application.UseCases.Transactions.Query.GetTransactionQuery
{
    public class TransactionReturnDto
    {
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string? clientName { get; set; }

        public string? consultantName { get; set; }


    }
}
