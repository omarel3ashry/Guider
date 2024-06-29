using Guider.Domain.Entities;

namespace Guider.Domain.Common
{
    public abstract class Consumer
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? BankAccount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IReadOnlyCollection<Appointment> Appointments { get; set; }
    }
}
