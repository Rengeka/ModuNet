using Microsoft.Extensions.DependencyInjection;
using ModuNet.Core.Interfaces;

namespace ModuNet.AspNet.Core;


public abstract class BaseModule : IModule
{
    public async Task<IResponse> ExecuteCommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
    {
        var serviceScope = CreateScope();

        var commandHandler = serviceScope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

        var response = await commandHandler.HandleAsync(command, cancellationToken);

        return response;
    }

    public async Task<IResponse<TResult>> ExecuteQueryAsync<TQuery, TResult>(TQuery request, CancellationToken cancellationToken)
    {
        var serviceScope = CreateScope();

        var queryHandler = serviceScope.ServiceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();

        var response = await queryHandler.HandleAsync(request, cancellationToken);

        return response;
    }

    protected abstract IServiceScope CreateScope();
}