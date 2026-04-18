using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using ModuNet.AspNet.Rest.Attributes;
using System.Reflection;

namespace ModuNet.AspNet.Rest.Extentions
{
    /// <summary>
    /// This class provides extension methods for mapping API endpoint groups
    /// discovered via reflection.
    /// </summary>
    /// <remarks>
    /// This extension scans the specified assembly for concrete types
    /// implementing <see cref="IEndpointGroup"/> and decorated with
    /// <see cref="ApiEndpointGroupAttribute"/>. Each discovered group is
    /// instantiated and mapped to the endpoint routing system.
    /// </remarks>
    public static class EndpointRouteBuilderExtensions
    {
        /// <summary>
        /// Discovers and maps all endpoint groups defined in the specified assembly.
        /// </summary>
        /// <param name="builder">
        /// The <see cref="IEndpointRouteBuilder"/> used to configure endpoint routing.
        /// </param>
        /// <param name="assembly">
        /// The assembly to scan for endpoint group implementations.
        /// </param>
        /// <remarks>
        /// Only non-abstract classes implementing <see cref="IEndpointGroup"/> and
        /// decorated with <see cref="ApiEndpointGroupAttribute"/> are considered.
        /// Each group is instantiated using its parameterless constructor.
        /// </remarks>
        public static void MapEndpointGroups(this IEndpointRouteBuilder builder, Assembly assembly)
        {
            var endpointGroupTypes = assembly.GetTypes()
                .Where(t =>
                    typeof(IEndpointGroup).IsAssignableFrom(t) &&
                    t is { IsClass: true, IsAbstract: false } &&
                    t.GetCustomAttribute<ApiEndpointGroupAttribute>() != null
                );

            foreach (var type in endpointGroupTypes)
            {
                var attribute = type.GetCustomAttribute<ApiEndpointGroupAttribute>();
                if (attribute == null) continue;

                var instance = (IEndpointGroup)Activator.CreateInstance(type)!;

                var groupBuilder = builder.MapGroup(attribute.Route);
                instance.MapEndpoints(groupBuilder);
            }
        }
    }
}