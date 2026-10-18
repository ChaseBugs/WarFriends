using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using War.Shared;

namespace War.Persistence;

public sealed class BattleAllocationDocument
{
    [BsonId] public string PlayerId { get; set; } = "";
    public string[] CardIds { get; set; } = Array.Empty<string>();
    public int[] CardCounts { get; set; } = Array.Empty<int>();
    public string[] BuddyCardIds { get; set; } = Array.Empty<string>();
    public int[] NormalUpgradeIndexes { get; set; } = Array.Empty<int>();
    public int[] SpecialUpgradeIndexes { get; set; } = Array.Empty<int>();
    public int[] EliteUpgradeIndexes { get; set; } = Array.Empty<int>();
    public long Revision { get; set; } = 1;
}

public sealed partial class BattleAllocationStore
{
    private readonly IMongoCollection<BattleAllocationDocument> allocations;

    /// <summary>Uses an existing database and its client session configuration.</summary>
    public BattleAllocationStore(IMongoDatabase database)
    {
        ArgumentNullException.ThrowIfNull(database);
        allocations = database.GetCollection<BattleAllocationDocument>("battle_allocations");
    }

    public BattleAllocationStore(string uri, string databaseName)
    {
        var settings = MongoClientSettings.FromConnectionString(uri);
        settings.ServerSelectionTimeout = TimeSpan.FromSeconds(5);
        allocations = new MongoClient(settings).GetDatabase(databaseName)
            .GetCollection<BattleAllocationDocument>("battle_allocations");
    }
    public async Task Initialize(CancellationToken ct)
    {
        await allocations.Indexes.CreateOneAsync(
            new CreateIndexModel<BattleAllocationDocument>(Builders<BattleAllocationDocument>.IndexKeys.Ascending(x => x.Revision)), cancellationToken: ct);
    }
    public async Task Put(BattleAllocationProjection projection, CancellationToken ct)
    {
        var value = BattleAllocationProjection.Validate(projection);
        var document = new BattleAllocationDocument
        {
            PlayerId = value.PlayerId, CardIds = value.CardIds.ToArray(), BuddyCardIds = value.BuddyCardIds.ToArray(),
            CardCounts = value.CardCounts.ToArray(),
            NormalUpgradeIndexes = value.NormalUpgradeIndexes.ToArray(), SpecialUpgradeIndexes = value.SpecialUpgradeIndexes.ToArray(),
            EliteUpgradeIndexes = value.EliteUpgradeIndexes.ToArray()
        };
        var update = Builders<BattleAllocationDocument>.Update
            .SetOnInsert(x => x.PlayerId, document.PlayerId)
            .Set(x => x.CardIds, document.CardIds)
            .Set(x => x.CardCounts, document.CardCounts)
            .Set(x => x.BuddyCardIds, document.BuddyCardIds)
            .Set(x => x.NormalUpgradeIndexes, document.NormalUpgradeIndexes)
            .Set(x => x.SpecialUpgradeIndexes, document.SpecialUpgradeIndexes)
            .Set(x => x.EliteUpgradeIndexes, document.EliteUpgradeIndexes)
            .Inc(x => x.Revision, 1L);
        await allocations.UpdateOneAsync(x => x.PlayerId == value.PlayerId, update,
            new UpdateOptions { IsUpsert = true }, ct);
    }

    /// <summary>Creates absent authority without replacing an existing allocation or advancing its revision.</summary>
    public async Task CreateIfMissing(BattleAllocationProjection projection, CancellationToken cancellationToken)
    {
        BattleAllocationProjection value = BattleAllocationProjection.Validate(projection);
        var update = Builders<BattleAllocationDocument>.Update
            .SetOnInsert(row => row.PlayerId, value.PlayerId)
            .SetOnInsert(row => row.CardIds, value.CardIds.ToArray())
            .SetOnInsert(row => row.CardCounts, value.CardCounts.ToArray())
            .SetOnInsert(row => row.BuddyCardIds, value.BuddyCardIds.ToArray())
            .SetOnInsert(row => row.NormalUpgradeIndexes, value.NormalUpgradeIndexes.ToArray())
            .SetOnInsert(row => row.SpecialUpgradeIndexes, value.SpecialUpgradeIndexes.ToArray())
            .SetOnInsert(row => row.EliteUpgradeIndexes, value.EliteUpgradeIndexes.ToArray())
            .SetOnInsert(row => row.Revision, 1L);

        try
        {
            await allocations.UpdateOneAsync(row => row.PlayerId == value.PlayerId, update,
                new UpdateOptions { IsUpsert = true }, cancellationToken);
        }
        catch (MongoWriteException failure) when (failure.WriteError.Category == ServerErrorCategory.DuplicateKey)
        {
            // A concurrent initializer may win the primary-key insert; its complete row still must validate below.
        }
        // Existing damaged authority must fail rather than being repaired into newly spendable inventory.
        _ = await Get(value.PlayerId, cancellationToken)
            ?? throw new InvalidDataException("Battle allocation disappeared after initialization.");
    }
    public async Task<BattleAllocationProjection?> Get(string playerId, CancellationToken ct)
    {
        var document = await allocations.Find(x => x.PlayerId == playerId).FirstOrDefaultAsync(ct);
        if (document == null) return null;
        return BattleAllocationProjection.Validate(new BattleAllocationProjection(document.PlayerId,
            document.CardIds, document.BuddyCardIds, document.NormalUpgradeIndexes,
            document.SpecialUpgradeIndexes, document.EliteUpgradeIndexes)
        {
            CardCounts = document.CardCounts
        });
    }
    public async Task<IReadOnlyList<BattleAllocationProjection>> GetMany(IEnumerable<string> playerIds, CancellationToken ct)
    {
        var ids = (playerIds ?? throw new ArgumentNullException(nameof(playerIds))).ToArray();
        if (ids.Length == 0 || ids.Length > 2 || ids.Any(string.IsNullOrWhiteSpace) ||
            ids.Distinct(StringComparer.Ordinal).Count() != ids.Length)
            throw new InvalidDataException("Invalid battle allocation participant set.");
        var docs = await allocations.Find(Builders<BattleAllocationDocument>.Filter.In(x => x.PlayerId, ids)).ToListAsync(ct);
        if (docs.Count != ids.Length || docs.Select(x => x.PlayerId).Distinct(StringComparer.Ordinal).Count() != ids.Length)
            throw new InvalidDataException("Battle allocation is incomplete.");
        var byId = docs.ToDictionary(x => x.PlayerId, StringComparer.Ordinal);
        return Array.AsReadOnly(ids.Select(id =>
        {
            var d = byId[id];
            return BattleAllocationProjection.Validate(new BattleAllocationProjection(d.PlayerId, d.CardIds, d.BuddyCardIds,
                d.NormalUpgradeIndexes, d.SpecialUpgradeIndexes, d.EliteUpgradeIndexes)
            {
                CardCounts = d.CardCounts
            });
        }).ToArray());
    }
}
