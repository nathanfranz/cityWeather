using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherSearch.DL.Repositories;
using WeatherSearch.Models;

namespace WeatherSearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(string city)
        {
            if (!string.IsNullOrEmpty(city))
            {
                var weather = WeatherSearchRepository.GetWeatherDataFromCity(city);

                if (weather.main != null)
                {
                    ViewData["CityWeather"] = city + " Weather Data:";
                    ViewData["Temperature"] = "Temperature: " + weather.main.temp + " Kelvin";
                    ViewData["Humidity"] = "Humidity: " + weather.main.humidity + "%";
                    ViewData["WindSpeed"] = "Wind Speed: " + weather.wind.speed + " meter/sec";
                    ViewData["WindDirection"] = "Wind Direction: " + weather.wind.speed + " degrees";
                }
                else
                {
                    ViewData["NoWeatherData"] = "No weather data was found for the city: " + city;
                }
            }

            return View();
        }
    }
}