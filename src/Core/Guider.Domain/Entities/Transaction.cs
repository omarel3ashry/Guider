using Guider.Domain.Enums;

namespace Guider.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public int UserId { get; set; }
        public int AppointmentId { get; set; }
        public string PaymentIntentId { get; set; }
        public User User { get; set; }
        public Appointment Appointment { get; set; }

    }
}
