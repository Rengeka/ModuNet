using Microsoft.AspNetCore.Routing;

namespace ModuNet.AspNet.Rest;

/// <summary>
/// Defines a contract for grouping and registering HTTP endpoints.
/// </summary>
public interface IEndpointGroup
{
    /// <summary>
    /// Registers endpoints using the provided route builder.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="IEndpointRouteBuilder"/> used to configure application routes.
    /// </param>
    public void MapEndpoints(IEndpointRouteBuilder builder);
}