namespace OpenHealthOS.Observability.Metrics;

using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Metrics;

public static class MetricsExtensions
{
    public static IServiceCollection AddOpenHealthMetrics(this IServiceCollection services)
    {
        services.AddOpenTelemetry()
            .WithMetrics(metrics => metrics
                .AddAspNetCoreInstrumentation()
                .AddConsoleExporter());

        return services;
    }
}
