namespace DataSharding.Model
{
    public class Movie
    {
        // PRIMARY KEY
        public int Id { get; set; }

        // COLUMNS
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
    }
}
