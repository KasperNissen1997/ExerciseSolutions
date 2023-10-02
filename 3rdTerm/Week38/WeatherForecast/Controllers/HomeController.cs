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
            forecast.ResultVM = await _httpClient.GetFromJsonAsync<ForecastResultVM>($"https://localhost:7209/api/Forecast/{forecast.RequestVM.CityName}?stateCode={forecast.RequestVM.StateCode}&countryCode={forecast.RequestVM.CountryCode}");

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