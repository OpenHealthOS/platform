namespace OpenHealthOS.ServiceDefaults.Extensions;

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
}