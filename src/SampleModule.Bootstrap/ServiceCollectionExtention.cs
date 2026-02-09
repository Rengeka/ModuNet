using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using ModuNet.AspNet.Extentions;
using ModuNet.Core.Interfaces;
using SampleApp.Rest;
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