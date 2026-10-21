using Microsoft.AspNetCore.Http;
using War.Protocol;

namespace War.BattleServer.Transport.Control;

internal static class WorkerGrantProjection
{
    internal static object Grant(MatchConnectionGrant grant)
    {
        return new
        {
            host = grant.Host,
            port = grant.Port,
            ticket = grant.Ticket,
            sessionKey = Convert.ToBase64String(grant.SessionKey.ToByteArray()),
            sessionId = grant.SessionId,
            matchId = grant.MatchId,
            playerId = grant.PlayerId,
            manifestHash = grant.ManifestHash,
            expiresUnixSeconds = grant.ExpiresUnixSeconds,
            mapId = grant.MapId,
            mapRevision = grant.MapRevision
        };
    }

    internal static IResult Registration(MatchRegistrationResult result, MatchManifest manifest)
    {
        object[] grants = result.Grants?.Select(Grant).ToArray() ?? Array.Empty<object>();
        return result.Code switch
        {
            "registered" or "existing-match" => Results.Json(new
            {
                code = result.Code, matchId = manifest.MatchId, manifestHash = result.ManifestHash, grants
            }, statusCode: result.Code == "registered" ? StatusCodes.Status201Created : StatusCodes.Status200OK),
            "duplicate-match" or "admission-expired" or "terminal-match-id" or "match-terminal" =>
                Results.Conflict(new { code = result.Code }),
            "match-capacity" or "control-capacity" or "control-unavailable" or "allocation-unavailable" =>
                Results.Json(new { code = result.Code }, statusCode: StatusCodes.Status503ServiceUnavailable),
            _ => Results.BadRequest(new { code = result.Code })
        };
    }

    internal static IResult Reconnect(MatchRegistrationResult result)
    {
        if (result.Code is "control-capacity" or "control-unavailable")
        {
            return Results.Json(new { code = result.Code }, statusCode: StatusCodes.Status503ServiceUnavailable);
        }
        if (result.Code is not ("reconnect-issued" or "reconnect-existing"))
        {
            return Results.Conflict(new { code = result.Code });
        }
        return Results.Ok(new { code = result.Code, grant = Grant(result.Grants!.Single()) });
    }
}
