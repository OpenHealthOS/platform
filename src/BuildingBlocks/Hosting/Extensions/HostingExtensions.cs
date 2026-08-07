namespace OpenHealthOS.Hosting.Extensions;

using Microsoft.Extensions.DependencyInjection;

public static class HostingExtensions
{
    public static IServiceCollection AddOpenHealthHosting(
        this IServiceCollection services)
    {
        return services;
    }
}