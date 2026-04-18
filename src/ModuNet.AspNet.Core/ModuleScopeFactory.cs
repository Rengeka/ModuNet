using Microsoft.Extensions.DependencyInjection;

namespace ModuNet.AspNet.Core
{
    /// <summary>
    /// Provides a factory for creating dependency injection scopes for modules.
    /// </summary>
    public class ModuleScopeFactory(ServiceProvider serviceProvider) : IModuleScopeFactory
    {
        /// <summary>
        /// Creates a new <see cref="IServiceScope"/> instance.
        /// </summary>
        /// <returns>
        /// A new service scope that can be used to resolve scoped dependencies.
        /// </returns>
        public IServiceScope CreateScope() => serviceProvider.CreateScope();
    }
}