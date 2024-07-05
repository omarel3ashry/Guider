using Guider.Domain.Enums;

namespace Guider.Application.UseCases.Transactions.Dto
{
    public class TransactionToAddDto
    {

        public TransactionType Type { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public float Amount { get; set; }
        public int UserId { get; set; }
        public int AppointmentId { get; set; }
        public string PaymentIntentId { get; set; }


    }
}
