using System.Globalization;

using AAS.TwinEngine.DataEngine.ApplicationLogic.Exceptions.Infrastructure;
using AAS.TwinEngine.DataEngine.Infrastructure.Monitoring;
using AAS.TwinEngine.DataEngine.Infrastructure.Providers.PluginDataProvider.Services;
using AAS.TwinEngine.DataEngine.ServiceConfiguration;

using Asp.Versioning;

using Serilog;

namespace AAS.TwinEngine.DataEngine;

public class Program
{
    private const double ApiVersion = 1.0;
    private const string ApiTitle = "DataEngine API";

    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        _ = builder.Host.UseSerilog();
        builder.ConfigureLogging(builder.Configuration);
        builder.ConfigureCorsServices();
        _ = builder.Services.AddHealthChecks().AddCheck<PluginManifestHealthCheck>("system_health");

        _ = builder.Services.AddHttpContextAccessor();
        builder.Services.ConfigureInfrastructure(builder.Configuration);
        builder.Services.ConfigureApplication(builder.Configuration);
        _ = builder.Services.AddAuthorization();

        _ = builder.Services.AddControllers();

        _ = builder.Services.AddEndpointsApiExplorer();
        _ = builder.Services.AddOpenApiDocument(settings =>
        {
            settings.DocumentName = ApiVersion.ToString("F1", CultureInfo.InvariantCulture);
            settings.Title = ApiTitle;
        });

        _ = builder.Services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(ApiVersion);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = new HeaderApiVersionReader("api-version");
        })
        .AddMvc();

        var app = builder.Build();

        _ = app.MapHealthChecks("/healthz");

        using (var scope = app.Services.CreateScope())
        {
            var pluginManifestHealthStatus = scope.ServiceProvider.GetRequiredService<IPluginManifestHealthStatus>();
            try
            {
                var pluginManifestInitializer = scope.ServiceProvider.GetRequiredService<PluginManifestInitializer>();
                await pluginManifestInitializer.InitializeAsync(CancellationToken.None).ConfigureAwait(false);
            }
            catch (MultiPluginConflictException)
            {
                pluginManifestHealthStatus.IsHealthy = false;
            }
        }

        _ = app.UseExceptionHandler();
        _ = app.UseHttpsRedirection();
        _ = app.UseAuthorization();
        app.UseCorsServices();
        _ = app.UseOpenApi(c => c.PostProcess = (d, _) => d.Servers.Clear());
        _ = app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/{ApiVersion:F1}/swagger.json", ApiTitle));
        _ = app.MapControllers();

        await app.RunAsync().ConfigureAwait(false);
    }
}
