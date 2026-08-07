namespace OpenHealthOS.Observability.Correlation;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

public static class CorrelationExtensions
{
    public static IApplicationBuilder UseOpenHealthCorrelation(this IApplicationBuilder app)
    {
        return app.Use(async (context, next) =>
        {
            var correlationId = context.Request.Headers["X-Correlation-ID"].ToString();
            if (string.IsNullOrWhiteSpace(correlationId))
            {
                correlationId = Guid.NewGuid().ToString("N");
            }

            context.Items["CorrelationId"] = correlationId;
            context.Response.Headers["X-Correlation-ID"] = correlationId;

            await next();
        });
    }
}
