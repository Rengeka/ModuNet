using Microsoft.Extensions.DependencyInjection;

namespace ModuNet.AspNet.Core
{
    /// <summary>
    /// Defines a factory for creating dependency injection scopes for modules.
    /// </summary>
    /// <remarks>
    /// It is responsible for creating <see cref="IServiceScope"/> instances,
    /// which provide an isolated lifetime for resolving scoped services.
    /// </remarks>
    public interface IModuleScopeFactory
    {
        /// <summary>
        /// Creates a new <see cref="IServiceScope"/>.
        /// </summary>
        /// <returns>
        /// A service scope that can be used to resolve scoped dependencies.
        /// </returns>
        IServiceScope CreateScope();
    }
}