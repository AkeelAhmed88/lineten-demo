using System.Data.Entity;

namespace LineTen.Infrastructure
{
    public class LineTenContext : DbContext
    {
        public LineTenContext() : base("LineTen") 
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(LineTenContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}