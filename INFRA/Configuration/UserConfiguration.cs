using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace INFRA.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(u => u.Username).HasMaxLength(50);

            builder.Property(u => u.Password).HasMaxLength(100);

            builder.HasOne(d => d.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId);

            builder.HasOne(s => s.School)
                .WithMany(p => p.Users)
                .HasForeignKey(s => s.SchoolId);
        }
    }
}
