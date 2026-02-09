using Microsoft.AspNetCore.Routing;

namespace SampleApp.Rest;

public interface IEndpointGroup
{
    public void MapEndpoints(IEndpointRouteBuilder builder);
}