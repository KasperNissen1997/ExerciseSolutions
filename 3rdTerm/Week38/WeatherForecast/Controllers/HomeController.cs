using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherForecast.Models.DTOs;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Path: /Home/Forecast/{CityName}
        public IActionResult ForecastDetails(ForecastResult forecast, string sortOrder, bool onlyClearSkies)
        {
            if (onlyClearSkies)
                forecast.FilteredDailyWeatherEntries = forecast.DailyWeatherEntries!
                    .Where(entry => entry.WeatherDataEntries!.First().Title.Contains("clear"))
                    .ToList();
            else
                forecast.FilteredDailyWeatherEntries = forecast.DailyWeatherEntries!;

            // If we are already sorting for any of the below, make it the reverse sort order if it is pressed again.
            ViewBag.DateSortOrder = sortOrder == "date_desc" ? "date_asc" : "date_desc";
            ViewBag.TemperatureSortOrder = sortOrder == "temp_desc" ? "temp_asc" : "temp_desc";
            ViewBag.RainFallSortOrder = sortOrder == "rain_desc" ? "rain_asc" : "rain_desc";
            ViewBag.WindSpeedSortOrder = sortOrder == "windSpeed_desc" ? "windSpeed_asc" : "windSpeed_desc";

            forecast.FilteredDailyWeatherEntries = sortOrder switch
            {
                "date_asc" => forecast.FilteredDailyWeatherEntries!.OrderBy(entry => entry.Date).ToList(),
                "date_desc" => forecast.FilteredDailyWeatherEntries!.OrderByDescending(entry => entry.Date).ToList(),
                "temp_asc" => forecast.FilteredDailyWeatherEntries!.OrderBy(entry => entry.TemperatureData).ToList(),
                "temp_desc" => forecast.FilteredDailyWeatherEntries!.OrderByDescending(entry => entry.TemperatureData).ToList(),
                "rain_asc" => forecast.FilteredDailyWeatherEntries!.OrderBy(entry => entry.RainFall).ToList(),
                "rain_desc" => forecast.FilteredDailyWeatherEntries!.OrderByDescending(entry => entry.RainFall).ToList(),
                "windSpeed_asc" => forecast.FilteredDailyWeatherEntries!.OrderBy(entry => entry.WindSpeed).ToList(),
                "windSpeed_desc" => forecast.FilteredDailyWeatherEntries!.OrderByDescending(entry => entry.WindSpeed).ToList(),
                _ => forecast.FilteredDailyWeatherEntries!.OrderBy(entry => entry.Date).ToList(),
            };

            return View(forecast);
        }

        [ActionName("Forecast")]
        public async Task<IActionResult> Forecast(ForecastRequest forecastRequest)
        {
            ForecastResult? forecast = await _httpClient.GetFromJsonAsync<ForecastResult>($"https://localhost:7209/api/Forecast/{forecastRequest.City}?stateCode={forecastRequest.State}&countryCode={forecastRequest.CountryCode}&unitType={forecastRequest.UnitType}");

            if (forecast?.DailyWeatherEntries?.Count == 0)
                return RedirectToAction(nameof(Index));

            forecast!.DailyWeatherEntries!.RemoveRange(forecastRequest.DayCount, forecast.DailyWeatherEntries.Count - (forecastRequest.DayCount + 1));

            return RedirectToAction(nameof(ForecastDetails), forecast);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}