using Microsoft.Extensions.DependencyInjection;
using ModuNet.AspNet.Core;
using ModuNetWebApp.Weather.Application;

namespace ModuNetWebApp.Weather.Bootstrap
{
    public class WeatherModule(
            [FromKeyedServices(typeof(WeatherModule))] 
            IModuleScopeFactory moduleScopeFactory
        ) : BaseModule(moduleScopeFactory), IWeatherModule { }
}