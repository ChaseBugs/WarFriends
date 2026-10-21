using System.Text.Json;
using Google.Protobuf;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace War.BattleServer.Transport.Control;

public static class WorkerResultEndpoints
{
    public static void MapWorkerResultEndpoints(this WebApplication app)
    {
        app.MapPost("/internal/results/poll", PollAsync);
        app.MapPost("/internal/results/find", FindAsync);
        app.MapPost("/internal/results/ack", AcknowledgeAsync);
    }

    private static async Task<IResult> PollAsync(HttpContext context, NetworkWorker worker,
        WorkerControlAuthentication authentication)
    {
        byte[]? body = await WorkerControlBody.ReadAsync(context, WorkerControlPolicy.ResultPollBodyBytes);
        if (body == null)
        {
            return Results.StatusCode(StatusCodes.Status413PayloadTooLarge);
        }
        if (!authentication.IsAuthorized(context, body, WorkerControlPolicy.ResultPollDomain))
        {
            return Results.Unauthorized();
        }
        if (!body.AsSpan().SequenceEqual("{}"u8))
        {
            return Results.BadRequest(new { code = "invalid-result-poll" });
        }

        var rows = worker.Outbox.PendingPage().Select(evidence => new
        {
            matchId = evidence.Snapshot.MatchId,
            digest = evidence.Digest,
            snapshot = Convert.ToBase64String(evidence.Snapshot.ToByteArray())
        }).ToArray();
        return Results.Ok(new { results = rows });
    }

    private static async Task<IResult> FindAsync(HttpContext context, NetworkWorker worker,
        WorkerControlAuthentication authentication)
    {
        byte[]? body = await WorkerControlBody.ReadAsync(context, WorkerControlPolicy.ResultReferenceBodyBytes);
        if (body == null)
        {
            return Results.StatusCode(StatusCodes.Status413PayloadTooLarge);
        }
        if (!authentication.IsAuthorized(context, body, WorkerControlPolicy.ResultFindDomain))
        {
            return Results.Unauthorized();
        }

        ResultReferenceRequest request;
        try
        {
            request = WorkerResultRequests.ReadLookup(body);
        }
        catch (Exception failure) when (failure is JsonException or InvalidDataException)
        {
            return Results.BadRequest(new { code = "invalid-result-lookup" });
        }

        try
        {
            var evidence = worker.Outbox.FindEvidence(request.MatchId, request.Proof);
            return evidence == null
                ? Results.NotFound(new { code = "missing" })
                : Results.Ok(new
                {
                    matchId = evidence.Snapshot.MatchId, digest = evidence.Digest,
                    snapshot = Convert.ToBase64String(evidence.Snapshot.ToByteArray())
                });
        }
        catch (Exception failure) when (failure is JsonException or ArgumentException)
        {
            return Results.BadRequest(new { code = "invalid-result-lookup" });
        }
        catch (InvalidDataException)
        {
            return Results.Conflict(new { code = "terminal-authority-conflict" });
        }
    }

    private static async Task<IResult> AcknowledgeAsync(HttpContext context, NetworkWorker worker,
        WorkerControlAuthentication authentication)
    {
        byte[]? body = await WorkerControlBody.ReadAsync(context, WorkerControlPolicy.ResultReferenceBodyBytes);
        if (body == null)
        {
            return Results.StatusCode(StatusCodes.Status413PayloadTooLarge);
        }
        if (!authentication.IsAuthorized(context, body, WorkerControlPolicy.ResultAckDomain))
        {
            return Results.Unauthorized();
        }

        ResultReferenceRequest request;
        try
        {
            request = WorkerResultRequests.ReadAcknowledgement(body);
        }
        catch (Exception failure) when (failure is JsonException or InvalidDataException)
        {
            return Results.BadRequest(new { code = "invalid-result-ack" });
        }

        string code;
        try
        {
            code = worker.Outbox.Acknowledge(request.MatchId, request.Proof);
        }
        catch (ArgumentException)
        {
            return Results.BadRequest(new { code = "invalid-result-ack" });
        }
        return code switch
        {
            "acknowledged" or "already-acknowledged" => Results.Ok(new { code }),
            "missing" => Results.NotFound(new { code }),
            _ => Results.Conflict(new { code })
        };
    }
}
