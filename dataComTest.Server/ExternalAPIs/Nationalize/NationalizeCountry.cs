using System.Globalization;
using System.Text.Json.Serialization;

namespace dataComTest.Server.ExternalAPIs.Nationalize
{
    public class NationalizeCountry
    {
        [JsonPropertyName("country_id")]
        public required string CountryID { get; set; }

        [JsonPropertyName("probability")]
        public required float Probability { get; set; }

        [JsonPropertyName("country_name")]
        public string CountryName => Utils.GetCountryNameByID(CountryID);
    }
}
