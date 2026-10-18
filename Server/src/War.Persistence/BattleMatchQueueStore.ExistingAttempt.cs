using MongoDB.Driver;
using War.Infrastructure;

namespace War.Persistence;

public sealed partial class BattleMatchQueueStore
{
    /// <summary>Reads only this attempt's existing outcome without creating a ticket or preparing a new loadout.</summary>
    public async Task<BattlePairingResult?> ExistingAttemptAsync(BattleQueueAttemptIdentity attempt,
        DateTimeOffset now, CancellationToken cancellationToken)
    {
        ValidateAttemptIdentity(attempt, now);
        if (now.ToUnixTimeSeconds() >= attempt.ExpiresUnixSeconds)
        {
            throw new InvalidDataException("Queue attempt admission has expired.");
        }
        using IClientSessionHandle session = await client.StartSessionAsync(cancellationToken: cancellationToken);
        return await session.WithTransactionAsync<BattlePairingResult?>(async (transaction, token) =>
        {
            var context = new AttemptTransaction(transaction, now, token);
            BattleQueueAttemptDocument? receipt = await ReadAttemptAsync(attempt.PlayerId, attempt.AttemptId, context);
            ValidateReceiptIdentity(receipt, attempt);
            if (receipt?.State is CancelledAttempt or ClosedAttempt or CancellingAttempt)
            {
                return new BattlePairingResult("cancelled", null, null);
            }
            BattlePairDocument? pair = await PairFor(transaction, attempt.PlayerId, token);
            if (pair != null)
            {
                RequirePairAttempt(pair, attempt);
                if (receipt?.State != PairedAttempt || receipt.MatchId != pair.MatchId)
                {
                    throw new InvalidDataException("Paired attempt receipt differs from its durable pair.");
                }
                return Result("paired", pair);
            }
            return receipt?.State == PairedAttempt
                ? new BattlePairingResult("attempt-completed", null, null)
                : null;
        }, QueueTransaction, cancellationToken);
    }
}
