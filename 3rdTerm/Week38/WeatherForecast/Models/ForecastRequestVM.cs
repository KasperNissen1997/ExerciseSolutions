namespace WeatherForecast.Models
{
    public class ForecastRequestVM
    {
        public string CityName { get; set; } = string.Empty;
        public string? StateCode { get; set; }
        public string CountryCode { get; set; } = string.Empty;
    }
}
