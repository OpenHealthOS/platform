namespace OpenHealthOS.Gateway.Endpoints;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

public static class GatewayEndpoints
{
    public static IEndpointRouteBuilder MapGatewayEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/gateway", () => Results.Ok(new
        {
            service = "gateway",
        }));

        return endpoints;
    }
}
