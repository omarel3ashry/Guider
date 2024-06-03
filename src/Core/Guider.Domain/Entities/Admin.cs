namespace Guider.Domain.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PassHash { get; set; }
        public string RevenueBankAccount { get; set; }
        public string OnHoldBankAccount { get; set; }

        public IReadOnlyCollection<Transaction> Transactions { get; set; }
    }
}
