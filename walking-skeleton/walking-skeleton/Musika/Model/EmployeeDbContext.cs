using Microsoft.EntityFrameworkCore;

namespace Musika.Model
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {

        }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }

       

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("AppDb");
            //var connectionString = Environment.GetEnvironmentVariable("ConnString");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
