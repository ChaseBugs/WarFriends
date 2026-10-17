using System.Text.RegularExpressions;
using War.Persistence;
using War.Protocol;
using static War.Backend.HttpProtocol;

namespace War.Backend;

/// <summary>Exposes participant-only rematch intent and source-compatible fresh allocation.</summary>
public static class BattleRematchEndpoints
{
    /// <summary>Uses the same account authentication boundary as the existing battle allocation routes.</summary>
    public static void MapBattleRematchEndpoints(this RouteGroupBuilder routes,
        Func<HttpContext, Task<string?>> authenticate)
    {
        routes.MapPost("/battle/rematch/read", (HttpContext context, BattleRematchConsentStore store) =>
            HandleAsync(context, store, authenticate, "read"));
        routes.MapPost("/battle/rematch/accept", (HttpContext context, BattleRematchConsentStore store) =>
            HandleAsync(context, store, authenticate, "accept"));
        routes.MapPost("/battle/rematch/cancel", (HttpContext context, BattleRematchConsentStore store) =>
            HandleAsync(context, store, authenticate, "cancel"));
        Func<HttpContext, Task<IResult>> allocate = context => AllocateAsync(context, authenticate);
        routes.MapPost("/battle/rematch/allocate", allocate);
        routes.MapPost("/battle/rematch/cancel-allocation",
            (HttpContext context, BattleRematchCancellation cancellation) =>
            CancelAllocatedAsync(context, cancellation, authenticate));
    }

    private static async Task<IResult> CancelAllocatedAsync(HttpContext context, BattleRematchCancellation cancellation,
        Func<HttpContext, Task<string?>> authenticate)
    {
        string? playerId = await authenticate(context);
        if (playerId == null)
        {
            return Error(401, "unauthorized", "Authentication required.");
        }
        MatchGrantRequest request = await Read(context, MatchGrantRequest.Parser);
        if (!IsCanonicalRequest(request))
        {
            return Error(400, "invalid_rematch_request", "Only a canonical completed match ID is accepted.");
        }
        try
        {
            return Proto(await cancellation.CancelAllocatedAsync(request.MatchId, playerId, context.RequestAborted));
        }
        catch (InvalidDataException)
        {
            return Error(409, "rematch_unavailable", "Source-bound rematch cancellation is unavailable.");
        }
        catch (HttpRequestException exception) when (exception.StatusCode == System.Net.HttpStatusCode.Conflict)
        {
            return Error(409, "rematch_cancellation_conflict", "The Worker did not confirm prestart cancellation.");
        }
        catch (Exception exception) when (exception is HttpRequestException ||
            exception is OperationCanceledException && !context.RequestAborted.IsCancellationRequested)
        {
            return Error(503, "rematch_cancellation_deferred", "Reserved rematch cancellation must be retried.");
        }
    }

    private static async Task<IResult> AllocateAsync(
        HttpContext context, Func<HttpContext, Task<string?>> authenticate)
    {
        string? playerId = await authenticate(context);
        if (playerId == null)
        {
            return Error(401, "unauthorized", "Authentication required.");
        }
        MatchGrantRequest request = await Read(context, MatchGrantRequest.Parser);
        if (!IsCanonicalRequest(request))
        {
            return Error(400, "invalid_rematch_request", "Only a canonical completed match ID is accepted.");
        }
        var allocator = context.RequestServices.GetService<BattleRematchAllocator>();
        if (allocator == null)
        {
            return Error(503, "rematch_disabled", "Rematch allocation policy is not configured.");
        }
        try
        {
            return Proto(await allocator.AllocateAsync(request.MatchId, playerId, context.RequestAborted));
        }
        catch (InvalidDataException)
        {
            return Error(409, "rematch_unavailable", "Source-compatible rematch allocation is unavailable.");
        }
        catch (HttpRequestException)
        {
            return Error(503, "rematch_provision_deferred", "Reserved rematch provisioning must be retried.");
        }
    }

    private static async Task<IResult> HandleAsync(HttpContext context, BattleRematchConsentStore store,
        Func<HttpContext, Task<string?>> authenticate, string operation)
    {
        string? playerId = await authenticate(context);
        if (playerId == null)
        {
            return Error(401, "unauthorized", "Authentication required.");
        }
        MatchGrantRequest request = await Read(context, MatchGrantRequest.Parser);
        if (!IsCanonicalRequest(request))
        {
            return Error(400, "invalid_rematch_request", "Only a canonical completed match ID is accepted.");
        }
        try
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;
            BattleRematchConsentDocument? consent = operation switch
            {
                "accept" => await store.AcceptAsync(request.MatchId, playerId, now, context.RequestAborted),
                "cancel" => await store.CancelAsync(request.MatchId, playerId, now, context.RequestAborted),
                _ => await store.ReadAsync(request.MatchId, playerId, now, context.RequestAborted),
            };
            return Proto(Project(request.MatchId, consent));
        }
        catch (InvalidDataException)
        {
            return Error(409, "rematch_unavailable", "Completed battle consent is unavailable for this participant.");
        }
    }

    private static bool IsCanonicalRequest(MatchGrantRequest request)
    {
        return Regex.IsMatch(request.MatchId, @"\Am[0-9a-f]{32}\z") &&
            request.Equals(new MatchGrantRequest { MatchId = request.MatchId });
    }

    private static MatchRematchConsent Project(string matchId, BattleRematchConsentDocument? consent)
    {
        var response = new MatchRematchConsent { MatchId = matchId, Status = "not-requested" };
        if (consent == null)
        {
            return response;
        }
        response.Status = consent.Status;
        response.Revision = consent.Revision;
        response.NextMatchId = consent.NextMatchId;
        response.ExpiresUnixMilliseconds = new DateTimeOffset(consent.ExpiresUtc).ToUnixTimeMilliseconds();
        response.AcceptedPlayerIds.Add(consent.AcceptedPlayers);
        return response;
    }
}
