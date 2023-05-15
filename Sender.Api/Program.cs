
using Sender.Api.Infrastructure.StartUpConfigurations;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting host");

    var builder = WebApplication.CreateBuilder(args);

    Log.Information("Configuring web host");
    builder.ConfigureHost();

    Log.Information("Configuring services");
    builder.ConfigureServices();

    var app = builder.Build();
    Log.Information("Configuring middleware");
    app.ConfigureMiddleware();

    Log.Information("Starting app");
    app.Run();
    Log.Information("Stopping host");

    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}
