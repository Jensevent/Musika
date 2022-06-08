using DataSharding.Model;

namespace DataSharding.Data
{
    public interface iMovieDAL
    {
        public Movie GetMovie(string title);
        public Movie AddMovie(Movie movie);

        public string InitDatabase();

    }
}
