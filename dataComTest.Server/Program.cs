using dataComTest.Server.ExternalAPIs.Agify;
using dataComTest.Server.ExternalAPIs.Genderize;
using dataComTest.Server.ExternalAPIs.Nationalize;

namespace dataComTest.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();


            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapGet("/allify", async (string? name) =>
            {
                //Make sure the name provided from the frontend is valid
                if (string.IsNullOrWhiteSpace(name))
                    return Results.BadRequest("Missing or empty 'name' query parameter.");


                var nationData = await NationalizeClient.GetResponseAsync(name);
                //Get the Couuntry ID returned from the nationlize client to provide to both the Gender and Age clients.
                string countryID = nationData?.Countries?.FirstOrDefault()?.CountryID ?? "";

                //Capture both Gender and Age data providing name and country
                var genderData = await GenderizeClient.GetResponseAsync(name, countryID);
                var ageData = await AgifyClient.GetResponseAsync(name, countryID);

                //Check if data from age and gender API have data
                if (ageData == null || genderData == null)
                {
                    return Results.Problem("Failed to fetch All API data.");
                }
                //Generate response to send to frontend
                var result = new AllifyResponse
                {
                    Name = name,
                    Age = ageData.Age ?? 0,
                    Gender = genderData.Gender ?? "",
                    CountryName = Utils.GetCountryNameByID(countryID)
                };
                return Results.Ok(result);
            });



            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
