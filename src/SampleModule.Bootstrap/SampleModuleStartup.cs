using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModuNet.AspNet.Extentions;
using SampleModule.Infrastructure.Rest;

namespace SampleModule.Bootstrap;

public static class SampleModuleStartup
{
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        // Inject your services here

        services.AddRequestHandlers(typeof(SampleEndpoint).Assembly);
    }
}