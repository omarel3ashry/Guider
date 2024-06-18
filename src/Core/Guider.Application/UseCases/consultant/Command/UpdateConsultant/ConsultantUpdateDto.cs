namespace Guider.Application.UseCases.consultant.Command.UpdateConsultant
{
    public class ConsultantUpdateDto
    {
        public int Id { get; set; }
        public string Bio { get; set; }
        public float HourlyRate { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public int UserId { get; set; }
        public int SubCategoryId { get; set; }
        public string Email { get; set; }

        // Additional properties from User
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
     
    }
}