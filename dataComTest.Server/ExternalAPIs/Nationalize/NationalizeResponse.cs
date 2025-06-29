using System.Text.Json.Serialization;

namespace dataComTest.Server.ExternalAPIs.Nationalize
{
    public class NationalizeResponse
    {
        [JsonPropertyName("country_id")]
        public string? CountryCode {  get; set; }

        [JsonPropertyName("probability")]
        public float Probability { get; set; }
    }
}
