namespace Guider.Domain.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string RevenueBankAccount { get; set; }
        public string OnHoldBankAccount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public IReadOnlyCollection<Transaction> Transactions { get; set; }
    }
}
