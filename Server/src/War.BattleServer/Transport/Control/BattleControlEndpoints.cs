using Microsoft.AspNetCore.Builder;

namespace War.BattleServer.Transport.Control;

public static class BattleControlEndpoints
{
    public static WebApplication MapBattleControlEndpoints(this WebApplication app)
    {
        app.MapWorkerHealthEndpoints();
        app.MapWorkerMatchEndpoints();
        app.MapWorkerResultEndpoints();
        return app;
    }
}
