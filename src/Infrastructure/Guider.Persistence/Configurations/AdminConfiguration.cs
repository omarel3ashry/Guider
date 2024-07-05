using Guider.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guider.Persistence.Configurations
{
    internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.Property(e => e.RevenueBankAccount)
                .HasMaxLength(100);
            builder.Property(e => e.OnHoldBankAccount)
                .HasMaxLength(100);
        }
    }
}
