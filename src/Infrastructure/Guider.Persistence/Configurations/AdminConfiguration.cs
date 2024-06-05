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
    internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.Property(e => e.Email)
                .HasMaxLength(50);
            builder.Property(e => e.PassHash)
                .HasMaxLength(50);
            builder.Property(e => e.RevenueBankAccount)
                .HasMaxLength(100);
            builder.Property(e => e.OnHoldBankAccount)
                .HasMaxLength(100);
        }
    }
}
