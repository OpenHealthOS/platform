namespace OpenHealthOS.ServiceDefaults.Extensions;

using Microsoft.AspNetCore.Builder;

public static class ApplicationBuilderExtensions
{
    public static WebApplication UseOpenHealthPipeline(
        this WebApplication app)
    {
        app.UseExceptionHandler();

        return app;
    }
}