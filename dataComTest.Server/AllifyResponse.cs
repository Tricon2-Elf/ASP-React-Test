using System.Globalization;
using System.Text.Json.Serialization;

namespace dataComTest.Server
{
    public class AllifyResponse
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("gender")]
        public required string Gender { get; set; }

        [JsonPropertyName("age")]
        public required int Age { get; set; }

        [JsonPropertyName("country_name")]
        public required string CountryName { get; set; }
    }
}
