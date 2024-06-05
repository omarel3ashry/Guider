namespace Guider.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PassHash { get; set; }
        public string Image { get; set; }
        public string BankAccount { get; set; }
        public bool IsDeleted { get; set; }

         public IReadOnlyCollection<Transaction> Transactions { get; set; }
    }
}
