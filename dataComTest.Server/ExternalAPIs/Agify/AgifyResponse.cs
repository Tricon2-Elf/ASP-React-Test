using System.Globalization;
using System.Text.Json.Serialization;

namespace dataComTest.Server.ExternalAPIs.Agify
{
    public class AgifyResponse
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("age")]
        public int? Age { get; set; } //Age can be recieved as null if name isn't in their data

        [JsonPropertyName("count")]
        public required int Count { get; set; }

        [JsonPropertyName("country_id")]
        public string?  CountryID { get; set; }

        [JsonPropertyName("country_name")]
        public string CountryName => Utils.GetCountryNameByID(CountryID ?? "");
    }
}
