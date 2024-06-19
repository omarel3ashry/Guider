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
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(e => e.FirstName)
                .HasMaxLength(50);
            builder.Property(e => e.LastName)
                .HasMaxLength(50);
            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(e => e.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
