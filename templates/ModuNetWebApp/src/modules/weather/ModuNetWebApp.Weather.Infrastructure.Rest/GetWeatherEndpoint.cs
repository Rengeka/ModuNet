using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuNetWebApp.Weather.Application;
using ModuNetWebApp.Weather.Application.Features.GetWeather;
using ModuNetWebApp.Weather.Domain.Entities;

namespace ModuNetWebApp.Weather.Infrastructure.Rest
{
    public static class GetWeatherEndpoint
    {
        public static async Task<IResult> Handle(
        [FromServices] IWeatherModule module,
        CancellationToken cancellationToken)
        {
            var query = new GetWeatherQuery();

            var result = await module.ExecuteQueryAsync<GetWeatherQuery, WeatherForecast>(query, cancellationToken);

            if (result.IsSuccessful)
            {
                return Results.Ok(result.Value);
            }

            return Results.InternalServerError();
        }
    }
}