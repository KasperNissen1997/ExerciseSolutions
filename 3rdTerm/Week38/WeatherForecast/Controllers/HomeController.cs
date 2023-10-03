using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherForecast.Models.ViewModels;

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

        public async Task<IActionResult> ForecastDetails(string city, string? state, string? countryCode, string unitType, int dayCount)
        {
            ForecastResultVM? forecast = await _httpClient.GetFromJsonAsync<ForecastResultVM>($"https://localhost:7209/api/Forecast/{city}?stateCode={state}&countryCode={countryCode}&unitType={unitType}");

            if (forecast?.DailyWeather == null)
                return RedirectToAction(nameof(Index));

            forecast.DailyWeather.RemoveRange(dayCount, forecast.DailyWeather.Count - dayCount);

            return View(forecast);
        }

        [ActionName("Forecast")]
        public IActionResult Forecast(ForecastRequestVM forecast)
        {
            return RedirectToAction(nameof(ForecastDetails), new { forecast.City, forecast.State, forecast.CountryCode, forecast.UnitType, forecast.DayCount });
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