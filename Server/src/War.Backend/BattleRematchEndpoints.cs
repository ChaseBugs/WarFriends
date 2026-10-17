using System.Text.RegularExpressions;
using War.Persistence;
using War.Protocol;
using static War.Backend.HttpProtocol;

namespace War.Backend;

/// <summary>Exposes participant-only rematch intent without issuing replacement battle grants.</summary>
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
        if (!Regex.IsMatch(request.MatchId, @"\Am[0-9a-f]{32}\z") ||
            !request.Equals(new MatchGrantRequest { MatchId = request.MatchId }))
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

    private static MatchRematchConsent Project(string matchId, BattleRematchConsentDocument? consent)
    {
        var response = new MatchRematchConsent { MatchId = matchId, Status = "not-requested" };
        if (consent == null)
        {
            return response;
        }
        response.Status = consent.Status;
        response.Revision = consent.Revision;
        response.ExpiresUnixMilliseconds = new DateTimeOffset(consent.ExpiresUtc).ToUnixTimeMilliseconds();
        response.AcceptedPlayerIds.Add(consent.AcceptedPlayers);
        return response;
    }
}
