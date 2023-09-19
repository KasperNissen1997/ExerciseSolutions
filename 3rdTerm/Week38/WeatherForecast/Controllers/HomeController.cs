using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient _httpClient;
        private readonly ApiKey _apiKey;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient, ApiKey apiKey)
        {
            _logger = logger;
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public IActionResult Index()
        {
            ViewData["ImgPath"] = "Testing";
            return View();
        }

        [HttpPost("PostRequest")]
        public async Task<IActionResult> PostRequest(WeatherForecastRequestVM request)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"http://api.openweathermap.org/geo/1.0/direct?q={request.CityName},{request.StateCode},{request.CountryCode}&limit=1&appid={_apiKey.Name}");
            string responseString = await response.Content.ReadAsStringAsync();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}