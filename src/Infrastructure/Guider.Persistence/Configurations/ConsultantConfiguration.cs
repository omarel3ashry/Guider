using Guider.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guider.Persistence.Configurations
{
    internal class ConsultantConfiguration : IEntityTypeConfiguration<Consultant>
    {
        public void Configure(EntityTypeBuilder<Consultant> builder)
        {
            builder.Property(e => e.Bio)
                .HasMaxLength(300);
            builder.Property(e => e.IsVerified)
                .HasDefaultValue(false);
            builder.Property(e => e.IsActive)
                .HasDefaultValue(true);
            builder.HasOne(e => e.SubCategory)
                .WithMany(e => e.Consultants)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(e => e.Image)
               .HasMaxLength(100);
            builder.Property(e => e.BankAccount)
                .HasMaxLength(100);
        }
    }
}
