using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ModuNet.AspNet.Core.Extentions
{
    /// <summary>
    /// Represents a mapping between an implementation type and its interface.
    /// </summary>
    public record TypeDeclaration(Type Type, Type Interface);

    /// <summary>
    /// Represents a type that is decorated with a specific attribute.
    /// </summary>
    /// <typeparam name="TAttribute">The attribute type.</typeparam>
    public record TypeWithAttribute<TAttribute>(Type Type, TAttribute Attribute)
        where TAttribute : Attribute;

    /// <summary>
    /// Provides extension methods for scanning assemblies and registering types.
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Registers all implementations of a given generic interface from the specified assemblies.
        /// </summary>
        /// <param name="services">The service collection to register implementations into.</param>
        /// <param name="interfaceType">The open generic interface type to search for (e.g. typeof(IHandler&lt;&gt;)).</param>
        /// <param name="assemblies">The assemblies to scan for implementations.</param>
        /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
        /// <remarks>
        /// All discovered implementations are registered with a scoped lifetime.
        /// </remarks>
        public static IServiceCollection AddInterfaceImplementations(
            this IServiceCollection services,
            Type interfaceType,
            params Assembly[] assemblies)
        {
            var implementations = assemblies
                .SelectMany(x => x.GetInterfaceImplementations(interfaceType))
                .ToArray();

            foreach (var mapper in implementations)
            {
                services.AddScoped(mapper.Interface, mapper.Type);
            }

            return services;
        }

        /// <summary>
        /// Retrieves all implementations of a given generic interface within the assembly.
        /// </summary>
        /// <param name="assembly">The assembly to scan.</param>
        /// <param name="interfaceType">The open generic interface type.</param>
        /// <returns>
        /// An array of <see cref="TypeDeclaration"/> representing implementation-to-interface mappings.
        /// </returns>
        public static TypeDeclaration[] GetInterfaceImplementations(
            this Assembly assembly,
            Type interfaceType)
        {
            return assembly.GetTypes()
                .Where(x => !x.IsInterface && !x.IsAbstract)
                .SelectMany(x =>
                {
                    var typeInterfaces = x.GetInterfaces()
                        .Where(i =>
                            i.IsGenericType &&
                            i.GetGenericTypeDefinition() == interfaceType)
                        .Select(i => new TypeDeclaration(x, i))
                        .ToArray();

                    return typeInterfaces;
                })
                .ToArray();
        }

        /// <summary>
        /// Retrieves all non-abstract classes in the assembly that are decorated with a specific attribute.
        /// </summary>
        /// <typeparam name="TAttribute">The attribute type to search for.</typeparam>
        /// <param name="assembly">The assembly to scan.</param>
        /// <returns>
        /// An array of <see cref="TypeWithAttribute{TAttribute}"/> containing matching types and their attributes.
        /// </returns>
        public static TypeWithAttribute<TAttribute>[] GetTypesWithAttribute<TAttribute>(
            this Assembly assembly)
            where TAttribute : Attribute
        {
            var types = assembly.GetTypes()
                .Where(x => x is { IsClass: true, IsAbstract: false })
                .Select(x => new
                {
                    Type = x,
                    Attribute = x.GetCustomAttribute<TAttribute>()
                })
                .Where(x => x.Attribute is not null)
                .Select(x => new TypeWithAttribute<TAttribute>(x.Type, x.Attribute!))
                .ToArray();

            return types;
        }
    }
}