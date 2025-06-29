using System.Text.Json.Serialization;

namespace dataComTest.Server.ExternalAPIs.Nationalize
{
    public class NationalizeResponse
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("country")]
        public List<NationalizeCountry>? Countries { get; set; }
    }
}
