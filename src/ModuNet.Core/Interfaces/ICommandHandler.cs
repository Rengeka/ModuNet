namespace ModuNet.Core.Interfaces
{
    public interface ICommandHandler<TCommand>
    {
        Task<IResponse> HandleAsync(TCommand query, CancellationToken cancellationToken);
    }
}