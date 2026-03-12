using Microsoft.AspNetCore.Routing;
using ModuNet.AspNet.Rest.Extentions;
using SampleModule.Infrastructure.Rest;

namespace SampleModule.Bootstrap;

public static class ServiceCollectionExtention
{
    public static IEndpointRouteBuilder UseSampleModule(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapEndpointGroups(typeof(SampleEndpoint).Assembly);

        return endpointRouteBuilder;
    }
}