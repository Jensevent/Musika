using EF_App.Context;

namespace EF_App.Data
{
    public class WeatherForecastDAL : IWeatherForecastDAL
    {
        private readonly WeatherForecastDbContext db;

        public WeatherForecastDAL(WeatherForecastDbContext db)
        {
            this.db = db;
        }
        List<Model.WeatherForecast> IWeatherForecastDAL.GetWeatherForecast()
        {
            return db.WeatherForecasts.ToList();
        }
    }
}
