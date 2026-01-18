using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModuNet.AspNet.Extentions;
using ModuNet.Core.Interfaces;
using SampleModule.Infrastructure.Rest;

namespace SampleModule.Bootstrap;

public static class SampleModuleStartup
{
    public static void Startup(IConfiguration configuration)
    {
        var services = new ServiceCollection();

        // Inject your services here

        services.AddRequestHandlers();

        var serviceProvider = services.BuildServiceProvider();
        SampleModuleCompositionRoot.SetProvider(serviceProvider);
    }

    public static IServiceCollection AddRequestHandlers(this IServiceCollection services)
    {
        var assembly = typeof(SampleEndpoint).Assembly;

        services.AddInterfaceImplementations(typeof(IQueryHandler<,>), [assembly]);
        services.AddInterfaceImplementations(typeof(ICommandHandler<>), [assembly]);

        return services;
    }
}