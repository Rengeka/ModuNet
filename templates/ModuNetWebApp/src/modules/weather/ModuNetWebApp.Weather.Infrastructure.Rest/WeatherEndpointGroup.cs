using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ModuNet.AspNet.Rest;
using ModuNet.AspNet.Rest.Attributes;

namespace ModuNetWebApp.Weather.Infrastructure.Rest
{
    [ApiEndpointGroup(_GROUP_NAME_)]
    public class WeatherEndpointGroup : IEndpointGroup
    {
        public const string _GROUP_NAME_ = "weather";

        public void MapEndpoints(IEndpointRouteBuilder builder)
        {
            builder.MapGet("", GetWeatherEndpoint.Handle).WithTags(_GROUP_NAME_);
        }
    }
}