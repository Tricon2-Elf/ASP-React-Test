using System.Globalization;
using System.Text.Json.Serialization;

namespace dataComTest.Server.ExternalAPIs.Nationalize
{
    public class NationalizeCountry
    {
        [JsonPropertyName("country_id")]
        public string? CountryID { get; set; }

        [JsonPropertyName("probability")]
        public float Probability { get; set; }

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
