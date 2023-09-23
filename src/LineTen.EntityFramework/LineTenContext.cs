using LineTen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LineTen.Infrastructure
{
    public class LineTenContext : DbContext
    {
        public LineTenContext(DbContextOptions<LineTenContext> options)
            : base(options) 
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LineTenContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}