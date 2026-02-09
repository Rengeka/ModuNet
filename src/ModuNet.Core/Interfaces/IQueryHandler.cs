namespace ModuNet.Core.Interfaces;

public interface IQueryHandler<TQuery, TResponse>
{
    Task<IResponse<TResponse>> HandleAsync(TQuery query, CancellationToken cancellationToken);
}