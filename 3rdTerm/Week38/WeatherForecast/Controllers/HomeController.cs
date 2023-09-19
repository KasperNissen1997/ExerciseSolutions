using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WeatherForecast.Models;
using WeatherForecast.Utility;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient _httpClient;
        private readonly ApiKey _apiKey;

        public HomeController(ILogger<HomeController> logger, ApiKey apiKey)
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
        public async Task<IActionResult> PostForecast(ForecastRequestVM request)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"http://api.openweathermap.org/geo/1.0/direct?q={request.CityName},{request.StateCode},{request.CountryCode}&limit=1&appid={_apiKey.Value}");
            string responseString = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            LatLonCoordSet? requestCoordSet = JsonSerializer.Deserialize<LatLonCoordSet>(responseString, options);

            if (requestCoordSet == null)
            {
                ModelState.AddModelError("BadGeoCodingRequest", "No location was found with the associated city name, state code and/or country code.");
                return View();
            }

            response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/3.0/onecall?lat={requestCoordSet.Lat}&lon={requestCoordSet.Lon}&exclude=minutely,hourly,alerts&appid={_apiKey.Value}");
            responseString = await response.Content.ReadAsStringAsync();

            return View();

            //LatLonCoordSet? coordSet = await _httpClient.GetFromJsonAsync<LatLonCoordSet>($"http://api.openweathermap.org/geo/1.0/direct?q={request.CityName},{request.StateCode},{request.CountryCode}&limit=1&appid={_apiKey.Value}");

            //if (coordSet == null) 
            //{
            //    ModelState.AddModelError("BadGeoCodingRequest", "No location was found with the associated city name, state code and/or country code.");

            //    return View();
            //}

            //Forecast? forecast = await _httpClient.GetFromJsonAsync<Forecast>($"https://api.openweathermap.org/data/3.0/onecall?lat={coordSet.lat}&lon={coordSet.lon}&exclude=minutely,hourly,alerts&appid={_apiKey.Value}");

            //return View();
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