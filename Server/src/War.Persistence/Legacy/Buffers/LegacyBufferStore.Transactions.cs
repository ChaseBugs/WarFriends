using MongoDB.Driver;
using War.Persistence.Legacy.Buffers;

namespace War.Persistence;

public sealed partial class LegacyBufferStore
{
    private const int MaximumDuplicateRetries = 4;
    private const int TransactionDeadlineSeconds = 30;

    private static readonly TransactionOptions BufferTransactionOptions = new(
        readConcern: ReadConcern.Snapshot,
        readPreference: ReadPreference.Primary,
        writeConcern: WriteConcern.WMajority);

    /// <summary>Commits one effect and its complete replay response in the same MongoDB transaction.</summary>
    public async Task<LegacyBufferedActionResult> ExecuteAsync(
        LegacyBufferedAction request,
        Func<LegacyPlayerDocument, LegacyBufferedMutation> calculate,
        CancellationToken cancellationToken)
    {
        ValidateRequest(request);
        using var deadline = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        deadline.CancelAfter(TimeSpan.FromSeconds(TransactionDeadlineSeconds));
        for (int attempt = 0; ; attempt++)
        {
            using IClientSessionHandle session = await _database.Client.StartSessionAsync(
                cancellationToken: deadline.Token);
            try
            {
                return await session.WithTransactionAsync(
                    (transaction, token) => ExecuteTransactionAsync(transaction, request, calculate, token),
                    BufferTransactionOptions,
                    deadline.Token);
            }
            catch (MongoWriteException exception) when (
                exception.WriteError.Category == ServerErrorCategory.DuplicateKey &&
                attempt < MaximumDuplicateRetries)
            {
                // Two first deliveries can race to insert the same receipt. Read the winner afresh.
            }
        }
    }

    private async Task<LegacyBufferedActionResult> ExecuteTransactionAsync(
        IClientSessionHandle session,
        LegacyBufferedAction request,
        Func<LegacyPlayerDocument, LegacyBufferedMutation> calculate,
        CancellationToken cancellationToken)
    {
        IMongoCollection<LegacyPlayerDocument> players = _database.GetCollection<LegacyPlayerDocument>("legacyPlayers");
        LegacyPlayerDocument player = await players.Find(session, row => row.Id == request.PlayerId)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new InvalidDataException("Buffered action account disappeared.");
        ValidatePlayer(player);
        LegacyBufferReceipt? receipt = await receipts.Find(session,
                row => row.Id == Key(request.PlayerId, request.BufferId))
            .FirstOrDefaultAsync(cancellationToken);
        ValidateReceipt(receipt, request);
        LegacyBufferEntry? recorded = receipt?.Entries.SingleOrDefault(entry => entry.Index == request.Index);
        if (recorded != null)
        {
            string? response = ReadReplay(recorded, request);
            return new LegacyBufferedActionResult(player, response, recorded.Delivery);
        }

        LegacyBufferedMutation mutation = calculate(player);
        ValidateMutation(request, mutation);
        ValidateReceiptCapacity(receipt, mutation.ResponseJson);
        await EnsureReceiptAsync(session, request, cancellationToken);
        LegacyPlayerDocument committed = await WritePlayerAsync(session, player, mutation, cancellationToken);
        await WriteResponseAsync(session, request, mutation, cancellationToken);
        return new LegacyBufferedActionResult(committed, mutation.ResponseJson, mutation.Delivery);
    }

    private Task EnsureReceiptAsync(
        IClientSessionHandle session,
        LegacyBufferedAction request,
        CancellationToken cancellationToken)
    {
        UpdateDefinition<LegacyBufferReceipt> update = Builders<LegacyBufferReceipt>.Update
            .SetOnInsert(row => row.PlayerId, request.PlayerId)
            .SetOnInsert(row => row.BufferId, request.BufferId)
            .SetOnInsert(row => row.CreatedUtc, DateTime.UtcNow);
        return receipts.UpdateOneAsync(session,
            row => row.Id == Key(request.PlayerId, request.BufferId),
            update, new UpdateOptions { IsUpsert = true }, cancellationToken);
    }

    private async Task<LegacyPlayerDocument> WritePlayerAsync(
        IClientSessionHandle session,
        LegacyPlayerDocument player,
        LegacyBufferedMutation mutation,
        CancellationToken cancellationToken)
    {
        var update = Builders<LegacyPlayerDocument>.Update;
        var changes = new List<UpdateDefinition<LegacyPlayerDocument>>
        {
            update.Set(row => row.Gold, mutation.Gold),
            update.Set(row => row.WarBucks, mutation.WarBucks),
            update.Set(row => row.Scraps, mutation.Scraps),
            update.Set(row => row.ArmyPower, mutation.ArmyPower),
            update.Inc(row => row.Revision, 1)
        };
        foreach (KeyValuePair<string, string> replacement in mutation.Serialized)
        {
            changes.Add(update.Set("Serialized." + replacement.Key, replacement.Value));
        }

        IMongoCollection<LegacyPlayerDocument> players = _database.GetCollection<LegacyPlayerDocument>("legacyPlayers");
        FilterDefinition<LegacyPlayerDocument> filter = Builders<LegacyPlayerDocument>.Filter.Where(
            row => row.Id == player.Id && row.Revision == player.Revision);
        LegacyPlayerDocument? committed = await players.FindOneAndUpdateAsync(session,
            filter,
            update.Combine(changes),
            new FindOneAndUpdateOptions<LegacyPlayerDocument> { ReturnDocument = ReturnDocument.After },
            cancellationToken);
        if (committed == null)
        {
            throw new InvalidDataException("Buffered account revision did not match its transaction read.");
        }

        ValidatePlayer(committed);
        return committed;
    }

    private async Task WriteResponseAsync(
        IClientSessionHandle session,
        LegacyBufferedAction request,
        LegacyBufferedMutation mutation,
        CancellationToken cancellationToken)
    {
        var entry = new LegacyBufferEntry
        {
            Index = request.Index,
            ActionId = request.ActionId,
            PayloadDigest = request.PayloadDigest,
            Result = mutation.Result,
            ResponseJson = mutation.ResponseJson,
            Delivery = mutation.Delivery
        };
        UpdateResult result = await receipts.UpdateOneAsync(session,
            row => row.Id == Key(request.PlayerId, request.BufferId),
            Builders<LegacyBufferReceipt>.Update.Push(row => row.Entries, entry),
            cancellationToken: cancellationToken);
        if (result.ModifiedCount != 1)
        {
            throw new InvalidDataException("Buffered response was not published.");
        }
    }
}
