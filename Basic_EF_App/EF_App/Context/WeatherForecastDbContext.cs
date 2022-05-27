using Microsoft.EntityFrameworkCore;

namespace EF_App.Context
{
    public class WeatherForecastDbContext : DbContext
    {
        public DbSet<Model.WeatherForecast> WeatherForecasts { get; set; }
        
        
        
        
        public WeatherForecastDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "";

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
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
