namespace OpenHealthOS.Observability.Logging;

using Microsoft.AspNetCore.Builder;
using Serilog;

public static class LoggingExtensions
{
    public static IApplicationBuilder UseOpenHealthRequestLogging(this IApplicationBuilder app)
    {
        return app.UseSerilogRequestLogging(options =>
        {
            options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
            {
                diagnosticContext.Set("TraceId", httpContext.TraceIdentifier);
                diagnosticContext.Set("CorrelationId", httpContext.Items["CorrelationId"] ?? string.Empty);
                diagnosticContext.Set("Path", httpContext.Request.Path);
                diagnosticContext.Set("Method", httpContext.Request.Method);
            };
        });
    }
}
