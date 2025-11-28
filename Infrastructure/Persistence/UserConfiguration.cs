using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(c => c.userId);

            builder.Property(c => c.userId)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.passwordHash)
                .IsRequired();

        }

    }
}
