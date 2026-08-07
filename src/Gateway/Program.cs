using OpenHealthOS.Gateway.Endpoints;
using OpenHealthOS.Gateway.Extensions;
using OpenHealthOS.Hosting.Builders;
using OpenHealthOS.Hosting.Extensions;
using OpenHealthOS.ServiceDefaults.Extensions;

var builder = OpenHealthHost.CreateBuilder(args);

builder.Services
    .AddOpenHealthHosting()
    .AddOpenHealthServiceDefaults()
    .AddGateway(builder.Configuration);

var app = builder.Build();

app.UseOpenHealthPipeline();
app.MapGatewayEndpoints();

app.Run();
