using Newtonsoft.Json;

namespace Models
{
    public class Geolocation
    {
        [JsonProperty("lat")]
        public string Latitude { get; set; }

        [JsonProperty("lng")]
        public string Longitude { get; set; }
    }
}
