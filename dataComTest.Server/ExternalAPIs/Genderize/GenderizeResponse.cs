using System.Globalization;
using System.Text.Json.Serialization;

namespace dataComTest.Server.ExternalAPIs.Genderize
{
    public class GenderizeResponse
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }


        [JsonPropertyName("gender")]
        public required string Gender { get; set; }

        [JsonPropertyName("probability")]
        public required float Probability { get; set; }

        [JsonPropertyName("count")]
        public required int Count { get; set; }

        [JsonPropertyName("country_id")]
        public string? CountryID { get; set; }

        [JsonPropertyName("country_name")]
        public string CountryName => Utils.GetCountryNameByID(CountryID ?? "");
    }
}
