﻿using LineTen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LineTen.Infrastructure.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                .HasMaxLength(50);

            builder.Property(c => c.LastName)
                .HasMaxLength(50);

            builder.Property(c => c.Phone)
                .HasMaxLength(50);

            builder.Property(c => c.Email)
                .HasMaxLength(50);

            builder.HasIndex(c => c.Id);
        }
    }
}
