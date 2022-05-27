namespace EF_App.Data
{
    public interface IWeatherForecastDAL
    {
        List<Model.WeatherForecast> GetWeatherForecast();
    }
}
