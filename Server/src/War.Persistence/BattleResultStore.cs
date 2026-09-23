using MongoDB.Driver;

namespace War.Persistence;

public sealed class BattleResultDocument
{
    public string Id { get; set; } = "";
    public string MatchId { get; set; } = "";
    public string Digest { get; set; } = "";
    public byte[] Snapshot { get; set; } = Array.Empty<byte>();
    public DateTime AcceptedUtc { get; set; }
    public bool Scored { get; set; }
    public DateTime? ScoredUtc { get; set; }
}

public sealed class BattleResultStore
{
    private readonly IMongoCollection<BattleResultDocument> results;
    public BattleResultStore(string uri, string databaseName)
    {
        var settings = MongoClientSettings.FromConnectionString(uri);
        settings.ServerSelectionTimeout = TimeSpan.FromSeconds(5);
        results = new MongoClient(settings).GetDatabase(databaseName).GetCollection<BattleResultDocument>("battle_results");
    }
    public async Task Initialize(CancellationToken ct)
    {
        await results.Indexes.CreateManyAsync(new[]
        {
            new CreateIndexModel<BattleResultDocument>(Builders<BattleResultDocument>.IndexKeys.Ascending(x => x.MatchId), new CreateIndexOptions { Unique = true }),
            new CreateIndexModel<BattleResultDocument>(Builders<BattleResultDocument>.IndexKeys.Ascending(x => x.AcceptedUtc))
        }, ct);
    }
    public async Task<string> Accept(string matchId, string digest, byte[] snapshot, CancellationToken ct)
    {
        var checkedSnapshot = snapshot ?? throw new InvalidDataException("Missing battle result snapshot.");
        var checkedMatchId = matchId ?? throw new InvalidDataException("Missing battle result ID.");
        var checkedDigest = digest ?? throw new InvalidDataException("Missing battle result digest.");
        if (!System.Text.RegularExpressions.Regex.IsMatch(checkedMatchId, @"\A[a-zA-Z0-9_-]{1,64}\z") ||
            !System.Text.RegularExpressions.Regex.IsMatch(checkedDigest, @"\A[0-9a-f]{64}\z") ||
            checkedSnapshot.Length is < 1 or > 65536)
            throw new InvalidDataException("Invalid battle result envelope.");
        var prior = await results.Find(x => x.MatchId == checkedMatchId).FirstOrDefaultAsync(ct);
        if (prior != null)
            return string.Equals(prior.Digest, checkedDigest, StringComparison.Ordinal) ? "already-accepted" : "conflict";
        var doc = new BattleResultDocument { Id = Guid.NewGuid().ToString("N"), MatchId = checkedMatchId,
            Digest = checkedDigest, Snapshot = checkedSnapshot.ToArray(), AcceptedUtc = DateTime.UtcNow };
        try { await results.InsertOneAsync(doc, cancellationToken: ct); return "accepted"; }
        catch (MongoWriteException e) when (e.WriteError.Category == ServerErrorCategory.DuplicateKey)
        {
            prior = await results.Find(x => x.MatchId == checkedMatchId).FirstOrDefaultAsync(ct);
            return prior != null && prior.Digest == checkedDigest ? "already-accepted" : "conflict";
        }
    }
    public async Task<BattleResultDocument?> Get(string matchId, CancellationToken ct)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch(matchId ?? "", @"\A[a-zA-Z0-9_-]{1,64}\z"))
            throw new InvalidDataException("Invalid battle result ID.");
        var result = await results.Find(x => x.MatchId == matchId).FirstOrDefaultAsync(ct);
        if (result == null) return null;
        if (!System.Text.RegularExpressions.Regex.IsMatch(result.Digest ?? "", @"\A[0-9a-f]{64}\z") ||
            result.Snapshot is not { Length: > 0 and <= 65536 })
            throw new InvalidDataException("Invalid persisted battle result.");
        result.Snapshot = result.Snapshot.ToArray();
        return result;
    }
    public async Task<long> Prune(DateTimeOffset now, TimeSpan retention, CancellationToken ct)
    {
        if (now < DateTimeOffset.UnixEpoch || retention < TimeSpan.FromDays(30) || retention > TimeSpan.FromDays(3650))
            throw new ArgumentOutOfRangeException(nameof(retention));
        var cutoff = now - retention;
        var candidates = await results.Find(Builders<BattleResultDocument>.Filter.Lt(x => x.AcceptedUtc, cutoff.UtcDateTime)).Limit(10001).ToListAsync(ct);
        if (candidates.Count > 10000) throw new InvalidDataException("Battle result archival batch exceeds capacity.");
        foreach (var row in candidates)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(row.MatchId ?? "", @"\A[a-zA-Z0-9_-]{1,64}\z") ||
                !System.Text.RegularExpressions.Regex.IsMatch(row.Digest ?? "", @"\A[0-9a-f]{64}\z") ||
                row.AcceptedUtc > now.UtcDateTime || row.Snapshot is not { Length: > 0 and <= 65536 })
                throw new InvalidDataException("Malformed battle result archival authority.");
        }
        if (candidates.Count == 0) return 0;
        var ids = candidates.Select(x => x.Id).ToArray();
        var deleted = await results.DeleteManyAsync(Builders<BattleResultDocument>.Filter.In(x => x.Id, ids), ct);
        return deleted.DeletedCount;
    }
    public async Task<string> ReconcileScored(string matchId, string digest, CancellationToken ct)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch(matchId ?? "", @"\A[a-zA-Z0-9_-]{1,64}\z") ||
            !System.Text.RegularExpressions.Regex.IsMatch(digest ?? "", @"\A[0-9a-f]{64}\z"))
            throw new InvalidDataException("Invalid battle result score identity.");
        var row = await Get(matchId!, ct);
        if (row == null) return "missing";
        if (!string.Equals(row.Digest, digest, StringComparison.Ordinal)) return "conflict";
        if (row.Scored) return "already-scored";
        var update = Builders<BattleResultDocument>.Update.Set(x => x.Scored, true).Set(x => x.ScoredUtc, DateTime.UtcNow);
        var result = await results.UpdateOneAsync(x => x.MatchId == matchId && x.Digest == digest && !x.Scored, update, cancellationToken: ct);
        return result.ModifiedCount == 1 ? "scored" : "already-scored";
    }
}
