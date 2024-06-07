using Microsoft.AspNetCore.Identity;

namespace Guider.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }

         public IReadOnlyCollection<Transaction> Transactions { get; set; }
    }
}
