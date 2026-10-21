using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using War.BattleServer.Transport.Control;

namespace War.BattleServer.Hosting;

public static class BattleHostExtensions
{
    public static WebApplicationBuilder ConfigureBattleHost(this WebApplicationBuilder builder,
        BattleHostStartupOptions startup)
    {
        builder.WebHost.ConfigureKestrel(options =>
        {
            options.ListenLocalhost(startup.ControlPort);
            options.Limits.MaxRequestBodySize = WorkerControlPolicy.MaximumBodyBytes;
        });
        builder.Services.AddBattleHostServices(startup);
        return builder;
    }

    public static IServiceCollection AddBattleHostServices(this IServiceCollection services,
        BattleHostStartupOptions startup)
    {
        services.AddSingleton(startup.Runtime);
        services.AddSingleton(startup.Keys);
        services.AddSingleton(startup.Worker);
        services.AddSingleton(TimeProvider.System);
        services.AddSingleton<WorkerControlAuthentication>();
        services.AddSingleton<NetworkWorker>(provider => new NetworkWorker(startup.Runtime, startup.Keys,
            startup.Worker, provider.GetRequiredService<ILogger<NetworkWorker>>()));
        services.AddHostedService(provider => provider.GetRequiredService<NetworkWorker>());
        return services;
    }
}
