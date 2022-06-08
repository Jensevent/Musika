using DataSharding.Model;
using Microsoft.EntityFrameworkCore;

namespace DataSharding.Context
{
    public class MovieDbContext : DbContext
    {
        // Create connection string variable
        private readonly string _connectionString;


        // Create movie Dataset
        public DbSet<Movie> Movies { get; set; }


        // WHEN a new DbContext is created, save the used connection string
        public MovieDbContext(string connectionString)
        {
            _connectionString = connectionString;

        }

        // Tell the optionsBuilder to use the SQL server with the given connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
