using EF_App.Context;

namespace EF_App.Data
{
    public class DataSeeder
    {
        private readonly WeatherForecastDbContext db;

        public DataSeeder(WeatherForecastDbContext db)
        {
            this.db = db;
        }

        public void Seed()
        {
            if (!db.WeatherForecasts.Any())
            {
                var WeatherForecasts = new List<Model.WeatherForecast>()
                {
                    new Model.WeatherForecast()
                    {
                        date = new DateTime(1995,1,1),
                        temperature = -5,
                        summary = "Freezing"
                    },
                    new Model.WeatherForecast()
                    {
                        date = new DateTime(2000,2,4),
                        temperature = 2,
                        summary = "Chilly"
                    },
                    new Model.WeatherForecast()
                    {
                        date = new DateTime(2004,7,17),
                        temperature = 28,
                        summary = "Hot"
                    },
                    new Model.WeatherForecast()
                    {
                        date = new DateTime(2010,2,17),
                        temperature = 18,
                        summary = "Cloudy with a chance of meatballs"
                    }
                };

                db.WeatherForecasts.AddRange(WeatherForecasts);
                db.SaveChanges();
            }
        }
    }
}
