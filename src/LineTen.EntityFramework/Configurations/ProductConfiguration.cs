using LineTen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LineTen.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(50);

            builder.Property(c => c.Description)
                .HasMaxLength(50);

            builder.Property(c => c.Sku)
                .HasMaxLength(250);

            builder.HasIndex(c => c.Id);
        }
    }
}
