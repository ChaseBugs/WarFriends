using MongoDB.Driver;
using War.Shared;

namespace War.Persistence;

/// <summary>Creates initial battle authority from one locked durable account revision.</summary>
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
    public async Task PrepareAsync(string playerId, long expectedRevision,
        Func<LegacyPlayerDocument, BattleAllocationProjection> project, CancellationToken cancellationToken)
    {
        if (!Guid.TryParseExact(playerId, "N", out Guid identity) || identity.ToString("N") != playerId ||
            expectedRevision < 1 || expectedRevision == long.MaxValue || project == null)
        {
            throw new InvalidDataException("Invalid initial battle preparation authority.");
        }

        using IClientSessionHandle session = await _client.StartSessionAsync(cancellationToken: cancellationToken);
        await session.WithTransactionAsync(async (transaction, token) =>
        {
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
                ValidateExisting(existing);
                return false;
            }

            // A real account write makes concurrent inventory changes conflict with this transaction's snapshot.
            UpdateResult locked = await _players.UpdateOneAsync(transaction,
                row => row.Id == playerId && row.Revision == expectedRevision,
                Builders<LegacyPlayerDocument>.Update.Inc(row => row.Revision, 1L), cancellationToken: token);
            if (locked.ModifiedCount != 1)
            {
                throw new InvalidDataException("Battle account revision could not be reserved.");
            }
            await _allocations.InsertOneAsync(transaction, CreateDocument(allocation), cancellationToken: token);
            return true;
        }, PreparationTransaction, cancellationToken);
    }

    private static void ValidateExisting(BattleAllocationDocument document)
    {
        _ = BattleAllocationProjection.Validate(new BattleAllocationProjection(document.PlayerId,
            document.CardIds, document.BuddyCardIds, document.NormalUpgradeIndexes,
            document.SpecialUpgradeIndexes, document.EliteUpgradeIndexes)
        {
            CardCounts = document.CardCounts
        });
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
}
