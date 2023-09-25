using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using WeatherForecast.Models.ViewModels;
using WeatherForecast.Utility;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient _httpClient;
        private readonly IApiKey _apiKey;

        public HomeController(ILogger<HomeController> logger, IApiKey apiKey)
        {
            _logger = logger;
            _apiKey = apiKey;

            _httpClient = new();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionName("Forecast")]
        public async Task<IActionResult> PostForecast(ForecastVM forecast)
        {
            GeoCodingCoordSet[]? coordSets = await _httpClient.GetFromJsonAsync<GeoCodingCoordSet[]>($"http://api.openweathermap.org/geo/1.0/direct?q={forecast.RequestVM.CityName},{forecast.RequestVM.StateCode},{forecast.RequestVM.CountryCode}&limit=1&appid={_apiKey.Value}");

            if (coordSets?.Length == 0)
            {
                ModelState.AddModelError("", $"No location named {forecast.RequestVM.CityName} within {forecast.RequestVM.CountryCode} could be found.\n" +
                    "Verify that the correct information has been entered, and try again. If the issue persists, contact your system administrator for more information.");

                return View(nameof(Index));
            }

            ForecastResultVM? forecastResult = await _httpClient.GetFromJsonAsync<ForecastResultVM>($"https://api.openweathermap.org/data/3.0/onecall?lat={coordSets[0].Latitude}&lon={coordSets[0].Longitude}&exclude=current,minutely,hourly,alerts&appid={_apiKey.Value}");

            if (forecastResult == null)
            {
                ModelState.AddModelError("", $"No weather information was found for {forecast.RequestVM.CityName}, {forecast.RequestVM.CountryCode}.\n" +
                    "Contact your system administrator for more information.");

                return View(nameof(Index));
            }

            forecast.ResultVM = forecastResult;

            return View(nameof(Index), forecast);
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