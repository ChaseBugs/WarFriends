using War.Persistence;

namespace War.Backend.Features.Health;

public static class HealthEndpoints
{
    public static void MapHealthEndpoints(this WebApplication app)
    {
        app.MapGet("/health/live", () => Results.Ok(new { status = "alive" }));
        app.MapGet("/health/ready", ReadReadyAsync);
    }

    private static async Task<IResult> ReadReadyAsync(AccountStore accounts, CancellationToken cancellationToken)
    {
        await accounts.Ping(cancellationToken);
        return Results.Ok(new { status = "ready" });
    }
}
