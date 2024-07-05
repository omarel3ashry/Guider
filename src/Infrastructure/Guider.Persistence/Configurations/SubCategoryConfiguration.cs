using Guider.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guider.Persistence.Configurations
{
    internal class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.Property(e => e.Name)
               .HasMaxLength(50);
            builder.HasOne(e => e.Category)
                .WithMany(e => e.SubCategories)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
