using System.Text.Json;

namespace dataComTest.Server.ExternalAPIs.Nationalize
{
    public class NationalizeClient
    {

        private static string endPoint = "https://api.nationalize.io/";
        private static HttpClient httpClient = new HttpClient();

        public static async Task<NationalizeResponse?> GetResponseAsync(string name)
        {
            //Check if provided name is empty/Null
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Provided name is blank");

            //Generate url from https://api.nationalize.io/?name=johnson
            string url = $"https://api.nationalize.io/?name={Uri.EscapeDataString(name)}";

            try
            {
                using var response = await httpClient.GetAsync(url);

                if(!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Exception: {response.StatusCode}: {response.ReasonPhrase}");
                }

                string json = await response.Content.ReadAsStringAsync();
                NationalizeResponse result = JsonSerializer.Deserialize<NationalizeResponse>(json) ?? throw new InvalidOperationException("Deserialize returned null");
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
