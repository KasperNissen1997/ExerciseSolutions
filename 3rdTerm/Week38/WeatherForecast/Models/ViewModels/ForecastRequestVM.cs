using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.Models.ViewModels
{
    public class ForecastRequestVM
    {
        [DisplayName("City")]
        [Required]
        public string City { get; set; } = string.Empty;
        [DisplayName("State")]
        public string? State { get; set; }
        [DisplayName("Country Code")]
        public string? CountryCode { get; set; }

        [DisplayName("Amount of Days")]
        public int DayCount { get; set; }
        [DisplayName("Unit Type")]
        public string UnitType { get; set; }
    }
}
