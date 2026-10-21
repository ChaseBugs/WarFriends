using System.Text.Json;
using Microsoft.AspNetCore.Http.Features;
using War.Backend.Transport.Http;
using War.Infrastructure;
using War.Persistence;

namespace War.Backend.Features.Battle.Internal;

public static class InternalBattleEndpoints
{
    private const int AllocationBodyBytes = 2048;

    public static void MapInternalBattleEndpoints(this WebApplication app)
    {
        app.MapPost("/internal/battle/matches/provision", ProvisionAsync);
        app.MapPost("/internal/battle/results/accept", AcceptResultAsync);
        app.MapPost("/internal/battle/allocations/read", ReadAllocationsAsync);
    }

    private static async Task<IResult> ProvisionAsync(HttpContext context, BattleControlAuthenticator authentication,
        BattleMatchProvisioner provisioner)
    {
        byte[] body = await BoundedHttpBody.ReadAsync(context, BackendHttpPolicy.MaximumRequestBodyBytes);
        if (body.Length == 0)
        {
            return Results.StatusCode(StatusCodes.Status413PayloadTooLarge);
        }
        if (!authentication.IsAuthorized(context, body, "war/match/provision/v1/"))
        {
            return Results.Unauthorized();
        }

        try
        {
            string code = await provisioner.Provision(body, context.RequestAborted);
            return Results.Json(new { code }, statusCode: code == "provisioned" ? 201 : 200);
        }
        catch (InvalidDataException)
        {
            return Results.BadRequest(new { code = "invalid-match-provision" });
        }
        catch (HttpRequestException)
        {
            return Results.StatusCode(StatusCodes.Status503ServiceUnavailable);
        }
    }

    private static async Task<IResult> AcceptResultAsync(HttpContext context, BattleControlAuthenticator authentication,
        BattleTerminalAcceptance acceptance)
    {
        IHttpMaxRequestBodySizeFeature? bodyLimit = context.Features.Get<IHttpMaxRequestBodySizeFeature>();
        if (bodyLimit is { IsReadOnly: false })
        {
            bodyLimit.MaxRequestBodySize = TerminalResultEnvelope.MaximumWireBodyBytes;
        }
        byte[] body = await BoundedHttpBody.ReadAsync(context, TerminalResultEnvelope.MaximumBodyBytes);
        if (!authentication.IsAuthorized(context, body, "war/result/accept/v1/"))
        {
            return Results.Unauthorized();
        }

        try
        {
            TerminalSubmission submission = BattleControlPayloads.ReadResult(body, authentication.ServerId);
            string code = await acceptance.Accept(submission.MatchId, submission.Digest, submission.Snapshot,
                context.RequestAborted);
            return code == "conflict" ? Results.Conflict(new { code }) : Results.Ok(new { code });
        }
        catch (Exception failure) when (failure is FormatException or JsonException or InvalidDataException)
        {
            return Results.BadRequest(new { code = "invalid-result" });
        }
    }

    private static async Task<IResult> ReadAllocationsAsync(HttpContext context,
        BattleControlAuthenticator authentication, BattleAllocationStore allocations)
    {
        byte[] body = await BoundedHttpBody.ReadAsync(context, AllocationBodyBytes);
        if (!authentication.IsAuthorized(context, body, "war/allocation/read/v1/"))
        {
            return Results.Unauthorized();
        }

        try
        {
            string[] players = BattleControlPayloads.ReadPlayerIds(body, authentication.ServerId);
            IReadOnlyList<War.Shared.BattleAllocationProjection> result =
                await allocations.GetMany(players, context.RequestAborted);
            return Results.Json(result);
        }
        catch (Exception failure) when (failure is JsonException or InvalidDataException)
        {
            return Results.BadRequest(new { code = "invalid-allocation-read" });
        }
    }
}
