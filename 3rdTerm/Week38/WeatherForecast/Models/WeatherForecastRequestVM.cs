namespace WeatherForecast.Models
{
    public class WeatherForecastRequestVM
    {
        public string CityName { get; set; } = string.Empty;
        public string? StateCode { get; set; }
        public string CountryCode { get; set; } = string.Empty;
    }
}
