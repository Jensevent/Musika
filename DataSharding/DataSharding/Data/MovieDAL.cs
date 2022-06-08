using DataSharding.Context;
using DataSharding.Model;
using System.Text.RegularExpressions;

namespace DataSharding.Data
{
    public class MovieDAL : iMovieDAL
    {
        // List of connectionStrings of all databases
        private readonly List<string> _connectionStrings = new List<string>();

        public MovieDAL(IConfiguration configuration)
        {
            // Retrieve all variables in appsettings.json under 'ConnectionStrings'
            var connectionStrings = configuration.GetSection("ConnectionStrings");

            // Foreach variable in the appsettings.json file, add it to the private list
            foreach (var connectionString in connectionStrings.GetChildren())
            {
                _connectionStrings.Add(connectionString.Value);
            }
        }

        // Add a movie to the database
        public Movie AddMovie(Movie movie)
        {
            // Select the database based on the title
            var db = new MovieDbContext(GetConnectionString(movie.Title));
            
            // Add movie to the db
            db.Movies.Add(movie);
            db.SaveChanges();

            // return the added movie
            return movie;
        }

        // Get a movie based on title
        public Movie GetMovie(string title)
        {
            // Select the database based on the title
            var db = new MovieDbContext(GetConnectionString(title));

            // Return the movie with that title
            return db.Movies.FirstOrDefault(x => x.Title == title);
        }


        public string InitDatabase()
        {
            // Loop through all the connected databases
            foreach (var connectionString in _connectionStrings)
            {
                // Connect to the db using the connection string
                var db = new MovieDbContext(connectionString);

                // Ensure the database is removed, and then created and migrated again
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
            
            // Create mockdata
            var movies = new List<Movie>(){
                    new Movie()
                    {
                        Title = "Top Gun: Maverick",
                        Genre = "Action",
                        ReleaseDate = new DateTime(2022, 03, 27)
                    },
                    new Movie()
                    {
                        Title="Doctor Strange in the Multiverse of Madness",
                        Genre="Action",
                        ReleaseDate=new DateTime(2022,04,04)
                    },
                    new Movie()
                    {
                        Title="Split",
                        Genre="Horror",
                        ReleaseDate=new DateTime(2016,09,26)
                    }
                };

            // Loop trough each movie and add it to the correct Db
            foreach(Movie movie in movies)
            {
                // Select the database based on the title
                var db = new MovieDbContext(GetConnectionString(movie.Title));

                // Add the movie to the database and save the db
                db.Movies.Add(movie);
                db.SaveChanges();
            }

            // Return a succes
            return "Great succes";
        }

        private string GetConnectionString(string title)
        {
            // If the title starts with letter A to M (Case insensitive), return true. Else, return false
            Regex regex = new Regex("^[A-Ma-m].{0,}");

            if(regex.IsMatch(title))
            {
                // Connect to Db2
                return _connectionStrings[1];
            }

            //Connect to Db1
            return _connectionStrings[0];
        }
    }
}
