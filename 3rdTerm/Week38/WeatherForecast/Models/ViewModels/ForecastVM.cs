using System.ComponentModel;

namespace WeatherForecast.Models.ViewModels
{
    public class ForecastVM
    {
        public ForecastRequestVM RequestVM { get; set; }
        public ForecastResultVM ResultVM { get; set; }
    }
}
