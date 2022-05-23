using Audio.Microservice.Model;

namespace Audio.Microservice.Data
{
    public interface IAudioDAL
    {
        List<AudioModel> GetSongs();

        AudioModel AddSong(AudioModel song);
    }
}