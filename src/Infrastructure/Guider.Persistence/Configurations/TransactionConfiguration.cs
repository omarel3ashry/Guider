using Guider.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guider.Persistence.Configurations
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasOne(e => e.Appointment)
                .WithMany(e => e.Transactions)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.User)
                .WithMany(e => e.Transactions)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
