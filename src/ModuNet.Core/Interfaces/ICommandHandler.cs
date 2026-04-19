namespace ModuNet.Core.Interfaces
{
    /// <summary>
    /// Defines a handler for processing commands without returning value.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command to handle.</typeparam>
    public interface ICommandHandler<TCommand>
    {
        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command">The command instance to process.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the operation to complete.</param>
        /// <returns>A task representing the asynchronous operation, containing an
        /// <see cref="IResponse{TResponse}"/> with no value.
        /// </returns>
        Task<IResponse> HandleAsync(TCommand command, CancellationToken cancellationToken);
    }
}