using MongoDB.Driver;
using War.Shared;

namespace War.Persistence;

/// <summary>Prepares battle authority from one locked durable account revision.</summary>
public sealed class BattleAllocationPreparationStore
{
    private static readonly TransactionOptions PreparationTransaction = new(
        readConcern: ReadConcern.Snapshot, writeConcern: WriteConcern.WMajority);
    private readonly MongoClient _client;
    private readonly IMongoCollection<LegacyPlayerDocument> _players;
    private readonly IMongoCollection<BattleAllocationDocument> _allocations;

    /// <summary>Uses the same database for account and battle authority so publication is atomic.</summary>
    public BattleAllocationPreparationStore(string uri, string databaseName)
    {
        _client = new MongoClient(uri);
        IMongoDatabase database = _client.GetDatabase(databaseName);
        _players = database.GetCollection<LegacyPlayerDocument>("legacyPlayers");
        _allocations = database.GetCollection<BattleAllocationDocument>("battle_allocations");
    }

    /// <summary>Rejects stale account revisions and preserves any existing validated allocation.</summary>
    public Task PrepareAsync(string playerId, long expectedRevision,
        Func<LegacyPlayerDocument, BattleAllocationProjection> project, CancellationToken cancellationToken)
    {
        return ExecuteAsync(new PreparationRequest(playerId, expectedRevision, project),
            PreparationMode.CreateOnly, cancellationToken);
    }

    /// <summary>Refreshes valid inactive authority from current account state without changing active battles.</summary>
    public Task RefreshInactiveAsync(string playerId, long expectedRevision,
        Func<LegacyPlayerDocument, BattleAllocationProjection> project, CancellationToken cancellationToken)
    {
        return ExecuteAsync(new PreparationRequest(playerId, expectedRevision, project),
            PreparationMode.RefreshInactive, cancellationToken);
    }

    private async Task ExecuteAsync(PreparationRequest request, PreparationMode mode,
        CancellationToken cancellationToken)
    {
        string playerId = request.PlayerId;
        long expectedRevision = request.ExpectedRevision;
        Func<LegacyPlayerDocument, BattleAllocationProjection> project = request.Project;
        if (!War.Shared.CanonicalGuid.IsCanonical(playerId) ||
            expectedRevision < 1 || expectedRevision == long.MaxValue || project == null)
        {
            throw new InvalidDataException("Invalid initial battle preparation authority.");
        }

        using IClientSessionHandle session = await _client.StartSessionAsync(cancellationToken: cancellationToken);
        await session.WithTransactionAsync(async (transaction, token) =>
        {
            await BattleAdmissionFence.AcquireAsync(_allocations.Database, transaction, [playerId], token);
            await RequireInactiveAsync(transaction, playerId, token);
            LegacyPlayerDocument player = await _players.Find(transaction, row => row.Id == playerId)
                .SingleOrDefaultAsync(token) ?? throw new InvalidDataException("Battle account is missing.");
            if (player.Revision != expectedRevision)
            {
                throw new InvalidDataException("Battle account changed before initial allocation.");
            }

            BattleAllocationProjection allocation = BattleAllocationProjection.Validate(project(player));
            if (allocation.PlayerId != playerId)
            {
                throw new InvalidDataException("Projected battle allocation belongs to another account.");
            }

            BattleAllocationDocument? existing = await _allocations.Find(transaction, row => row.PlayerId == playerId)
                .SingleOrDefaultAsync(token);
            if (existing != null)
            {
                BattleAllocationProjection previous = BattleAllocationStore.ValidateDocument(existing);
                if (mode == PreparationMode.CreateOnly || HasSameContents(previous, allocation))
                {
                    return false;
                }
            }

            await PublishAsync(transaction, new AllocationWrite(playerId, expectedRevision, allocation, existing), token);
            return true;
        }, PreparationTransaction, cancellationToken);
    }

    private async Task RequireInactiveAsync(IClientSessionHandle session, string playerId,
        CancellationToken cancellationToken)
    {
        IMongoDatabase database = _allocations.Database;
        var pairs = database.GetCollection<BattlePairDocument>("battle_pairs");
        bool hasPair = await pairs.Find(session,
            Builders<BattlePairDocument>.Filter.AnyEq(row => row.Players, playerId)).AnyAsync(cancellationToken);
        var tickets = database.GetCollection<BattleQueueTicketDocument>("battle_queue_tickets");
        bool hasTicket = await tickets.Find(session, row => row.PlayerId == playerId).AnyAsync(cancellationToken);
        if (hasPair || hasTicket)
        {
            throw new InvalidDataException("Active queue or battle ownership prevents allocation preparation.");
        }
    }

    private async Task PublishAsync(IClientSessionHandle session, AllocationWrite write,
        CancellationToken cancellationToken)
    {
        // A real account write makes concurrent inventory changes conflict with this transaction's snapshot.
        UpdateResult locked = await _players.UpdateOneAsync(session,
            row => row.Id == write.PlayerId && row.Revision == write.ExpectedRevision,
            Builders<LegacyPlayerDocument>.Update.Inc(row => row.Revision, 1L), cancellationToken: cancellationToken);
        if (locked.ModifiedCount != 1)
        {
            throw new InvalidDataException("Battle account revision could not be reserved.");
        }
        BattleAllocationDocument document = CreateDocument(write.Projection);
        if (write.Prior == null)
        {
            await _allocations.InsertOneAsync(session, document, cancellationToken: cancellationToken);
            return;
        }
        document.Revision = checked(write.Prior.Revision + 1);
        ReplaceOneResult replaced = await _allocations.ReplaceOneAsync(session,
            row => row.PlayerId == write.PlayerId && row.Revision == write.Prior.Revision,
            document, cancellationToken: cancellationToken);
        if (replaced.ModifiedCount != 1)
        {
            throw new InvalidDataException("Battle allocation changed before inactive refresh.");
        }
    }

    private static bool HasSameContents(BattleAllocationProjection previous, BattleAllocationProjection current)
    {
        return previous.PlayerId == current.PlayerId &&
            previous.CardIds.SequenceEqual(current.CardIds, StringComparer.Ordinal) &&
            previous.CardCounts.SequenceEqual(current.CardCounts) &&
            previous.BuddyCardIds.SequenceEqual(current.BuddyCardIds, StringComparer.Ordinal) &&
            previous.NormalUpgradeIndexes.SequenceEqual(current.NormalUpgradeIndexes) &&
            previous.SpecialUpgradeIndexes.SequenceEqual(current.SpecialUpgradeIndexes) &&
            previous.EliteUpgradeIndexes.SequenceEqual(current.EliteUpgradeIndexes);
    }

    private static BattleAllocationDocument CreateDocument(BattleAllocationProjection allocation)
    {
        return new BattleAllocationDocument
        {
            PlayerId = allocation.PlayerId,
            CardIds = allocation.CardIds.ToArray(),
            CardCounts = allocation.CardCounts.ToArray(),
            BuddyCardIds = allocation.BuddyCardIds.ToArray(),
            NormalUpgradeIndexes = allocation.NormalUpgradeIndexes.ToArray(),
            SpecialUpgradeIndexes = allocation.SpecialUpgradeIndexes.ToArray(),
            EliteUpgradeIndexes = allocation.EliteUpgradeIndexes.ToArray(),
            Revision = 1
        };
    }

    private enum PreparationMode
    {
        CreateOnly,
        RefreshInactive
    }

    private readonly record struct PreparationRequest(string PlayerId, long ExpectedRevision,
        Func<LegacyPlayerDocument, BattleAllocationProjection> Project);

    private readonly record struct AllocationWrite(string PlayerId, long ExpectedRevision,
        BattleAllocationProjection Projection, BattleAllocationDocument? Prior);
}
