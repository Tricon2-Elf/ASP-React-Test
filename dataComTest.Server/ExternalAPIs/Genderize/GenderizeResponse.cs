using System.Text.Json.Serialization;

namespace dataComTest.Server.ExternalAPIs.Genderize
{
    public class GenderizeResponse
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        [JsonPropertyName("probability")]
        public float Probability { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
