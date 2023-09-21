using Microsoft.EntityFrameworkCore;

namespace LineTen.Infrastructure
{
    public class LineTenContext : DbContext
    {
        public LineTenContext() : base() 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LineTenContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}