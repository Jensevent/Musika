using Audio.Microservice.Model;
using Microsoft.EntityFrameworkCore;

namespace Audio.Microservice.Context
{
    public class AudioDbContext : DbContext
    {
        public AudioDbContext(DbContextOptions<AudioDbContext> options) : base(options)
        {
        }

        public DbSet<AudioModel> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "";

            if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

               connectionString = configuration.GetConnectionString("AppDb");
                
            }
            else
            {
                connectionString = Environment.GetEnvironmentVariable("ConnectionStrings:AppDb");
                Console.Write(connectionString);
            }


            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
