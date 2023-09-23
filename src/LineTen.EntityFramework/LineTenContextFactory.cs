using LineTen.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LineTen.EntityFramework
{
    public class LineTenContextFactory : IDesignTimeDbContextFactory<LineTenContext>
    {
        public LineTenContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LineTenContext>();

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LineTen;Integrated Security=True;");

            return new LineTenContext(optionsBuilder.Options);
        }
    }
}
