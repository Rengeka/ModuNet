using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ModuNet.AspNet.Core.Extentions
{
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
        public static WebApplicationBuilder AddModule<TModuleInterface, TModule>(
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

            return webApplicationBuilder;
        }

        /// <summary>
        /// Adds a module to the routing pipeline, allowing it to configure its own endpoints
        /// using the provided delegate.
        /// </summary>
        /// <param name="endpointRouteBuilder">
        /// The <see cref="IEndpointRouteBuilder"/> to which the module configuration is applied.
        /// </param>
        /// <param name="configureModule">
        /// A delegate that receives the <paramref name="endpointRouteBuilder"/> and can register
        /// endpoints (MapGet, MapPost, MapControllers, MapGrpcService, etc.) belonging to the module.
        /// </param>
        /// <returns>
        /// The same <paramref name="endpointRouteBuilder"/> instance, enabling fluent chaining.
        /// </returns>
        public static IEndpointRouteBuilder UseModule(
            this IEndpointRouteBuilder endpointRouteBuilder,
            Action<IEndpointRouteBuilder> configureModule)
        {
            configureModule(endpointRouteBuilder);
            return endpointRouteBuilder;
        }
    }
}