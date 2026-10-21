using War.Persistence;
using War.Protocol;

namespace War.Backend.Features.Battle.Rematch;

internal static class BattleRematchProjection
{
    internal static MatchRematchConsent Project(string matchId, BattleRematchConsentDocument? consent)
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
