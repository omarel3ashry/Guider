namespace Guider.Application.UseCases.Clients.Command.UpdateClient
{
    public class UpdateClientDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string BankAccount { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
