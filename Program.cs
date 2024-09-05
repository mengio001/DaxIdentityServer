using Duende.IdentityServer.EntityFramework.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using QuizTower.IDP;
using QuizTower.IDP.Util;
using Serilog;
using Azure.Identity;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Note: Using AddJsonFile with the 'optional: true' parameter means that if the file does not exist, the application will continue running without it.
    if (builder.Environment.IsDevelopment() || builder.Environment.IsTest())
    {
        builder.Configuration
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
    }
    else
    {
        builder.Configuration
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
    }
    
    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(ctx.Configuration));

    var app = builder
        .ConfigureServices()
        .ConfigurePipeline();

    // seed the configuration database
    SeedData.EnsureSeedData(app);

    app.Run();
}
catch (HostAbortedException)
{
    // eat exception, cfr https://github.com/dotnet/efcore/issues/29809
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}