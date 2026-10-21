using War.Persistence;
using War.Protocol;

namespace War.Backend;

/// <summary>Cancels the exact consumed rematch reservation through existing Worker terminal authority.</summary>
public sealed class BattleRematchCancellation
{
    private readonly BattleRematchConsentStore _consents;
    private readonly BattleMatchQueueStore _queue;
    private readonly BattlePairedCancellation _cancellation;

    /// <summary>Shares durable consent, participant fencing and Worker-confirmed cancellation services.</summary>
    public BattleRematchCancellation(BattleRematchConsentStore consents, BattleMatchQueueStore queue,
        BattlePairedCancellation cancellation)
    {
        _consents = consents;
        _queue = queue;
        _cancellation = cancellation;
    }

    /// <summary>Uses the consumed source pointer; a stale request cannot select a later account-owned match.</summary>
    public async Task<MatchQueueReply> CancelAllocatedAsync(
        string sourceMatchId, string authenticatedPlayerId, CancellationToken cancellationToken)
    {
        DateTimeOffset now = DateTimeOffset.UtcNow;
        var consent = await _consents.ReadAsync(sourceMatchId, authenticatedPlayerId, now, cancellationToken);
        if (consent?.Status != "allocated")
        {
            throw new InvalidDataException("Only a consumed rematch has an allocated match to cancel.");
        }
        var captured = await _queue.CancelReservedMatchAsync(
            new BattleReservedMatchCancellation(authenticatedPlayerId, consent.NextMatchId, consent.NextPlayers, now),
            cancellationToken);
        if (captured.Code == "not-assigned")
        {
            return new MatchQueueReply { Code = "completed", MatchId = consent.NextMatchId };
        }
        string code = await _cancellation.CancelAsync(captured, cancellationToken);
        return new MatchQueueReply { Code = code, MatchId = consent.NextMatchId };
    }
}
