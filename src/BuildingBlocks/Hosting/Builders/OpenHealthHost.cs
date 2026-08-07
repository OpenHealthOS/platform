namespace OpenHealthOS.Hosting.Builders;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

public static class OpenHealthHost
{
    public static WebApplicationBuilder CreateBuilder(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();

        return builder;
    }
}