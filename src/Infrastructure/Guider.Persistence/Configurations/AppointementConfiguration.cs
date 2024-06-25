using Guider.Domain.Entities;
using Guider.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guider.Persistence.Configurations
{
    internal class AppointementConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.Property(e => e.State)
                .HasConversion<string>()
                .HasDefaultValue(AppointmentState.Pending);
            builder.HasOne(e => e.Client)
                .WithMany(e => e.Appointments)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.Consultant)
                .WithMany(e => e.Appointments)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
