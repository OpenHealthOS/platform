namespace OpenHealthOS.ServiceDefaults.Extensions;

using System.Text.Json;
using Asp.Versioning;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOpenHealthServiceDefaults(
        this IServiceCollection services)
    {
        services.AddHealthChecks();

        services.AddProblemDetails();

        return services;
    }

    public static IServiceCollection AddOpenHealthApi(
        this IServiceCollection services)
    {
        services.AddOpenApi();

        services.AddEndpointsApiExplorer();

        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = ApiVersion.Default;
            options.ReportApiVersions = true;
        });

        services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        });

        return services;
    }
}