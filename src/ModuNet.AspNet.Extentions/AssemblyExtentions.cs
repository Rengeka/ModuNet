using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ModuNet.AspNet.Extentions;

public record TypeDeclaration(Type Type, Type Interface);

public record TypeWithAttribute<TAttribute>(Type Type, TAttribute Attribute) where TAttribute : Attribute;

public static class AssemblyExtensions
{
    public static IServiceCollection AddInterfaceImplementations(this IServiceCollection services, Type interfaceType, params Assembly[] assemblies)
    {
        var implementations = assemblies.SelectMany(x => x.GetInterfaceImplementations(interfaceType)).ToArray();
        foreach (var mapper in implementations)
        {
            services.AddScoped(mapper.Interface, mapper.Type);
        }

        return services;
    }

    public static TypeDeclaration[] GetInterfaceImplementations(this Assembly assembly, Type interfaceType)
    {
        return assembly.GetTypes()
            .Where(x => !x.IsInterface)
            .SelectMany(x =>
            {
                var typeInterfaces = x.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType)
                    .Select(i => new TypeDeclaration(x, i))
                    .ToArray();

                return typeInterfaces;
            })
            .ToArray();
    }

    public static TypeWithAttribute<TAttribute>[] GetTypesWithAttribute<TAttribute>(this Assembly assembly)
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