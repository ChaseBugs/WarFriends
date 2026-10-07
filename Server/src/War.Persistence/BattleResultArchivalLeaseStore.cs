using MongoDB.Driver;

namespace War.Persistence;

public sealed class BattleResultArchivalLeaseDocument
{
    public string Id { get; set; } = "battle-results";
    public string OwnerId { get; set; } = "";
    public DateTime ExpiresUtc { get; set; }
}

/// <summary>Coordinates archival passes between Backend processes.</summary>
public sealed class BattleResultArchivalLeaseStore
{
    private readonly IMongoCollection<BattleResultArchivalLeaseDocument> leases;

    public BattleResultArchivalLeaseStore(string uri, string databaseName)
    {
        var settings = MongoClientSettings.FromConnectionString(uri);
        settings.ServerSelectionTimeout = TimeSpan.FromSeconds(5);
        leases = new MongoClient(settings).GetDatabase(databaseName)
            .GetCollection<BattleResultArchivalLeaseDocument>("battle_maintenance_leases");
    }

    public async Task<bool> TryAcquire(string ownerId, DateTime nowUtc, TimeSpan lifetime, CancellationToken ct)
    {
        ValidateArguments(ownerId, nowUtc, lifetime);
        DateTime expiry = nowUtc.Add(lifetime);
        var filter = Builders<BattleResultArchivalLeaseDocument>.Filter;
        var available = filter.Eq(x => x.Id, "battle-results") &
            (filter.Eq(x => x.OwnerId, ownerId) | filter.Lte(x => x.ExpiresUtc, nowUtc));
        var update = Builders<BattleResultArchivalLeaseDocument>.Update
            .Set(x => x.OwnerId, ownerId).Set(x => x.ExpiresUtc, expiry);

        try
        {
            var result = await leases.UpdateOneAsync(available, update,
                new UpdateOptions { IsUpsert = true }, ct);
            return result.MatchedCount == 1 || result.UpsertedId != null;
        }
        catch (MongoWriteException exception) when
            (exception.WriteError.Category == ServerErrorCategory.DuplicateKey)
        {
            // Another process owns the one durable lease row.
            return false;
        }
    }

    public async Task Release(string ownerId, CancellationToken ct)
    {
        if (!Guid.TryParseExact(ownerId, "N", out _))
            throw new InvalidDataException("Invalid battle archival lease owner.");

        await leases.DeleteOneAsync(x => x.Id == "battle-results" && x.OwnerId == ownerId, ct);
    }

    private static void ValidateArguments(string ownerId, DateTime nowUtc, TimeSpan lifetime)
    {
        if (!Guid.TryParseExact(ownerId, "N", out _) ||
            nowUtc.Kind != DateTimeKind.Utc || nowUtc < DateTime.UnixEpoch ||
            lifetime <= TimeSpan.Zero || lifetime > TimeSpan.FromMinutes(10) ||
            nowUtc > DateTime.MaxValue - lifetime)
            throw new InvalidDataException("Invalid battle archival lease request.");
    }
}
