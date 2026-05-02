using Microsoft.AspNetCore.Routing;
using ModuNet.AspNet.Rest.Extentions;
using ModuNetWebApp.Weather.Infrastructure.Rest;

namespace ModuNetWebApp.Weather.Bootstrap
{
    public static class UseWeatherModule
    {
        public static void UseServices(IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapEndpointGroups(typeof(GetWeatherEndpoint).Assembly);
        }
    }
}