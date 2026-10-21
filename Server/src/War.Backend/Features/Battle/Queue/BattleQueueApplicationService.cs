using War.Backend.Application;
using War.Backend.Features.Battle.Admission;
using War.Infrastructure;
using War.Persistence;
using War.Protocol;
using static War.Backend.Application.ApplicationFailureKind;
using QueueResult = War.Backend.Application.ApplicationResult<War.Protocol.MatchQueueReply>;

namespace War.Backend.Features.Battle.Queue;

public sealed class BattleQueueApplicationService
{
    private readonly BattleMatchQueueStore _queue;
    private readonly BattleQueueAttemptTokens _attempts;
    private readonly BattleQueueHosting _hosting;
    private readonly BattleQueueAdmission _admission;

    public BattleQueueApplicationService(BattleMatchQueueStore queue, BattleQueueAttemptTokens attempts,
        BattleQueueHosting hosting, BattleQueueAdmission admission)
    {
        _queue = queue;
        _attempts = attempts;
        _hosting = hosting;
        _admission = admission;
    }

    public async Task<QueueResult> JoinAsync(string playerId, MatchQueueRequest request,
        CancellationToken cancellationToken)
    {
        if (!BattleRequestPolicy.IsOnlyQueueAttempt(request))
        {
            return QueueResult.Reject(InvalidRequest, "invalid_matchmaking_request",
                "Unknown matchmaking request fields.");
        }

        DateTimeOffset now = DateTimeOffset.UtcNow;
        BattleQueueAttemptIdentity? attempt;
        try
        {
            attempt = request.AttemptToken.Length == 0 ? null :
                _attempts.ValidateForJoin(request.AttemptToken, playerId, now.ToUnixTimeSeconds());
        }
        catch (InvalidDataException)
        {
            return QueueResult.Reject(InvalidRequest, "invalid_queue_attempt",
                "Invalid or expired queue attempt credential.");
        }
        if (_hosting.CompatibilityKey == null)
        {
            return QueueResult.Reject(Unavailable, "matchmaking_disabled", "Matchmaking policy is not configured.");
        }

        BattlePairingResult? pair;
        try
        {
            pair = attempt.HasValue
                ? await _queue.ExistingAttemptAsync(attempt.Value, now, cancellationToken)
                : await _queue.ExistingUnscoped(playerId, cancellationToken);
            if (pair == null)
            {
                ApplicationFailure? failure = await _admission.PrepareAsync(playerId, cancellationToken);
                if (failure != null)
                {
                    return QueueResult.FromFailure(failure);
                }
                // Scoped admission checks its expiry again after preparation, as before extraction.
                pair = attempt.HasValue
                    ? await _queue.JoinAttemptAsync(attempt.Value, _hosting.CompatibilityKey,
                        DateTimeOffset.UtcNow, cancellationToken)
                    : await _queue.Join(playerId, _hosting.CompatibilityKey, now, cancellationToken);
            }
        }
        catch (InvalidDataException)
        {
            return QueueResult.Reject(Conflict, "matchmaking_conflict",
                "Player has incompatible matchmaking authority.");
        }
        return await PublishPairAsync(pair, cancellationToken);
    }

    private async Task<QueueResult> PublishPairAsync(BattlePairingResult pair, CancellationToken cancellationToken)
    {
        if (pair.Code == "paired" && pair.MatchId != null && pair.Players != null && _hosting.CanProvision)
        {
            try
            {
                pair = await _hosting.ProvisionAsync(pair, cancellationToken);
            }
            catch (Exception failure) when (failure is InvalidDataException or HttpRequestException)
            {
                return QueueResult.Reject(Unavailable, "match_provision_deferred",
                    "Match is paired but provisioning must be retried.");
            }
        }

        var reply = new MatchQueueReply { Code = pair.Code, MatchId = pair.MatchId ?? "" };
        if (pair.Players != null)
        {
            reply.PlayerIds.Add(pair.Players);
        }
        return QueueResult.Success(reply);
    }
}
