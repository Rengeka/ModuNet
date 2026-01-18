using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System.Reflection;

namespace SampleApp.Rest;

public static class EndpointRouteBuilderExtensions
{
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