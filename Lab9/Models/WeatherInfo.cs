using Newtonsoft.Json;

namespace Lab9.Models
{
    public class WeatherInfo
    {
        [JsonProperty("main")]
        public MainInfo Main { get; set; }

        [JsonProperty("weather")]
        public WeatherDescription[] Weather { get; set; }

        public class MainInfo
        {
            [JsonProperty("temp")]
            public float Temperature { get; set; }

            [JsonProperty("humidity")]
            public int Humidity { get; set; }
        }

        public class WeatherDescription
        {
            [JsonProperty("description")]
            public string Description { get; set; }
        }
    }
}
