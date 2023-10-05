using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.Models.DTOs
{
    public class ForecastRequestDTO
    {
        [DisplayName("City")]
        [Required]
        public string City { get; set; } = string.Empty;
        [DisplayName("State")]
        public string? State { get; set; }
        [DisplayName("Country Code")]
        public string? CountryCode { get; set; }

        [DisplayName("Included amount of Days")]
        public int DayCount { get; set; }
        [DisplayName("Unit Type")]
        public string UnitType { get; set; } = string.Empty;
    }
}
