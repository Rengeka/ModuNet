using Microsoft.Extensions.DependencyInjection;
using ModuNet.Core.Interfaces;
using System.Reflection;

namespace ModuNet.AspNet.Core.Extentions
{
    /// <summary>
    /// Provides extension methods for registering application services.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers all request handlers (queries and commands) found in the specified assembly.
        /// </summary>
        /// <param name="services">The service collection to add registrations to.</param>
        /// <param name="assembly">The assembly to scan for handler implementations.</param>
        /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
        /// <remarks>
        /// This method scans the provided assembly and registers implementations of:
        /// <list type="bullet">
        /// <item><description><see cref="IQueryHandler{TQuery, TResponse}"/></description></item>
        /// <item><description><see cref="ICommandHandler{TCommand}"/></description></item>
        /// </list>
        /// using the <c>AddInterfaceImplementations</c> helper.
        /// </remarks>
        public static IServiceCollection AddRequestHandlers(
            this IServiceCollection services,
            Assembly assembly)
        {
            services.AddInterfaceImplementations(typeof(IQueryHandler<,>), [assembly]);
            services.AddInterfaceImplementations(typeof(ICommandHandler<>), [assembly]);

            return services;
        }
    }
}