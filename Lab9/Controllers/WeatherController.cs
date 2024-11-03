using Lab9.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab9.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IActionResult> Index(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                city = "Odessa"; 
            }

            var weather = await _weatherService.GetWeatherAsync(city);
            return View(weather);
        }
    }
}
