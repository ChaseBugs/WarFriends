using System.Text.RegularExpressions;
using War.Protocol;

namespace War.Backend.Features.Battle.Admission;

public static class BattleRequestPolicy
{
    public static bool IsMatchId(string matchId)
    {
        return Regex.IsMatch(matchId, @"\Am[0-9a-f]{32}\z");
    }

    public static bool IsOnlyMatchId(MatchGrantRequest request)
    {
        return IsMatchId(request.MatchId) && request.Equals(new MatchGrantRequest { MatchId = request.MatchId });
    }

    public static bool IsOnlyQueueAttempt(MatchQueueRequest request)
    {
        return request.Equals(new MatchQueueRequest { AttemptToken = request.AttemptToken });
    }
}
