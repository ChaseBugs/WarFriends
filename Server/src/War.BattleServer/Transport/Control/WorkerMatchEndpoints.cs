using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace War.BattleServer.Transport.Control;

public static class WorkerMatchEndpoints
{
    public static void MapWorkerMatchEndpoints(this WebApplication app)
    {
        app.MapPost("/internal/matches", RegisterAsync);
        app.MapPost("/internal/matches/reconnect", ReconnectAsync);
        app.MapPost("/internal/matches/cancel", CancelAsync);
    }

    private static async Task<IResult> RegisterAsync(HttpContext context, NetworkWorker worker,
        WorkerControlAuthentication authentication)
    {
        byte[]? body = await WorkerControlBody.ReadAsync(context, WorkerControlPolicy.MaximumBodyBytes);
        if (body == null)
        {
            return Results.StatusCode(StatusCodes.Status413PayloadTooLarge);
        }
        if (!authentication.IsAuthorized(context, body, WorkerControlPolicy.MatchDomain))
        {
            return Results.Unauthorized();
        }

        MatchManifest manifest;
        try
        {
            manifest = MatchManifest.Parse(body);
        }
        catch (InvalidDataException)
        {
            return Results.BadRequest(new { code = "invalid-manifest" });
        }
        MatchRegistrationResult result = await worker.RegisterMatch(manifest, context.RequestAborted);
        return WorkerGrantProjection.Registration(result, manifest);
    }

    private static async Task<IResult> ReconnectAsync(HttpContext context, NetworkWorker worker,
        WorkerControlAuthentication authentication)
    {
        byte[]? body = await WorkerControlBody.ReadAsync(context, WorkerControlPolicy.ReconnectBodyBytes);
        if (body == null)
        {
            return Results.StatusCode(StatusCodes.Status413PayloadTooLarge);
        }
        if (!authentication.IsAuthorized(context, body, WorkerControlPolicy.MatchDomain))
        {
            return Results.Unauthorized();
        }

        ReconnectControlRequest request;
        try
        {
            request = WorkerMatchRequests.ReadReconnect(body);
        }
        catch (Exception failure) when (failure is JsonException or InvalidDataException)
        {
            return Results.BadRequest(new { code = "invalid-reconnect" });
        }
        MatchRegistrationResult result = await worker.RegisterReconnect(request.MatchId, request.PlayerId,
            request.RequestId, context.RequestAborted);
        return WorkerGrantProjection.Reconnect(result);
    }

    private static async Task<IResult> CancelAsync(HttpContext context, NetworkWorker worker,
        WorkerControlAuthentication authentication)
    {
        byte[]? body = await WorkerControlBody.ReadAsync(context, WorkerControlPolicy.CancellationBodyBytes);
        if (body == null)
        {
            return Results.StatusCode(StatusCodes.Status413PayloadTooLarge);
        }
        if (!authentication.IsAuthorized(context, body, WorkerControlPolicy.MatchDomain))
        {
            return Results.Unauthorized();
        }

        CancelControlRequest request;
        try
        {
            request = WorkerMatchRequests.ReadCancellation(body);
        }
        catch (Exception failure) when (failure is JsonException or InvalidDataException)
        {
            return Results.BadRequest(new { code = "invalid-cancel" });
        }
        MatchRegistrationResult result = request.ManifestHash == null
            ? await worker.CancelMatchBeforeStart(request.MatchId, context.RequestAborted)
            : await worker.CancelMatchBeforeStart(request.MatchId, request.ManifestHash, context.RequestAborted);
        return result.Code switch
        {
            "cancelled-before-start" or "already-cancelled" =>
                Results.Ok(new { code = result.Code, matchId = request.MatchId, manifestHash = result.ManifestHash }),
            "control-capacity" or "control-unavailable" =>
                Results.Json(new { code = result.Code }, statusCode: StatusCodes.Status503ServiceUnavailable),
            _ => Results.Conflict(new { code = result.Code })
        };
    }
}
