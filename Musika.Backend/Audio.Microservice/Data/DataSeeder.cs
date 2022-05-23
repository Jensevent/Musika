using Audio.Microservice.Context;
using Audio.Microservice.Model;

namespace Audio.Microservice.Data
{
    public class DataSeeder
    {
        private readonly AudioDbContext dbContext;

        public DataSeeder(AudioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Seed()
        {
            if (!dbContext.Songs.Any())
            {
                var songs = new List<AudioModel>()
                {
                    new AudioModel()
                    {
                        songName= "Never Gonna Give You Up",
                        artist = "Rick Ashley",
                        //track= "--"
                    },
                    new AudioModel()
                    {
                        songName= "Demons",
                        artist = "Imagine Dragons",
                        //track= "--"
                    },
                    new AudioModel()
                    {
                        songName= "Kids",
                        artist = "2 Doors Cinema Club",
                        //track= "--"
                    }
                };

                dbContext.Songs.AddRange(songs);
                dbContext.SaveChanges();
            }
        }
    }
}
