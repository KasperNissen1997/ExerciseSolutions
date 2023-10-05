using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
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

        // Path: /Home/ForecastDetails
        public IActionResult ForecastDetails(string sortOrder, bool goodTimes)
        {
            // ForecastResultDTO forecast = (ForecastResultDTO) TempData["forecastResultDTO"]!;
            ForecastResultDTO forecast = JsonSerializer.Deserialize<ForecastResultDTO>((string) TempData["forecastResultDTO"]!)!;

            if (goodTimes)
                forecast.FilteredDailyWeatherEntries = forecast.DailyWeatherEntries!
                    .Where(entry => entry.WeatherDataEntries!.First().Title.Contains("Clear"))
                    .ToList();
            else
                forecast.FilteredDailyWeatherEntries = forecast.DailyWeatherEntries!;

            // If we are already sorting for any of the below, make it the reverse sort order if it is pressed again.
            ViewBag.DateSortOrder = sortOrder == "date_desc" ? "date_asc" : "date_desc";
            ViewBag.TemperatureSortOrder = sortOrder == "temp_desc" ? "temp_asc" : "temp_desc";
            ViewBag.RainFallSortOrder = sortOrder == "rain_desc" ? "rain_asc" : "rain_desc";
            ViewBag.WindSpeedSortOrder = sortOrder == "windSpeed_desc" ? "windSpeed_asc" : "windSpeed_desc";
            ViewBag.SunriseSortOrder = sortOrder == "sunrise_desc" ? "sunrise_asc" : "sunrise_desc";
            ViewBag.SunsetSortOrder = sortOrder == "sunset_desc" ? "sunset_asc" : "sunset_desc";

            forecast.FilteredDailyWeatherEntries = sortOrder switch
            {
                "date_asc" => forecast.FilteredDailyWeatherEntries!.OrderBy(entry => entry.Date).ToList(),
                "date_desc" => forecast.FilteredDailyWeatherEntries!.OrderByDescending(entry => entry.Date).ToList(),
                "temp_asc" => forecast.FilteredDailyWeatherEntries!.OrderBy(entry => entry.TemperatureData.Day).ToList(),
                "temp_desc" => forecast.FilteredDailyWeatherEntries!.OrderByDescending(entry => entry.TemperatureData.Day).ToList(),
                "rain_asc" => forecast.FilteredDailyWeatherEntries!.OrderBy(entry => entry.RainFall).ToList(),
                "rain_desc" => forecast.FilteredDailyWeatherEntries!.OrderByDescending(entry => entry.RainFall).ToList(),
                "windSpeed_asc" => forecast.FilteredDailyWeatherEntries!.OrderBy(entry => entry.WindSpeed).ToList(),
                "windSpeed_desc" => forecast.FilteredDailyWeatherEntries!.OrderByDescending(entry => entry.WindSpeed).ToList(),
                "sunrise_asc" => forecast.FilteredDailyWeatherEntries!.OrderBy(entry => entry.Sunrise).ToList(),
                "sunrise_desc" => forecast.FilteredDailyWeatherEntries!.OrderByDescending(entry => entry.Sunrise).ToList(),
                "sunset_asc" => forecast.FilteredDailyWeatherEntries!.OrderBy(entry => entry.Sunset).ToList(),
                "sunset_desc" => forecast.FilteredDailyWeatherEntries!.OrderByDescending(entry => entry.Sunset).ToList(),
                _ => forecast.FilteredDailyWeatherEntries!.OrderBy(entry => entry.Date).ToList(),
            };

            TempData["forecastResultDTO"] = JsonSerializer.Serialize(forecast);

            return View(forecast);
            // return View();
        }

        [ActionName("Forecast")]
        public async Task<IActionResult> Forecast(ForecastRequestDTO forecastRequest)
        {
            ForecastResultDTO? forecast = await _httpClient.GetFromJsonAsync<ForecastResultDTO>($"https://localhost:7209/api/Forecast/{forecastRequest.City}?stateCode={forecastRequest.State}&countryCode={forecastRequest.CountryCode}&unitType={forecastRequest.UnitType}");

            if (forecast?.DailyWeatherEntries?.Count == 0)
                return RedirectToAction(nameof(Index));

            forecast!.DailyWeatherEntries!.RemoveRange(forecastRequest.DayCount, forecast.DailyWeatherEntries.Count - (forecastRequest.DayCount + 1));

            string serializedDTO = JsonSerializer.Serialize(forecast);

            if (TempData.ContainsKey("forecastResultDTO"))
                TempData["forecastResultDTO"] = serializedDTO;
            else
                TempData.Add("forecastResultDTO", serializedDTO);

            return RedirectToAction(nameof(ForecastDetails));
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