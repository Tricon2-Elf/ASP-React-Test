using System.Globalization;
using System.Text.Json.Serialization;

namespace dataComTest.Server
{
    public class AllifyResponse
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("country_id")]
        public string? CountryID { get; set; }

        [JsonPropertyName("country_name")]
        public string CountryName => Utils.GetCountryNameByID(CountryID);
    }
}
