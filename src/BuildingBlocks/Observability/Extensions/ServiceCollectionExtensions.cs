namespace OpenHealthOS.Observability.Extensions;

using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using Serilog.Events;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOpenHealthObservability(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .Enrich.WithProperty("ServiceName", "OpenHealthOS.Gateway")
            .WriteTo.Console()
            .CreateLogger();

        services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

        services.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService("OpenHealthOS.Gateway"))
            .WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation()
                .AddConsoleExporter());

        return services;
    }
}
