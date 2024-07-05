namespace Guider.Application.UseCases.Admin.Query.GetUnVerifiedConsultantDetailes
{
    public class ConsultantDetailsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public float HourlyRate { get; set; }
        public string SubcatrgoryName { get; set; }
        public List<string> Attachments { get; set; }
    }
}
