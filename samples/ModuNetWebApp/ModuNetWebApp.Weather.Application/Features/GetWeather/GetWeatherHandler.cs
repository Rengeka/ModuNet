using ModuNet.Core;
using ModuNet.Core.Interfaces;
using ModuNetWebApp.Weather.Domain.Entities;

namespace ModuNetWebApp.Weather.Application.Features.GetWeather
{
    public class GetWeatherHandler : IQueryHandler<GetWeatherQuery, WeatherForecast>
    {
        public async Task<IResponse<WeatherForecast>> HandleAsync(GetWeatherQuery query, CancellationToken cancellationToken)
        {
            var weatherForecast = new WeatherForecast();
            return weatherForecast.Success();
        }
    }
}