namespace Guider.Domain.Entities
{
    public class Consultant
    {
        public int Id { get; set; }
        public string Bio { get; set; }
        public float HourlyRate { get; set; }
        public bool isActive { get; set; }
        public bool isVerified { get; set; }
        public int UserId { get; set; }
        public int SubCategoryId { get; set; }

        public User User { get; set; }
        public SubCategory SubCategory { get; set; }
        public IReadOnlyCollection<Schedule> Schedules { get; set; }
        public IReadOnlyCollection<Appointment> Appointments { get; set; }
    }
}
