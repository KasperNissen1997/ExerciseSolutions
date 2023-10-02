using System.ComponentModel;

namespace WeatherForecastAPI.Models.ViewModels
{
    public class ForecastRequestVM
    {
        [DisplayName("City Name")]
        public string CityName { get; set; } = string.Empty;
        [DisplayName("State Code")]
        public string? StateCode { get; set; }
        [DisplayName("Country Code")]
        public string? CountryCode { get; set; } = string.Empty;
    }
}
