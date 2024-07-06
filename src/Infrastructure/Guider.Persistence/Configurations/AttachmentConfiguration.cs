using Guider.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guider.Persistence.Configurations
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.Property(e => e.ImageUrl)
                 .HasMaxLength(100);
            builder.HasOne(e => e.Consultant)
                .WithMany(e => e.Attachments)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
