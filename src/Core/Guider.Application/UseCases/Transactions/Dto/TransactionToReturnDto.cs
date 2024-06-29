using Guider.Domain.Enums;

namespace Guider.Application.UseCases.Transactions.Dto
{
    internal class TransactionToReturnDto
    {
        public int id { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public int UserId { get; set; }
        public int AppointmentId { get; set; }
        public string PaymentIntentId { get; set; }

    }
}
