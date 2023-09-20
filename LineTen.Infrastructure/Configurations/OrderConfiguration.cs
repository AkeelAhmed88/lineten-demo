﻿using LineTen.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LineTen.Infrastructure.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Status)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.CreatedDate)
                .IsRequired();

            builder.HasOne(c => c.Product)
                .WithOne()
                .HasForeignKey("ProductId");

            builder.HasOne(c => c.Customer)
                .WithOne()
                .HasForeignKey("CustomerId");

            builder.HasIndex(c => c.Id);
        }
    }
}