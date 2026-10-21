using War.Backend.Application;
using War.Infrastructure;
using War.Protocol;
using static War.Backend.Application.ApplicationFailureKind;

namespace War.Backend.Features.Battle.Queue;

public sealed class BattleQueueAttemptService
{
    private readonly BattleQueueAttemptTokens _attempts;

    public BattleQueueAttemptService(BattleQueueAttemptTokens attempts)
    {
        _attempts = attempts;
    }

    public ApplicationResult<MatchQueueAttemptGrant> Issue(string playerId, MatchQueueRequest request)
    {
        if (request.CalculateSize() != 0)
        {
            return ApplicationResult<MatchQueueAttemptGrant>.Reject(InvalidRequest,
                "invalid_matchmaking_request", "Matchmaking request must be empty.");
        }

        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        return ApplicationResult<MatchQueueAttemptGrant>.Success(new MatchQueueAttemptGrant
        {
            Token = _attempts.Issue(playerId, now),
            ExpiresUnixSeconds = now + BattleQueueAttemptTokens.LifetimeSeconds
        });
    }
}
