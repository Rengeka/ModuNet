using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModuNet.AspNet.Core;

namespace ModuNet.AspNet.Extentions;

public static class ModuleExtensions
{
    public static void AddModule<TModuleInterface, TModule>(
        this WebApplicationBuilder webApplicationBuilder,
        Action<IConfiguration, IServiceCollection> startup)
        where TModule : class, TModuleInterface
        where TModuleInterface : class
    {
        var services = new ServiceCollection();

        startup(webApplicationBuilder.Configuration, services);

        var serviceProvider = services.BuildServiceProvider();
        var moduleScopeFactory = new ModuleScopeFactory(serviceProvider);

        webApplicationBuilder.Services.AddKeyedSingleton<IModuleScopeFactory>(typeof(TModule), moduleScopeFactory);
        webApplicationBuilder.Services.AddTransient<TModuleInterface, TModule>();
    }
}