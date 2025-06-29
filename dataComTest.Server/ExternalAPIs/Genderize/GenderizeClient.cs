using System.Text.Json;
using dataComTest.Server.ExternalAPIs.Nationalize;

namespace dataComTest.Server.ExternalAPIs.Genderize
{
    public class GenderizeClient
    {
        private static readonly string endPoint = "https://api.genderize.io/";
        private static readonly HttpClient httpClient = new HttpClient();

        public static async Task<GenderizeResponse?> GetResponseAsync(string name, string country)
        {
            //Check if provided name is empty/Null
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Provided name is blank");

            string url = $"{endPoint}/?name={Uri.EscapeDataString(name)}";

            if(!string.IsNullOrWhiteSpace(country))
            {
                url += $"&country_id={Uri.EscapeDataString(country)}";
            }
            try
            {
                using HttpResponseMessage response = await httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Exception: {response.StatusCode}: {response.ReasonPhrase}");
                }

                string json = await response.Content.ReadAsStringAsync();
                GenderizeResponse result = JsonSerializer.Deserialize<GenderizeResponse>(json) ?? throw new InvalidOperationException("Deserialize returned null");
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return null;
            }
        }
    }
}
