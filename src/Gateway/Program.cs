using OpenHealthOS.Hosting.Builders;
using OpenHealthOS.Hosting.Extensions;
using OpenHealthOS.ServiceDefaults.Extensions;

var builder = OpenHealthHost.CreateBuilder(args);

builder.Services.AddOpenHealthHosting();
builder.Services.AddOpenHealthServiceDefaults();

var app = builder.Build();

app.UseOpenHealthPipeline();

app.MapHealthChecks("/health");
app.MapHealthChecks("/ready");

app.Run();
