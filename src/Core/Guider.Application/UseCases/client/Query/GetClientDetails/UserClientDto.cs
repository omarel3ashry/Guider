﻿namespace Guider.Application.UseCases.client.Query.GetClientDetails
{
    public class UserClientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string BankAccount { get; set; }
    }
}