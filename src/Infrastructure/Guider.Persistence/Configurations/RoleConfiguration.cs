﻿using Guider.Persistence.Consts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Guider.Persistence.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            List<IdentityRole<int>> roles = new List<IdentityRole<int>>()
            {
                new IdentityRole<int>
                {
                    Id=1,
                    Name = ConstRole.Admin,
                    NormalizedName = ConstRole.Admin.ToUpper()
                },
                new IdentityRole<int>
                {
                    Id=2,
                    Name = ConstRole.Client,
                    NormalizedName = ConstRole.Client.ToUpper()
                },
                new IdentityRole<int>
                {
                    Id=3,
                    Name = ConstRole.Consultant,
                    NormalizedName = ConstRole.Consultant.ToUpper()
                },
            };
            builder.HasData(roles);
        }
    }
}
