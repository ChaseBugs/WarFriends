using MongoDB.Driver;
using War.Infrastructure;

namespace War.Persistence;

public sealed partial class BattleMatchQueueStore
{
    private const int QueueTicketLifetimeSeconds = 120;
    private const int MaximumAttemptTransactionRetries = 16;
    private const int AttemptOperationTimeoutSeconds = 30;
    private const int AttemptReceiptRetentionSeconds = 300;
    private const long MaximumAttemptUnixSecond = 253402300799;
    private const int MaximumWaitingAttemptRows = 128;
    private const string WaitingAttempt = "waiting";
    private const string PairedAttempt = "paired";
    private const string CancellingAttempt = "cancelling";
    private const string CancelledAttempt = "cancelled";
    private const string ClosedAttempt = "closed";

    private readonly record struct AttemptTransaction(
        IClientSessionHandle Session, DateTimeOffset Now, CancellationToken CancellationToken);

    private async Task InitializeAttemptIndexesAsync(CancellationToken cancellationToken)
    {
        await attempts.Indexes.CreateManyAsync([
            new CreateIndexModel<BattleQueueAttemptDocument>(
                Builders<BattleQueueAttemptDocument>.IndexKeys.Ascending(row => row.PlayerId)
                    .Ascending(row => row.State)),
            new CreateIndexModel<BattleQueueAttemptDocument>(
                Builders<BattleQueueAttemptDocument>.IndexKeys.Ascending(row => row.RetainUntilUtc),
                new CreateIndexOptions { ExpireAfter = TimeSpan.Zero })], cancellationToken);
    }

    private async Task<BattlePairingResult> RunAttemptTransactionAsync(
        Func<AttemptTransaction, Task<BattlePairingResult>> action,
        DateTimeOffset now,
        CancellationToken cancellationToken)
    {
        using var operation = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        operation.CancelAfter(TimeSpan.FromSeconds(AttemptOperationTimeoutSeconds));
        cancellationToken = operation.Token;
        for (int retry = 0; retry < MaximumAttemptTransactionRetries; retry++)
        {
            using var session = await client.StartSessionAsync(cancellationToken: cancellationToken);
            try
            {
                return await session.WithTransactionAsync(
                    (transaction, token) => action(new AttemptTransaction(transaction, now, token)),
                    QueueTransaction, cancellationToken);
            }
            catch (MongoWriteException failure) when (failure.WriteError.Category == ServerErrorCategory.DuplicateKey)
            {
                // Independent first join/cancel transactions may insert the same receipt identity.
            }
        }

        throw new InvalidDataException("Queue attempt ownership changed repeatedly; retry the request.");
    }

    private async Task<BattleQueueAttemptDocument?> ReadAttemptAsync(
        string playerId, string attemptId, AttemptTransaction transaction)
    {
        string id = playerId + ":" + attemptId;
        var receipt = await attempts.Find(transaction.Session, row => row.Id == id)
            .FirstOrDefaultAsync(transaction.CancellationToken);
        if (receipt != null)
        {
            ValidateAttemptReceipt(receipt);
            if (receipt.PlayerId != playerId || receipt.AttemptId != attemptId ||
                receipt.IssuedUtc > transaction.Now.UtcDateTime)
            {
                throw new InvalidDataException("Queue receipt differs from requested attempt authority.");
            }
        }

        return receipt;
    }

    private async Task SaveAttemptAsync(BattleQueueAttemptDocument receipt, AttemptTransaction transaction)
    {
        long previousRevision = receipt.Revision;
        receipt.Revision = checked(previousRevision + 1);
        ValidateAttemptReceipt(receipt);
        if (previousRevision == 0)
        {
            await attempts.InsertOneAsync(transaction.Session, receipt,
                cancellationToken: transaction.CancellationToken);
            return;
        }

        var updated = await attempts.ReplaceOneAsync(transaction.Session,
            row => row.Id == receipt.Id && row.Revision == previousRevision, receipt,
            cancellationToken: transaction.CancellationToken);
        if (updated.ModifiedCount != 1)
        {
            throw new InvalidDataException("Queue receipt ownership changed inside its transaction.");
        }
    }

    private async Task CloseOtherWaitingAttemptsAsync(
        BattleQueueAttemptDocument receipt, AttemptTransaction transaction)
    {
        var previous = await attempts.Find(transaction.Session, row => row.PlayerId == receipt.PlayerId &&
            row.AttemptId != receipt.AttemptId && row.State == WaitingAttempt)
            .Limit(MaximumWaitingAttemptRows + 1).ToListAsync(transaction.CancellationToken);
        if (previous.Count > MaximumWaitingAttemptRows)
        {
            throw new InvalidDataException("Too many unresolved queue attempt receipts.");
        }

        foreach (var row in previous)
        {
            ValidateAttemptReceipt(row);
            row.State = ClosedAttempt;
            await SaveAttemptAsync(row, transaction);
        }
    }

    private async Task MarkPairedAsync(
        BattleQueueAttemptDocument receipt, string matchId, AttemptTransaction transaction)
    {
        receipt.State = PairedAttempt;
        receipt.MatchId = matchId;
        await SaveAttemptAsync(receipt, transaction);
    }

    private async Task DeleteAttemptTicketAsync(
        BattleQueueTicketDocument ticket, AttemptTransaction transaction)
    {
        var deleted = await tickets.DeleteOneAsync(transaction.Session,
            row => row.Id == ticket.Id && row.PlayerId == ticket.PlayerId && row.AttemptId == ticket.AttemptId,
            cancellationToken: transaction.CancellationToken);
        if (deleted.DeletedCount != 1)
        {
            throw new InvalidDataException("Queue attempt ticket changed inside its transaction.");
        }
    }

    private static BattleQueueAttemptDocument CreateAttempt(BattleQueueAttemptIdentity attempt)
    {
        return new BattleQueueAttemptDocument
        {
            Id = attempt.PlayerId + ":" + attempt.AttemptId, PlayerId = attempt.PlayerId,
            AttemptId = attempt.AttemptId,
            IssuedUtc = DateTimeOffset.FromUnixTimeSeconds(attempt.IssuedUnixSeconds).UtcDateTime,
            ExpiresUtc = DateTimeOffset.FromUnixTimeSeconds(attempt.ExpiresUnixSeconds).UtcDateTime,
            RetainUntilUtc = DateTimeOffset.FromUnixTimeSeconds(
                attempt.ExpiresUnixSeconds + AttemptReceiptRetentionSeconds).UtcDateTime
        };
    }

    private static void ValidateReceiptIdentity(
        BattleQueueAttemptDocument? receipt, BattleQueueAttemptIdentity attempt)
    {
        if (receipt != null &&
            (receipt.IssuedUtc != DateTimeOffset.FromUnixTimeSeconds(attempt.IssuedUnixSeconds).UtcDateTime ||
             receipt.ExpiresUtc != DateTimeOffset.FromUnixTimeSeconds(attempt.ExpiresUnixSeconds).UtcDateTime))
        {
            throw new InvalidDataException("Queue receipt lifetime differs from its signed credential.");
        }
    }

    private static void ValidateAttemptIdentity(BattleQueueAttemptIdentity attempt, DateTimeOffset now)
    {
        Validate(attempt.PlayerId, "attempt", now);
        if (!ValidId(attempt.AttemptId) || attempt.IssuedUnixSeconds < 0 ||
            attempt.IssuedUnixSeconds > now.ToUnixTimeSeconds() ||
            attempt.IssuedUnixSeconds > MaximumAttemptUnixSecond - BattleQueueAttemptTokens.LifetimeSeconds -
                AttemptReceiptRetentionSeconds ||
            attempt.ExpiresUnixSeconds != attempt.IssuedUnixSeconds + BattleQueueAttemptTokens.LifetimeSeconds)
        {
            throw new InvalidDataException("Invalid queue attempt authority.");
        }
    }

    private static void ValidateAttemptReceipt(BattleQueueAttemptDocument receipt)
    {
        bool paired = receipt.State is PairedAttempt or CancellingAttempt;
        if (!ValidId(receipt.PlayerId) || !ValidId(receipt.AttemptId) ||
            receipt.Id != receipt.PlayerId + ":" + receipt.AttemptId || receipt.Revision is < 1 or long.MaxValue ||
            receipt.IssuedUtc.Kind != DateTimeKind.Utc || receipt.IssuedUtc < DateTime.UnixEpoch ||
            receipt.IssuedUtc > DateTime.MaxValue.AddSeconds(
                -BattleQueueAttemptTokens.LifetimeSeconds - AttemptReceiptRetentionSeconds) ||
            receipt.IssuedUtc.Ticks % TimeSpan.TicksPerSecond != 0 || receipt.ExpiresUtc.Kind != DateTimeKind.Utc ||
            receipt.ExpiresUtc != receipt.IssuedUtc.AddSeconds(BattleQueueAttemptTokens.LifetimeSeconds) ||
            receipt.RetainUntilUtc.Kind != DateTimeKind.Utc ||
            receipt.RetainUntilUtc != receipt.ExpiresUtc.AddSeconds(AttemptReceiptRetentionSeconds) ||
            receipt.State is not
                (WaitingAttempt or PairedAttempt or CancellingAttempt or CancelledAttempt or ClosedAttempt) ||
            (paired ? !System.Text.RegularExpressions.Regex.IsMatch(receipt.MatchId ?? "", @"\Am[0-9a-f]{32}\z") :
                receipt.MatchId != ""))
        {
            throw new InvalidDataException("Invalid durable queue attempt receipt.");
        }
    }

    private static bool PairOwnsAttempt(BattlePairDocument pair, BattleQueueAttemptIdentity attempt)
    {
        int playerIndex = Array.IndexOf(pair.Players, attempt.PlayerId);
        return playerIndex >= 0 && pair.AttemptIds.Length == pair.Players.Length &&
            pair.AttemptIds[playerIndex] == attempt.AttemptId;
    }

    private static void RequirePairAttempt(BattlePairDocument pair, BattleQueueAttemptIdentity attempt)
    {
        _ = Result("paired", pair);
        if (!PairOwnsAttempt(pair, attempt))
        {
            throw new InvalidDataException("A different attempt owns this player's pair.");
        }
    }
}
