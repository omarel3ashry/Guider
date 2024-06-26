namespace Guider.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? BankAccount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public IReadOnlyCollection<Appointment> Appointments { get; set; }
    }
}
