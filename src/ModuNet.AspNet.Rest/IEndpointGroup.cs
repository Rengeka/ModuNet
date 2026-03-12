using Microsoft.AspNetCore.Routing;

namespace ModuNet.AspNet.Rest;

public interface IEndpointGroup
{
    public void MapEndpoints(IEndpointRouteBuilder builder);
}