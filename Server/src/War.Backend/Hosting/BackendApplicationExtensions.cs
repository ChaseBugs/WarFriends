using War.Backend.Hosting.Configuration;
using War.Backend.Legacy.State;
using War.Backend.Transport.Http;
using War.Persistence;

namespace War.Backend.Hosting;

public static class BackendApplicationExtensions
{
    public static async Task InitializeBackendAsync(this WebApplication app)
    {
        CancellationToken stopping = app.Lifetime.ApplicationStopping;
        await app.Services.GetRequiredService<AccountStore>().Initialize(stopping);
        await app.Services.GetRequiredService<BattleAllocationStore>().Initialize(stopping);
        await app.Services.GetRequiredService<BattleGrantStore>().Initialize(stopping);
        await app.Services.GetRequiredService<BattleMatchQueueStore>().Initialize(stopping);
        await app.Services.GetRequiredService<BattleResultStore>().Initialize(stopping);
        await app.Services.GetRequiredService<LegacyPlayerStore>().Initialize(stopping);
        await app.Services.GetRequiredService<LegacyBufferStore>().Initialize(stopping);
        await app.Services.GetRequiredService<LegacySquadStore>().Initialize(stopping);
        if (app.Services.GetRequiredService<BackendDeploymentOptions>().Legacy.AllowInsecureHttp)
        {
            app.Logger.LogWarning("Legacy HTTP is enabled for the isolated offline deployment.");
        }
    }

    public static WebApplication UseBackendPipeline(this WebApplication app)
    {
        app.UseMiddleware<BackendRequestMiddleware>();
        app.UseMiddleware<LegacyAuthorityFailureMiddleware>();
        app.UseRateLimiter();
        return app;
    }
}
