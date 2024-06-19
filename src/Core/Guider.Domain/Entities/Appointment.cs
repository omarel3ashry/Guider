using Guider.Domain.Enums;

namespace Guider.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public float Rate { get; set; }
        public AppointmentState State { get; set; }
        public float Duration { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int ConsultantId { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? ClientSecretKey { get; set; }

        public Client Client { get; set; }
        public Consultant Consultant { get; set; }
        public IReadOnlyCollection<Transaction> Transactions { get; set; }


    }
}
