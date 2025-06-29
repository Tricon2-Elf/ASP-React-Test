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

            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            });


            app.MapGet("/nation", async (string? name) =>
            {
                if (string.IsNullOrWhiteSpace(name))
                    return Results.BadRequest("Missing or empty 'name' query parameter.");
                var result = await NationalizeClient.GetResponseAsync(name);

                return result is not null
                    ? Results.Ok(result)
                    : Results.Problem("Failed to fetch nationalization data.");
            });

            app.MapGet("/allify", async (string? name) =>
            {
                if (string.IsNullOrWhiteSpace(name))
                    return Results.BadRequest("Missing or empty 'name' query parameter.");


                var nationData = await NationalizeClient.GetResponseAsync(name);
                string? countryID = nationData?.Countries?[0].CountryID;
                var genderData = await GenderizeClient.GetResponseAsync(name, countryID);
                var ageData = await AgifyClient.GetResponseAsync(name, countryID);
                var result = new AllifyResponse
                {
                    Name = name,
                    Age = ageData.Age,
                    Gender = genderData.Gender,
                    CountryID = countryID
                };
                return result is not null
                    ? Results.Ok(result)
                    : Results.Problem("Failed to fetch All API data.");
            });



            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
