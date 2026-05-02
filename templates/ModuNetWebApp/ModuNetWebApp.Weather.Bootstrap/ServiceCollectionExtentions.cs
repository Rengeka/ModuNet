using Microsoft.AspNetCore.Routing;
using ModuNet.AspNet.Rest.Extentions;
using ModuNetWebApp.Weather.Infrastructure.Rest;

namespace ModuNetWebApp.Weather.Bootstrap
{
    public static class ServiceCollectionExtentions
    {
        public static IEndpointRouteBuilder UseWeatherModule(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapEndpointGroups(typeof(GetWeatherEndpoint).Assembly);

            return endpointRouteBuilder;
        }
    }
}