using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ModuNet.AspNet.Rest;
using ModuNet.AspNet.Rest.Attributes;

namespace SampleModule.Infrastructure.Rest;

[ApiEndpointGroup(GroupName)]
public class SampleEndpointGroup : IEndpointGroup
{
    public const string GroupName = "sample";

    public void MapEndpoints(IEndpointRouteBuilder builder)
    {
        builder.MapGet("", SampleEndpoint.Handle).WithTags(GroupName);
    }
}