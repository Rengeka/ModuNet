using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModuNet.AspNet.Core;
using ModuNet.Core.Interfaces;

namespace ModuNet.AspNet.Extentions;
/*
public static class ServiceCollectionExtention
{
    public static IServiceCollection AddModule<TModuleInterface, TModule, TStartup>(
            this IServiceCollection services, 
            IConfiguration configuration) 
        where TModuleInterface : IModule
        where TModule : BaseModule
    {
        if (typeof(TModule) == typeof(IModule))
            throw new ArgumentException("IModule cannot be used directly. Use a concrete inherited module type.");


        RecommendationStartup.Startup(configuration);

        services.AddScoped<IRecommendationModule, RecommendationModule>();

        return services;
    }

    public static IEndpointRouteBuilder UseModule<TModule>(this IEndpointRouteBuilder endpointRouteBuilder) where TModule : IModule
    {
        endpointRouteBuilder.MapEndpointGroups(typeof(GetRecommendationEndpoint).Assembly);

        return endpointRouteBuilder;
    }
}*/