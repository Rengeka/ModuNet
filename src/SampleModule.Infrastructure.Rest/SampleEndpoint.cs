using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleModule.Application;

namespace SampleModule.Infrastructure.Rest;

public static class SampleEndpoint
{
    public static async Task<IResult> Handle(
        [FromServices] ISampleModule module,
        CancellationToken cancellationToken)
    {
        return Results.Ok("Sample");
    }
}