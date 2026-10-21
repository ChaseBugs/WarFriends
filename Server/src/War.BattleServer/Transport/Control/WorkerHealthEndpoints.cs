using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace War.BattleServer.Transport.Control;

public static class WorkerHealthEndpoints
{
    public static void MapWorkerHealthEndpoints(this WebApplication app)
    {
        app.MapGet("/health/live", () => Results.Ok(new { status = "alive" }));
        app.MapGet("/health/ready", ReadReady);
        app.MapGet("/health/metrics", (NetworkWorker worker) => Results.Ok(worker.Metrics));
    }

    private static IResult ReadReady(NetworkWorker worker)
    {
        return worker.IsReady ? Results.Ok(new { status = "ready" }) :
            Results.StatusCode(StatusCodes.Status503ServiceUnavailable);
    }
}
