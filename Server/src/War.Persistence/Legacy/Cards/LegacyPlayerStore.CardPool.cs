using System.Text.RegularExpressions;
using MongoDB.Driver;
using War.Persistence.Legacy.Cards;
using War.Persistence.Legacy.State;

namespace War.Persistence;

public sealed partial class LegacyPlayerStore
{
    private const int CardPoolSuccess = 1;
    private const int CardPoolWrongPlayerData = 11301;
    private const int CardPoolDepositAction = 174;
    private const int CardPoolWithdrawAction = 175;
    private const int CardPoolDeadlineSeconds = 30;
    private const int CardPoolDuplicateRetries = 4;

    private static readonly TransactionOptions CardPoolTransactionOptions = new(
        readConcern: ReadConcern.Snapshot,
        readPreference: ReadPreference.Primary,
        writeConcern: WriteConcern.WMajority);

    private IMongoCollection<LegacyCardPoolReceipt> CardPoolReceipts =>
        players.Database.GetCollection<LegacyCardPoolReceipt>("legacyCardPoolReceipts");

    private Task InitializeCardPoolAsync(CancellationToken cancellationToken)
    {
        var keys = Builders<LegacyCardPoolReceipt>.IndexKeys.Ascending(row => row.ActorId)
            .Ascending(row => row.ActionId).Ascending(row => row.NextWithdraw);
        return CardPoolReceipts.Indexes.CreateOneAsync(new CreateIndexModel<LegacyCardPoolReceipt>(keys),
            cancellationToken: cancellationToken);
    }

    /// <summary>Commits card ownership, pool stock, cooldown, reputation and receipt as one transfer.</summary>
    public async Task<LegacyCardPoolResult> ApplyCardPoolAsync(
        LegacyCardPoolOperation operation,
        Func<LegacyCardPoolSnapshot, LegacyCardPoolMutation> calculate,
        CancellationToken cancellationToken)
    {
        ValidateCardPoolOperation(operation);
        string receiptId = operation.ActorId + (operation.OperationId == null
            ? ":audit:" + Guid.NewGuid().ToString("N") : ":op:" + operation.OperationId);
        using var deadline = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        deadline.CancelAfter(TimeSpan.FromSeconds(CardPoolDeadlineSeconds));
        for (int attempt = 0; ; attempt++)
        {
            using IClientSessionHandle session = await players.Database.Client.StartSessionAsync(
                cancellationToken: deadline.Token);
            try
            {
                return await session.WithTransactionAsync(
                    (transaction, token) => ApplyCardPoolTransactionAsync(transaction,
                        new CardPoolExecution(operation, receiptId, calculate), token),
                    CardPoolTransactionOptions, deadline.Token);
            }
            catch (MongoWriteException exception) when (
                exception.WriteError.Category == ServerErrorCategory.DuplicateKey && attempt < CardPoolDuplicateRetries)
            {
                // Concurrent first deliveries re-read the operation's committed receipt.
            }
        }
    }

    private async Task<LegacyCardPoolResult> ApplyCardPoolTransactionAsync(
        IClientSessionHandle session, CardPoolExecution execution, CancellationToken cancellationToken)
    {
        LegacyCardPoolOperation operation = execution.Operation;
        LegacyCardPoolSnapshot snapshot = await ReadCardPoolSnapshotAsync(session, operation, cancellationToken);
        LegacyCardPoolMutation? mutation = operation.OperationId == null ? execution.Calculate(snapshot) : null;
        LegacyCardPoolReceipt? receipt = await FindCardPoolReceiptAsync(session,
            new CardPoolReceiptLookup(execution, mutation?.NextWithdraw ?? 0), cancellationToken);
        if (receipt != null)
        {
            return ReplayCardPoolReceipt(receipt, operation, snapshot.Actor);
        }

        mutation ??= execution.Calculate(snapshot);
        ValidateCardPoolMutation(operation, snapshot, mutation);
        if (mutation.Result == CardPoolSuccess)
        {
            await WriteCardPoolTransferAsync(session, snapshot, mutation, cancellationToken);
        }

        if (mutation.Result == CardPoolSuccess || operation.OperationId != null)
        {
            await CardPoolReceipts.InsertOneAsync(session, new LegacyCardPoolReceipt
            {
                Id = execution.ReceiptId,
                ActorId = operation.ActorId,
                ActionId = operation.ActionId,
                PayloadDigest = operation.PayloadDigest,
                Result = mutation.Result,
                NextWithdraw = mutation.NextWithdraw,
                CreatedUtc = DateTimeOffset.FromUnixTimeSeconds(operation.NowUnixSeconds).UtcDateTime
            }, cancellationToken: cancellationToken);
        }

        LegacyPlayerDocument current = await players.Find(session, row => row.Id == operation.ActorId)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidDataException("Card-pool actor disappeared.");
        return new LegacyCardPoolResult(mutation.Result, mutation.NextWithdraw, current);
    }

    private async Task<LegacyCardPoolSnapshot> ReadCardPoolSnapshotAsync(
        IClientSessionHandle session, LegacyCardPoolOperation operation, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument actor = await players.Find(session, row => row.Id == operation.ActorId)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidDataException("Card-pool actor disappeared.");
        LegacyPlayerIdentityAuthority.Validate(actor);
        LegacyPlayerEconomyAuthority.Validate(actor);
        LegacyPlayerDocument? donor = null;
        if (operation.DonorId != null && operation.DonorId != actor.Id)
        {
            donor = await players.Find(session, row => row.Id == operation.DonorId)
                .FirstOrDefaultAsync(cancellationToken);
            if (donor != null)
            {
                LegacyPlayerIdentityAuthority.Validate(donor);
                LegacyPlayerEconomyAuthority.Validate(donor);
            }
        }

        LegacySquadDocument? squad = null;
        if (operation.ActionId == CardPoolWithdrawAction && !string.IsNullOrEmpty(actor.SquadId))
        {
            squad = await players.Database.GetCollection<LegacySquadDocument>("legacySquads")
                .Find(session, row => row.Id == actor.SquadId).FirstOrDefaultAsync(cancellationToken);
        }

        return new LegacyCardPoolSnapshot(actor, donor, squad);
    }

    private async Task<LegacyCardPoolReceipt?> FindCardPoolReceiptAsync(
        IClientSessionHandle session, CardPoolReceiptLookup lookup, CancellationToken cancellationToken)
    {
        CardPoolExecution execution = lookup.Execution;
        LegacyCardPoolOperation operation = execution.Operation;
        if (operation.OperationId != null)
        {
            return await CardPoolReceipts.Find(session, row => row.Id == execution.ReceiptId)
                .FirstOrDefaultAsync(cancellationToken);
        }

        if (operation.ActionId != CardPoolWithdrawAction)
        {
            return null;
        }

        // A matching active cooldown fences ordinary Client retries, not a new post-cooldown intent.
        return await CardPoolReceipts.Find(session, row => row.ActorId == operation.ActorId &&
                row.ActionId == CardPoolWithdrawAction && row.Result == CardPoolSuccess &&
                row.NextWithdraw == lookup.NextWithdraw && row.NextWithdraw > operation.NowUnixSeconds &&
                row.PayloadDigest == operation.PayloadDigest)
            .SortByDescending(row => row.NextWithdraw).FirstOrDefaultAsync(cancellationToken);
    }

    private static LegacyCardPoolResult ReplayCardPoolReceipt(
        LegacyCardPoolReceipt receipt, LegacyCardPoolOperation operation, LegacyPlayerDocument actor)
    {
        DateTime nowUtc = DateTimeOffset.FromUnixTimeSeconds(operation.NowUnixSeconds).UtcDateTime;
        if (receipt.ActorId != operation.ActorId || receipt.Result is > 1 and <= 10 || receipt.Result <= 0 ||
            receipt.NextWithdraw < 0 || receipt.CreatedUtc < DateTime.UnixEpoch || receipt.CreatedUtc > nowUtc ||
            receipt.ActionId is not (CardPoolDepositAction or CardPoolWithdrawAction) ||
            !Regex.IsMatch(receipt.PayloadDigest, "\\A[0-9a-f]{64}\\z"))
        {
            throw new InvalidDataException("Invalid card-pool receipt authority.");
        }

        if (receipt.ActionId != operation.ActionId || receipt.PayloadDigest != operation.PayloadDigest)
        {
            return new LegacyCardPoolResult(CardPoolWrongPlayerData, 0, actor);
        }

        return new LegacyCardPoolResult(receipt.Result, receipt.NextWithdraw, actor);
    }

    private static void ValidateCardPoolOperation(LegacyCardPoolOperation operation)
    {
        if (string.IsNullOrEmpty(operation.ActorId) || operation.NowUnixSeconds < 0 ||
            operation.ActionId is not (CardPoolDepositAction or CardPoolWithdrawAction) ||
            operation.ActionId == CardPoolWithdrawAction && string.IsNullOrEmpty(operation.DonorId) ||
            operation.ActionId == CardPoolDepositAction && operation.DonorId != null ||
            !Regex.IsMatch(operation.PayloadDigest, "\\A[0-9a-f]{64}\\z") ||
            operation.OperationId != null && !Regex.IsMatch(operation.OperationId, "\\A[a-zA-Z0-9_-]{1,64}\\z"))
        {
            throw new InvalidDataException("Invalid card-pool operation identity.");
        }
    }

    private static void ValidateCardPoolMutation(
        LegacyCardPoolOperation operation, LegacyCardPoolSnapshot snapshot, LegacyCardPoolMutation mutation)
    {
        if (mutation.Result <= 0 || mutation.Result is > 1 and <= 10 || mutation.NextWithdraw < 0 ||
            mutation.Result != CardPoolSuccess && (mutation.ActorCards != null || mutation.ActorDeposits != null ||
                mutation.DonorDeposits != null || mutation.DonorReputation != null || mutation.NeedsSquadFence))
        {
            throw new InvalidDataException("Invalid card-pool mutation outcome.");
        }

        if (mutation.Result == CardPoolSuccess && (string.IsNullOrEmpty(mutation.ActorCards) ||
            snapshot.Actor.Revision < 0 || snapshot.Actor.Revision == long.MaxValue ||
            operation.ActionId == CardPoolDepositAction && (mutation.ActorDeposits == null ||
                mutation.DonorDeposits != null || mutation.DonorReputation != null || mutation.NeedsSquadFence) ||
            operation.ActionId == CardPoolWithdrawAction && (snapshot.Donor == null || snapshot.Squad == null ||
                snapshot.Donor.Id == snapshot.Actor.Id || mutation.ActorDeposits != null ||
                mutation.DonorDeposits == null || mutation.DonorReputation is null or < 0 ||
                !mutation.NeedsSquadFence || mutation.NextWithdraw <= operation.NowUnixSeconds)))
        {
            throw new InvalidDataException("Incomplete card-pool mutation authority.");
        }
    }

    private sealed record CardPoolExecution(
        LegacyCardPoolOperation Operation,
        string ReceiptId,
        Func<LegacyCardPoolSnapshot, LegacyCardPoolMutation> Calculate);

    private sealed record CardPoolReceiptLookup(CardPoolExecution Execution, int NextWithdraw);
}
