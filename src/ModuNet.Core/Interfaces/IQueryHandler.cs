namespace ModuNet.Core.Interfaces
{
    /// <summary>
    /// Defines a handler for processing queries and returning a response.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query to handle.</typeparam>
    /// <typeparam name="TResponse">The type of the response data.</typeparam
    public interface IQueryHandler<TQuery, TResponse>
    {
        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query">The query instance to process.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the operation to complete.</param>
        /// <returns>A task representing the asynchronous operation, containing an
        /// <see cref="IResponse{TResponse}"/> with the query result.
        /// </returns>
        Task<IResponse<TResponse>> HandleAsync(TQuery query, CancellationToken cancellationToken);
    }
}