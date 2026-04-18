namespace ModuNet.Core.Interfaces
{
    /// <summary>
    /// Represents a module capable of handling commands and queries, using handlers
    /// registered within it's uniqe dependency injection container.
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Executes a command that performs an action without returning a value.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command to execute.</typeparam>
        /// <param name="command">The command instance.</param>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the operation to complete.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing an <see cref="IResponse"/>
        /// that indicates the result of the command execution.
        /// </returns>
        Task<IResponse> ExecuteCommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken);

        /// <summary>
        /// Executes a query that retrieves data and returns a result.
        /// </summary>
        /// <typeparam name="TQuery">The type of the query to execute.</typeparam>
        /// <typeparam name="TResult">The type of the result returned by the query.</typeparam>
        /// <param name="request">The query instance.</param>
        /// <param name="cancellationToken">
        /// A token to observe while waiting for the operation to complete.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, containing an
        /// <see cref="IResponse{TResult}"/> with the query result.
        /// </returns>
        Task<IResponse<TResult>> ExecuteQueryAsync<TQuery, TResult>(TQuery request, CancellationToken cancellationToken);
    }
}