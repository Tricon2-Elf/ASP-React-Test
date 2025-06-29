using System.Globalization;
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

        [JsonPropertyName("country_id")]
        public string? CountryID { get; set; }

        [JsonPropertyName("country_name")]
        public string CountryName
        {
            get
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(CountryID))
                        return new RegionInfo(CountryID).EnglishName;
                    else
                        throw new ArgumentException("Invalid Country Code");
                }
                catch
                {
                    return "Unknown";
                }
            }
        }
    }
}
