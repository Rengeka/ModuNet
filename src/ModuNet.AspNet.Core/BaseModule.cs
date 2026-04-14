using Microsoft.Extensions.DependencyInjection;
using ModuNet.Core.Interfaces;

namespace ModuNet.AspNet.Core;

/// <summary>
/// Base module class that provides common functionality for creating scopes and handling commands and queries.
/// </summary>
/// <remarks>
/// This class creates a service scope and handles the appropriate requests
/// (<see cref="ICommandHandler{TCommand}"/> and
/// <see cref="IQueryHandler{TQuery, TResult}"/>).
/// </remarks>
/// <param name="moduleScopeFactory"></param>
public abstract class BaseModule(IModuleScopeFactory moduleScopeFactory) : IModule
{
    /// <summary>
    /// Executes a command asynchronously by resolving the corresponding
    /// command handler from the dependency injection container.
    /// </summary>
    /// <typeparam name="TCommand">
    /// The type of the command.
    /// </typeparam>
    /// <param name="command">
    /// The command instance to be executed.
    /// </param>
    /// <param name="cancellationToken">
    /// A token used to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// An <see cref="IResponse"/> representing the result of the command execution.
    /// </returns>
    public async Task<IResponse> ExecuteCommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
    {
        var serviceScope = moduleScopeFactory.CreateScope();

        var commandHandler = serviceScope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

        var response = await commandHandler.HandleAsync(command, cancellationToken);

        return response;
    }

    /// <summary>
    /// Executes a query asynchronously and returns a strongly typed result
    /// by resolving the corresponding query handler from the
    /// dependency injection container.
    /// </summary>
    /// <typeparam name="TQuery">
    /// The type of the query.
    /// </typeparam>
    /// <typeparam name="TResult">
    /// The type of the query result.
    /// </typeparam>
    /// <param name="request">
    /// The query instance to be executed.
    /// </param>
    /// <param name="cancellationToken">
    /// A token used to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// An <see cref="IResponse{TResult}"/> representing the result
    /// of the query execution.
    /// </returns>
    public async Task<IResponse<TResult>> ExecuteQueryAsync<TQuery, TResult>(TQuery request, CancellationToken cancellationToken)
    {
        var serviceScope = moduleScopeFactory.CreateScope();

        var queryHandler = serviceScope.ServiceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();

        var response = await queryHandler.HandleAsync(request, cancellationToken);

        return response;
    }
}