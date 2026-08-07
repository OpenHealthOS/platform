namespace OpenHealthOS.Observability.Tracing;

using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;

public static class TracingExtensions
{
    public static IServiceCollection AddOpenHealthTracing(this IServiceCollection services)
    {
        services.AddOpenTelemetry()
            .WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation()
                .AddConsoleExporter());

        return services;
    }
}
