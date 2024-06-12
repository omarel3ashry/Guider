﻿namespace Guider.Application.UseCases.consultant.Command.CreateConsultant
{
    public class ConsultantCreateOrUpdateDto
    {
        public int Id { get; set; }
        public string Bio { get; set; }
        public float HourlyRate { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public int UserId { get; set; }
        public int SubCategoryId { get; set; }

        // Additional properties from User
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string BankAccount { get; set; }
    }
}