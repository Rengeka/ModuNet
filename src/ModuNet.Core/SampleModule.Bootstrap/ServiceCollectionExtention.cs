using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleApp.Rest;
using SampleModule.Application;
using SampleModule.Infrastructure.Rest;

namespace SampleModule.Bootstrap;

public static class ServiceCollectionExtention
{
    public static IServiceCollection AddSampleModule(this IServiceCollection services, IConfiguration configuration)
    {
        SampleModuleStartup.Startup(configuration);

        services.AddScoped<ISampleModule, SampleModule>();

        return services;
    }

    public static IEndpointRouteBuilder UseSampleModule(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapEndpointGroups(typeof(SampleEndpoint).Assembly);

        return endpointRouteBuilder;
    }
}