using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab9.Models.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherService(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<WeatherInfo> GetWeatherAsync(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={_apiKey}";
            var response = await _httpClient.GetStringAsync(url);
            var weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(response);
            return weatherInfo;
        }
    }
}
