using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ModuNet.AspNet.Core.Extentions;

/// <summary>
/// Provides extension methods for registering ModuNet modules into an ASP.NET application.
/// </summary>
public static class ModuleExtensions
{
    /// <summary>
    /// Registers a module with its own isolated service configuration and dependencies.
    /// </summary>
    /// <typeparam name="TModuleInterface">
    /// The module contract (interface) used for dependency injection.
    /// </typeparam>
    /// <typeparam name="TModule">
    /// The concrete module implementation.
    /// </typeparam>
    /// <param name="webApplicationBuilder">
    /// The ASP.NET <see cref="WebApplicationBuilder"/> used to configure the application.
    /// </param>
    /// <param name="startup">
    /// A delegate used to configure module-specific services using the application
    /// <see cref="IConfiguration"/> and a dedicated <see cref="IServiceCollection"/>.
    /// </param>
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

        webApplicationBuilder.Services.AddKeyedSingleton<IModuleScopeFactory>(
            typeof(TModule),
            moduleScopeFactory);

        webApplicationBuilder.Services.AddTransient<TModuleInterface, TModule>();
    }
}