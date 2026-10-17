using MongoDB.Driver;
using War.Infrastructure;

namespace War.Persistence;

public sealed partial class BattleMatchQueueStore
{
    /// <summary>Joins only this signed attempt; cancellation receipts prevent delayed recreation.</summary>
    public Task<BattlePairingResult> JoinAttemptAsync(
        BattleQueueAttemptIdentity attempt,
        string compatibilityKey,
        DateTimeOffset now,
        CancellationToken cancellationToken)
    {
        ValidateAttemptIdentity(attempt, now);
        Validate(attempt.PlayerId, compatibilityKey, now);
        if (now.ToUnixTimeSeconds() >= attempt.ExpiresUnixSeconds)
        {
            throw new InvalidDataException("Queue attempt admission has expired.");
        }

        return RunAttemptTransactionAsync(
            transaction => JoinAttemptCoreAsync(attempt, compatibilityKey, transaction), now, cancellationToken);
    }

    /// <summary>Captures only this attempt's pair, or records cancellation before a delayed join.</summary>
    public Task<BattlePairingResult> CancelAttemptAsync(
        BattleQueueAttemptIdentity attempt, DateTimeOffset now, CancellationToken cancellationToken)
    {
        ValidateAttemptIdentity(attempt, now);
        return RunAttemptTransactionAsync(
            transaction => CancelAttemptCoreAsync(attempt, transaction), now, cancellationToken);
    }

    private async Task<BattlePairingResult> JoinAttemptCoreAsync(
        BattleQueueAttemptIdentity attempt, string compatibilityKey, AttemptTransaction transaction)
    {
        var receipt = await ReadAttemptAsync(attempt.PlayerId, attempt.AttemptId, transaction);
        ValidateReceiptIdentity(receipt, attempt);
        if (receipt?.State is CancelledAttempt or ClosedAttempt or CancellingAttempt)
        {
            return new BattlePairingResult("cancelled", null, null);
        }

        var pair = await PairFor(transaction.Session, attempt.PlayerId, transaction.CancellationToken);
        if (pair != null)
        {
            RequirePairAttempt(pair, attempt);
            if (receipt?.State != PairedAttempt || receipt.MatchId != pair.MatchId)
            {
                throw new InvalidDataException("Paired attempt receipt differs from its durable pair.");
            }

            await MarkPairedAsync(receipt, pair.MatchId, transaction);
            return Result("paired", pair);
        }

        if (receipt?.State == PairedAttempt)
        {
            receipt.State = ClosedAttempt;
            receipt.MatchId = "";
            await SaveAttemptAsync(receipt, transaction);
            return new BattlePairingResult("attempt-completed", null, null);
        }

        var ticket = await PrepareAttemptTicketAsync(attempt, compatibilityKey, transaction);
        receipt ??= CreateAttempt(attempt);
        await CloseOtherWaitingAttemptsAsync(receipt, transaction);
        return await PairAttemptTicketAsync(ticket, receipt, transaction);
    }

    private async Task<BattleQueueTicketDocument> PrepareAttemptTicketAsync(
        BattleQueueAttemptIdentity attempt, string compatibilityKey, AttemptTransaction transaction)
    {
        var token = transaction.CancellationToken;
        var ticket = await tickets.Find(transaction.Session, row => row.PlayerId == attempt.PlayerId)
            .FirstOrDefaultAsync(token);
        if (ticket != null)
        {
            ValidateTicket(ticket);
            if (ticket.ExpiresUtc > transaction.Now.UtcDateTime)
            {
                if (ticket.AttemptId != attempt.AttemptId || ticket.CompatibilityKey != compatibilityKey ||
                    ticket.AttemptExpiresUtc != DateTimeOffset.FromUnixTimeSeconds(
                        attempt.ExpiresUnixSeconds).UtcDateTime ||
                    ticket.JoinedUtc < DateTimeOffset.FromUnixTimeSeconds(attempt.IssuedUnixSeconds).UtcDateTime)
                {
                    throw new InvalidDataException("Another queue ticket owns this player.");
                }

                return ticket;
            }

            await DeleteAttemptTicketAsync(ticket, transaction);
        }

        ticket = new BattleQueueTicketDocument
        {
            Id = Guid.NewGuid().ToString("N"), PlayerId = attempt.PlayerId, AttemptId = attempt.AttemptId,
            CompatibilityKey = compatibilityKey, JoinedUtc = transaction.Now.UtcDateTime,
            ExpiresUtc = transaction.Now.AddSeconds(QueueTicketLifetimeSeconds).UtcDateTime,
            AttemptExpiresUtc = DateTimeOffset.FromUnixTimeSeconds(attempt.ExpiresUnixSeconds).UtcDateTime
        };
        await tickets.InsertOneAsync(transaction.Session, ticket, cancellationToken: token);
        return ticket;
    }

    private async Task<BattlePairingResult> PairAttemptTicketAsync(
        BattleQueueTicketDocument ticket, BattleQueueAttemptDocument receipt, AttemptTransaction transaction)
    {
        var token = transaction.CancellationToken;
        var candidate = await tickets.Find(transaction.Session, row =>
            row.PlayerId != ticket.PlayerId && row.CompatibilityKey == ticket.CompatibilityKey &&
            row.AttemptId != "" && row.AttemptId != null &&
            row.JoinedUtc <= transaction.Now.UtcDateTime && row.ExpiresUtc > transaction.Now.UtcDateTime &&
            row.AttemptExpiresUtc > transaction.Now.UtcDateTime)
            .SortBy(row => row.JoinedUtc).ThenBy(row => row.PlayerId).FirstOrDefaultAsync(token);
        if (candidate == null)
        {
            // This write conflicts with cancellation, including a cancellation of a first delayed join.
            await SaveAttemptAsync(receipt, transaction);
            return new BattlePairingResult("waiting", null, null);
        }

        ValidateTicket(candidate);
        var candidateReceipt = await ReadAttemptAsync(candidate.PlayerId, candidate.AttemptId, transaction) ??
            throw new InvalidDataException("Scoped candidate has no durable attempt receipt.");
        if (candidateReceipt.ExpiresUtc != candidate.AttemptExpiresUtc ||
            candidateReceipt.IssuedUtc > candidate.JoinedUtc)
        {
            throw new InvalidDataException("Candidate ticket and receipt have different admission deadlines.");
        }

        if (candidateReceipt.State != WaitingAttempt)
        {
            throw new InvalidDataException("Candidate ticket contradicts its closed attempt receipt.");
        }

        var pair = new BattlePairDocument
        {
            Id = Guid.NewGuid().ToString("N"), MatchId = "m" + Guid.NewGuid().ToString("N"),
            CompatibilityKey = ticket.CompatibilityKey, CreatedUtc = transaction.Now.UtcDateTime,
            Players = [candidate.PlayerId, ticket.PlayerId], AttemptIds = [candidate.AttemptId, ticket.AttemptId]
        };
        await pairs.InsertOneAsync(transaction.Session, pair, cancellationToken: token);
        await DeleteAttemptTicketAsync(candidate, transaction);
        await DeleteAttemptTicketAsync(ticket, transaction);
        await MarkPairedAsync(candidateReceipt, pair.MatchId, transaction);
        await MarkPairedAsync(receipt, pair.MatchId, transaction);
        return Result("paired", pair);
    }

    private async Task<BattlePairingResult> CancelAttemptCoreAsync(
        BattleQueueAttemptIdentity attempt, AttemptTransaction transaction)
    {
        var receipt = await ReadAttemptAsync(attempt.PlayerId, attempt.AttemptId, transaction);
        ValidateReceiptIdentity(receipt, attempt);
        var pair = await PairFor(transaction.Session, attempt.PlayerId, transaction.CancellationToken);
        if (pair != null)
        {
            _ = Result("paired", pair);
            if (PairOwnsAttempt(pair, attempt))
            {
                if (receipt != null && (receipt.State is not (PairedAttempt or CancellingAttempt) ||
                    receipt.MatchId != pair.MatchId))
                {
                    throw new InvalidDataException("Cancellation receipt differs from its durable pair.");
                }

                if (receipt == null && transaction.Now.ToUnixTimeSeconds() < attempt.ExpiresUnixSeconds)
                {
                    throw new InvalidDataException("Paired attempt has no retained cancellation authority.");
                }

                if (transaction.Now.ToUnixTimeSeconds() < attempt.ExpiresUnixSeconds)
                {
                    receipt ??= CreateAttempt(attempt);
                    receipt.State = CancellingAttempt;
                    receipt.MatchId = pair.MatchId;
                    await SaveAttemptAsync(receipt, transaction);
                }

                await RecordPairCancellationAsync(pair, attempt.PlayerId, attempt.AttemptId, transaction);
                return Result("already-paired", pair);
            }
        }

        var ticket = await tickets.Find(transaction.Session, row => row.PlayerId == attempt.PlayerId)
            .FirstOrDefaultAsync(transaction.CancellationToken);
        bool removed = false;
        if (ticket != null)
        {
            ValidateTicket(ticket);
            if (ticket.AttemptId == attempt.AttemptId)
            {
                if (ticket.AttemptExpiresUtc != DateTimeOffset.FromUnixTimeSeconds(
                        attempt.ExpiresUnixSeconds).UtcDateTime ||
                    ticket.JoinedUtc < DateTimeOffset.FromUnixTimeSeconds(attempt.IssuedUnixSeconds).UtcDateTime ||
                    receipt != null && receipt.State != WaitingAttempt)
                {
                    throw new InvalidDataException("Cancellation ticket contradicts its attempt authority.");
                }

                await DeleteAttemptTicketAsync(ticket, transaction);
                removed = true;
            }
        }

        if (transaction.Now.ToUnixTimeSeconds() < attempt.ExpiresUnixSeconds)
        {
            receipt ??= CreateAttempt(attempt);
            receipt.State = CancelledAttempt;
            receipt.MatchId = "";
            await SaveAttemptAsync(receipt, transaction);
        }

        return new BattlePairingResult(removed ? "cancelled" : "not-queued", null, null);
    }
}
