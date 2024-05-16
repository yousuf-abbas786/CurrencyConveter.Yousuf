using CC.WebAPIs.Infrastructure;

using Microsoft.AspNetCore.Builder;

namespace CC.WebAPIs.Endpoints
{
    public class WeatherForecasts : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                //.RequireAuthorization()
                .MapGet(GetWeatherForecasts, "abcd");
        }

        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

            var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
            //throw new Exception("asds");
            return forecast;
        }

        public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
        {
            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }
    }
}
