using Guider.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
