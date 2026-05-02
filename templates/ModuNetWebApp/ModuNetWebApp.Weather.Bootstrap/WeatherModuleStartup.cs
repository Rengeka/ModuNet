using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModuNet.AspNet.Extentions;
using ModuNetWebApp.Weather.Application.Features.GetWeather;

namespace ModuNetWebApp.Weather.Bootstrap
{
    public static class WeatherModuleStartup
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            // Inject your services here

            services.AddRequestHandlers(typeof(GetWeatherHandler).Assembly);
        }
    }
}