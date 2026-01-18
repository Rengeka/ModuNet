namespace ModuNet.Core.Interfaces;

public interface IModule
{
    Task<IResponse> ExecuteCommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken);
    Task<IResponse<TResult>> ExecuteQueryAsync<TQuery, TResult>(TQuery request, CancellationToken cancellationToken);
}