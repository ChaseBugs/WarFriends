using MongoDB.Bson;
using MongoDB.Driver;

namespace War.Persistence;

public sealed partial class BattleMatchQueueStore
{
    public const int CancellationRetrySeconds = 60;
    private const int MaximumCancellationBatch = 4;
    private const int MaximumDiscoveryLeadSeconds = CancellationRetrySeconds * 2;

    private async Task InitializeCancellationIndexAsync(CancellationToken cancellationToken)
    {
        await pairs.Indexes.CreateOneAsync(new CreateIndexModel<BattlePairDocument>(
            Builders<BattlePairDocument>.IndexKeys.Ascending("Cancellation.RetryAfterUtc").Ascending(row => row.Id)),
            cancellationToken: cancellationToken);
    }

    private async Task RecordPairCancellationAsync(
        BattlePairDocument pair, string playerId, string attemptId, AttemptTransaction transaction)
    {
        if (pair.Cancellation != null)
        {
            ValidatePairCancellation(pair);
            return;
        }

        pair.Cancellation = new BattlePairCancellationRequest
        {
            PlayerId = playerId, AttemptId = attemptId,
            RequestedUtc = transaction.Now.UtcDateTime, RetryAfterUtc = transaction.Now.UtcDateTime
        };
        ValidatePairCancellation(pair);
        var updated = await pairs.UpdateOneAsync(transaction.Session,
            row => row.Id == pair.Id && row.MatchId == pair.MatchId && row.Cancellation == null,
            Builders<BattlePairDocument>.Update.Set(row => row.Cancellation, pair.Cancellation),
            cancellationToken: transaction.CancellationToken);
        if (updated.ModifiedCount != 1)
        {
            throw new InvalidDataException("Pair cancellation authority changed inside its transaction.");
        }
    }

    /// <summary>Claims a bounded, fully validated page; expiry permits takeover after a Backend stops.</summary>
    public async Task<IReadOnlyList<BattlePairingResult>> ClaimCancellationsAsync(
        DateTimeOffset now, CancellationToken cancellationToken)
    {
        if (now < DateTimeOffset.UnixEpoch || now > DateTimeOffset.MaxValue.AddSeconds(-MaximumDiscoveryLeadSeconds))
        {
            throw new InvalidDataException("Invalid cancellation recovery time.");
        }

        var filter = Builders<BattlePairDocument>.Filter;
        var due = filter.Ne(row => row.Cancellation, null) & filter.Or(
            filter.Lte("Cancellation.RetryAfterUtc", now.UtcDateTime),
            filter.Gt("Cancellation.RetryAfterUtc", now.AddSeconds(MaximumDiscoveryLeadSeconds).UtcDateTime),
            filter.Gt("Cancellation.RequestedUtc", now.AddSeconds(CancellationRetrySeconds).UtcDateTime),
            filter.Not(filter.Type("Cancellation.RetryAfterUtc", BsonType.DateTime)),
            filter.Not(filter.Type("Cancellation.RequestedUtc", BsonType.DateTime)));
        var candidates = await pairs.Find(due).Sort(Builders<BattlePairDocument>.Sort
            .Ascending("Cancellation.RetryAfterUtc").Ascending(row => row.Id))
            .Limit(MaximumCancellationBatch).ToListAsync(cancellationToken);
        foreach (var pair in candidates)
        {
            _ = Result("already-paired", pair);
            var request = pair.Cancellation ??
                throw new InvalidDataException("Recovery row has no cancellation intent.");
            if (request.RequestedUtc > now.AddSeconds(CancellationRetrySeconds).UtcDateTime ||
                request.RetryAfterUtc > now.AddSeconds(MaximumDiscoveryLeadSeconds).UtcDateTime)
            {
                throw new InvalidDataException("Cancellation recovery authority is future dated.");
            }
        }

        var claimed = new List<BattlePairingResult>();
        foreach (var pair in candidates)
        {
            if (await TryClaimCancellationAsync(pair, now, cancellationToken))
            {
                claimed.Add(Result("already-paired", pair));
            }
        }

        return claimed.AsReadOnly();
    }

    private async Task<bool> TryClaimCancellationAsync(
        BattlePairDocument pair, DateTimeOffset now, CancellationToken cancellationToken)
    {
        var filter = Builders<BattlePairDocument>.Filter;
        var attemptsMatch = filter.Eq(row => row.AttemptIds, pair.AttemptIds);
        if (pair.AttemptIds.Length == 0)
        {
            attemptsMatch |= filter.Exists(row => row.AttemptIds, false);
        }

        var identity = filter.Eq(row => row.Id, pair.Id) & filter.Eq(row => row.MatchId, pair.MatchId) &
            filter.Eq(row => row.Players, pair.Players) & attemptsMatch &
            filter.Eq(row => row.CompatibilityKey, pair.CompatibilityKey) &
            filter.Eq(row => row.CreatedUtc, pair.CreatedUtc) & filter.Eq(row => row.Cancellation, pair.Cancellation);
        var updated = await pairs.UpdateOneAsync(identity,
            Builders<BattlePairDocument>.Update.Set("Cancellation.RetryAfterUtc",
                now.AddSeconds(CancellationRetrySeconds).UtcDateTime), cancellationToken: cancellationToken);
        return updated.ModifiedCount == 1;
    }

    private static void ValidatePairCancellation(BattlePairDocument pair)
    {
        var request = pair.Cancellation;
        if (request == null)
        {
            return;
        }

        int playerIndex = Array.IndexOf(pair.Players, request.PlayerId);
        bool ownsAttempt = pair.AttemptIds.Length == 0
            ? request.AttemptId == ""
            : playerIndex >= 0 && pair.AttemptIds[playerIndex] == request.AttemptId;
        if (playerIndex < 0 || !ownsAttempt || request.RequestedUtc.Kind != DateTimeKind.Utc ||
            request.RequestedUtc < DateTime.UnixEpoch || request.RetryAfterUtc.Kind != DateTimeKind.Utc ||
            request.RetryAfterUtc < request.RequestedUtc)
        {
            throw new InvalidDataException("Invalid durable pair cancellation request.");
        }
    }
}
