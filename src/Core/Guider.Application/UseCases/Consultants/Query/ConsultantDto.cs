namespace Guider.Application.UseCases.Consultants.Query
{
    public class ConsultantDto
    {
        public int Id { get; set; }
        public string Bio { get; set; }
        public float HourlyRate { get; set; }
        public string Image { get; set; }
        public string BankAccount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public float AverageRate { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryName { get; set; }
        public List<ScheduledDto> Schedules { get; set; }
        public List<AppointmentDto> Appointments { get; set; }
    }
}