using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using War.Shared;

namespace War.Persistence;

public sealed class BattleAllocationDocument
{
    [BsonId] public string PlayerId { get; set; } = "";
    public string[] CardIds { get; set; } = Array.Empty<string>();
    public string[] BuddyCardIds { get; set; } = Array.Empty<string>();
    public int[] NormalUpgradeIndexes { get; set; } = Array.Empty<int>();
    public int[] SpecialUpgradeIndexes { get; set; } = Array.Empty<int>();
    public int[] EliteUpgradeIndexes { get; set; } = Array.Empty<int>();
    public long Revision { get; set; } = 1;
}

public sealed class BattleAllocationStore
{
    private readonly IMongoCollection<BattleAllocationDocument> allocations;
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
            NormalUpgradeIndexes = value.NormalUpgradeIndexes.ToArray(), SpecialUpgradeIndexes = value.SpecialUpgradeIndexes.ToArray(),
            EliteUpgradeIndexes = value.EliteUpgradeIndexes.ToArray()
        };
        var update = Builders<BattleAllocationDocument>.Update
            .SetOnInsert(x => x.PlayerId, document.PlayerId)
            .Set(x => x.CardIds, document.CardIds)
            .Set(x => x.BuddyCardIds, document.BuddyCardIds)
            .Set(x => x.NormalUpgradeIndexes, document.NormalUpgradeIndexes)
            .Set(x => x.SpecialUpgradeIndexes, document.SpecialUpgradeIndexes)
            .Set(x => x.EliteUpgradeIndexes, document.EliteUpgradeIndexes)
            .SetOnInsert(x => x.Revision, 0L)
            .Inc(x => x.Revision, 1L);
        await allocations.UpdateOneAsync(x => x.PlayerId == value.PlayerId, update,
            new UpdateOptions { IsUpsert = true }, ct);
    }
    public async Task<BattleAllocationProjection?> Get(string playerId, CancellationToken ct)
    {
        var document = await allocations.Find(x => x.PlayerId == playerId).FirstOrDefaultAsync(ct);
        if (document == null) return null;
        return BattleAllocationProjection.Validate(new BattleAllocationProjection(document.PlayerId,
            document.CardIds, document.BuddyCardIds, document.NormalUpgradeIndexes,
            document.SpecialUpgradeIndexes, document.EliteUpgradeIndexes));
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
                d.NormalUpgradeIndexes, d.SpecialUpgradeIndexes, d.EliteUpgradeIndexes));
        }).ToArray());
    }
}
