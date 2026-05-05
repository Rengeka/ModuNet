namespace ModuNetWebApp.Weather.Domain.Entities
{
    public class WeatherForecast
    {
        public DateOnly Date { get; init; }

        public int TemperatureC { get; init; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public Summary Summary { get; init; }

        public WeatherForecast()
        {
            Date = DateOnly.FromDateTime(DateTime.UtcNow);
            Summary = new Summary();
            TemperatureC = Random.Shared.Next(-20, 55);
        }
    }
}