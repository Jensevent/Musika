namespace EF_App.Model
{
    public class WeatherForecast
    {
        public int id { get; set; }
        public DateTime date { get; set; }

        public int temperature { get; set; }

        public string? summary { get; set; }
    }
}
