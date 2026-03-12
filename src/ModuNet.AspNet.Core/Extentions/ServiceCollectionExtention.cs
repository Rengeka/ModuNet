using Microsoft.Extensions.DependencyInjection;
using ModuNet.Core.Interfaces;
using System.Reflection;

namespace ModuNet.AspNet.Extentions;

public static class ServiceCollectionExtention
{
    public static IServiceCollection AddRequestHandlers(this IServiceCollection services, Assembly assembly)
    {
        services.AddInterfaceImplementations(typeof(IQueryHandler<,>), [assembly]);
        services.AddInterfaceImplementations(typeof(ICommandHandler<>), [assembly]);

        return services;
    }
}