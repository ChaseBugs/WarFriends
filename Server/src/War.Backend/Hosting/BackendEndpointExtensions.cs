using War.Backend.Features.Accounts;
using War.Backend.Features.Battle.Admission;
using War.Backend.Features.Battle.Internal;
using War.Backend.Features.Battle.Queue;
using War.Backend.Features.Health;
using War.Backend.Features.Network;
using War.Backend.Legacy;

namespace War.Backend.Hosting;

/// <summary>Composes feature maps; no request or matchmaking orchestration belongs here.</summary>
public static class BackendEndpointExtensions
{
    public static WebApplication MapBackendEndpoints(this WebApplication app)
    {
        app.MapModernBackendEndpoints();
        app.MapLegacy();
        return app;
    }

    public static WebApplication MapModernBackendEndpoints(this WebApplication app)
    {
        app.MapHealthEndpoints();
        RouteGroupBuilder accounts = app.MapGroup("/v1/accounts").RequireRateLimiting("auth");
        accounts.MapAccountEndpoints();
        RouteGroupBuilder api = app.MapGroup("/v1").RequireRateLimiting("api");
        api.MapPlayerEndpoint();
        api.MapConnectivityEndpoints();
        api.MapBattleAdmissionEndpoints();
        api.MapBattleQueueEndpoints();
        api.MapBattleRematchEndpoints();
        app.MapInternalBattleEndpoints();
        return app;
    }
}
