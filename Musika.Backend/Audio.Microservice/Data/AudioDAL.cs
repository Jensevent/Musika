using Audio.Microservice.Context;
using Audio.Microservice.Model;

namespace Audio.Microservice.Data
{
    public class AudioDAL : IAudioDAL
    {
        private readonly AudioDbContext db;

        public AudioDAL(AudioDbContext db)
        {
            this.db = db;
        }

        public AudioModel AddSong(AudioModel song)
        {
            db.Songs.Add(song);
            db.SaveChanges();
            return song;
        }

        public List<AudioModel> GetSongs() => db.Songs.ToList();


    }
}
