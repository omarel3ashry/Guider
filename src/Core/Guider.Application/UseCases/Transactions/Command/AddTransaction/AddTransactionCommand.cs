using Guider.Domain.Enums;
using MediatR;

namespace Guider.Application.UseCases.Transactions.Command.AddTransaction
{
    public class AddTransactionCommand : IRequest<bool>
    {

        public TransactionType Type { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public float Amount { get; set; }
        public int UserId { get; set; }
        public int AppointmentId { get; set; }
        public string PaymentIntentId { get; set; }

    }
}
