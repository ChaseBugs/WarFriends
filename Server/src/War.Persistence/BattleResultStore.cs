using MongoDB.Driver;
using War.BattleServer;
using War.Shared;
using War.Protocol;

namespace War.Persistence;

public sealed class BattleResultDocument
{
    public string Id { get; set; } = "";
    public string MatchId { get; set; } = "";
    public string Digest { get; set; } = "";
    public byte[] Snapshot { get; set; } = Array.Empty<byte>();
    public DateTime AcceptedUtc { get; set; }
    public BattlePhase? TerminalPhase { get; set; }
    public bool Scored { get; set; }
    public DateTime? ScoredUtc { get; set; }
    public bool Settled { get; set; }
    public DateTime? SettledUtc { get; set; }
}

public sealed class BattleResultStore
{
    public const int ArchivalPageSize = 256;
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
            new CreateIndexModel<BattleResultDocument>(Builders<BattleResultDocument>.IndexKeys.Ascending(x => x.AcceptedUtc)),
            new CreateIndexModel<BattleResultDocument>(Builders<BattleResultDocument>.IndexKeys
                .Ascending(x => x.TerminalPhase).Ascending(x => x.AcceptedUtc)),
            new CreateIndexModel<BattleResultDocument>(Builders<BattleResultDocument>.IndexKeys
                .Ascending(x => x.Settled).Ascending(x => x.AcceptedUtc))
        }, ct);
    }
    public async Task<string> Accept(string matchId, string digest, byte[] snapshot, CancellationToken ct)
    {
        var checkedSnapshot = snapshot ?? throw new InvalidDataException("Missing battle result snapshot.");
        var checkedMatchId = matchId ?? throw new InvalidDataException("Missing battle result ID.");
        var checkedDigest = digest ?? throw new InvalidDataException("Missing battle result digest.");
        if (!System.Text.RegularExpressions.Regex.IsMatch(checkedMatchId, @"\A[a-zA-Z0-9_-]{1,64}\z") ||
            !System.Text.RegularExpressions.Regex.IsMatch(checkedDigest, @"\A[0-9a-f]{64}\z") ||
            checkedSnapshot.Length is < 1 or > TerminalResultDigest.MaximumPayloadBytes ||
            TerminalResultDigest.Compute(checkedSnapshot)!=checkedDigest)
            throw new InvalidDataException("Invalid battle result envelope.");
        var terminal=TerminalOutbox.ValidatePayload(checkedSnapshot,checkedMatchId,checkedDigest);
        var prior = await results.Find(x => x.MatchId == checkedMatchId).FirstOrDefaultAsync(ct);
        if (prior != null)
        {
            Validate(prior,checkedMatchId,DateTime.UtcNow);
            return prior.Digest==checkedDigest && prior.Snapshot.AsSpan().SequenceEqual(checkedSnapshot)
                ? "already-accepted" : "conflict";
        }
        var doc = new BattleResultDocument { Id = Guid.NewGuid().ToString("N"), MatchId = checkedMatchId,
            Digest = checkedDigest, Snapshot = checkedSnapshot.ToArray(), AcceptedUtc = DateTime.UtcNow,
            TerminalPhase = terminal.Phase };
        try { await results.InsertOneAsync(doc, cancellationToken: ct); return "accepted"; }
        catch (MongoWriteException e) when (e.WriteError.Category == ServerErrorCategory.DuplicateKey)
        {
            prior = await results.Find(x => x.MatchId == checkedMatchId).FirstOrDefaultAsync(ct);
            if(prior==null)return "conflict";
            Validate(prior,checkedMatchId,DateTime.UtcNow);
            return prior.Digest==checkedDigest && prior.Snapshot.AsSpan().SequenceEqual(checkedSnapshot)
                ? "already-accepted" : "conflict";
        }
    }
    public async Task<BattleResultDocument?> Get(string matchId, CancellationToken ct)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch(matchId ?? "", @"\A[a-zA-Z0-9_-]{1,64}\z"))
            throw new InvalidDataException("Invalid battle result ID.");
        var result = await results.Find(x => x.MatchId == matchId).FirstOrDefaultAsync(ct);
        if (result == null) return null;
        Validate(result,matchId,DateTime.UtcNow);
        result.Snapshot = result.Snapshot.ToArray();
        return result;
    }
    public async Task<IReadOnlyList<BattleCardMatchStats>?> GetCardStats(string matchId,CancellationToken ct)
    {
        var result=await Get(matchId,ct);
        return result==null ? null : BattleCardStatsProjection.FromPayload(result.Snapshot,result.MatchId,result.Digest);
    }
    public async Task<IReadOnlyList<BattlePlayerArmyStats>?> GetArmyStats(string matchId,CancellationToken ct)
    {
        var result=await Get(matchId,ct);
        return result==null ? null : BattleArmyStatsProjection.FromPayload(result.Snapshot,result.MatchId,result.Digest);
    }
    public async Task<IReadOnlyList<BattleOutcomeMatchStats>?> GetOutcomeStats(string matchId,CancellationToken ct)
    {
        var result=await Get(matchId,ct);
        return result==null ? null : BattleOutcomeStatsProjection.FromPayload(result.Snapshot,result.MatchId,result.Digest);
    }
    public async Task<IReadOnlyList<BattlePlayerShotEvidence>?> GetShotEvidence(string matchId,CancellationToken ct)
    {
        var result=await Get(matchId,ct);
        return result==null ? null : BattleShotEvidenceProjection.FromPayload(result.Snapshot,result.MatchId,result.Digest);
    }
    public async Task<IReadOnlyList<BattlePlayerBulletHitEvidence>?> GetBulletHitEvidence(string matchId,CancellationToken ct)
    {
        var result=await Get(matchId,ct);
        return result==null ? null : BattleBulletHitEvidenceProjection.FromPayload(result.Snapshot,result.MatchId,result.Digest);
    }
    public async Task<IReadOnlyList<BattleDirectArmyKillEvidence>?> GetDirectArmyKillEvidence(string matchId,CancellationToken ct)
    {
        var result=await Get(matchId,ct);
        return result==null ? null : BattleDirectArmyKillEvidenceProjection.FromPayload(
            result.Snapshot,result.MatchId,result.Digest);
    }
    public async Task<IReadOnlyList<BattleDirectKillStats>?> GetDirectKillStats(string matchId,CancellationToken ct)
    {
        var result=await Get(matchId,ct);
        return result==null ? null : BattleDirectKillStatsProjection.FromPayload(
            result.Snapshot,result.MatchId,result.Digest);
    }
    public async Task<long> Prune(DateTimeOffset now, TimeSpan retention, CancellationToken ct)
    {
        var page = await PrunePage(now, retention, ct);
        return page.Removed;
    }
    public async Task<BattleResultPrunePage> PrunePage(DateTimeOffset now, TimeSpan retention, CancellationToken ct)
    {
        if (now < DateTimeOffset.UnixEpoch || retention < TimeSpan.FromDays(30) || retention > TimeSpan.FromDays(3650))
            throw new ArgumentOutOfRangeException(nameof(retention));
        var cutoff = now - retention;
        var filter=Builders<BattleResultDocument>.Filter;
        var due=filter.Lt(x=>x.AcceptedUtc,cutoff.UtcDateTime);
        var eligible=filter.Eq(x=>x.Settled,true) |
            filter.Eq(x=>x.TerminalPhase,BattlePhase.Aborted) |
            filter.Eq(x=>x.TerminalPhase,null); // Inspect older rows without a phase mirror.
        // A single maintenance pass has a fixed upper bound. Repeated passes
        // advance through old rows without loading the entire collection.
        var candidates=await results.Find(due & eligible)
            .SortBy(x=>x.AcceptedUtc).ThenBy(x=>x.Id)
            .Limit(ArchivalPageSize).ToListAsync(ct);
        foreach (var row in candidates)
            Validate(row,row.MatchId,now.UtcDateTime);
        if (candidates.Count == 0) return new BattleResultPrunePage(0, 0);
        long removed=0;
        foreach(var row in candidates)
        {
            var terminal=TerminalOutbox.ValidatePayload(row.Snapshot,row.MatchId,row.Digest);
            if(row.TerminalPhase==null)
            {
                // Older rows did not store an indexed phase. Only the validated
                // terminal payload can supply that phase for future scans.
                var phaseUpdate=Builders<BattleResultDocument>.Update
                    .Set(x=>x.TerminalPhase,terminal.Phase);
                var updated=await results.UpdateOneAsync(Exact(row),phaseUpdate,cancellationToken:ct);
                if(updated.ModifiedCount!=1)
                    throw new InvalidDataException("Battle result changed during phase migration; retry archival.");
                row.TerminalPhase=terminal.Phase;
            }
            if(terminal.Phase==BattlePhase.Ended && !row.Settled)
                continue; // A score marker alone does not transact account rewards.
            var deleted=await results.DeleteOneAsync(Exact(row),ct);
            if(deleted.DeletedCount!=1)
                throw new InvalidDataException("Battle result changed during archival; retry remaining rows.");
            removed++;
        }
        return new BattleResultPrunePage(candidates.Count, removed);
    }
    public async Task<string> ReconcileScored(string matchId, string digest, CancellationToken ct)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch(matchId ?? "", @"\A[a-zA-Z0-9_-]{1,64}\z") ||
            !System.Text.RegularExpressions.Regex.IsMatch(digest ?? "", @"\A[0-9a-f]{64}\z"))
            throw new InvalidDataException("Invalid battle result score identity.");
        var row = await Get(matchId!, ct);
        if (row == null) return "missing";
        if (!string.Equals(row.Digest, digest, StringComparison.Ordinal)) return "conflict";
        if (TerminalOutbox.ValidatePayload(row.Snapshot,row.MatchId,row.Digest).Phase!=BattlePhase.Ended)
            throw new InvalidDataException("An aborted battle cannot be marked scored.");
        if (row.Scored) return "already-scored";
        var update = Builders<BattleResultDocument>.Update.Set(x => x.Scored, true).Set(x => x.ScoredUtc, DateTime.UtcNow);
        var result = await results.UpdateOneAsync(Exact(row), update, cancellationToken: ct);
        if(result.ModifiedCount==1)return "scored";
        var latest=await Get(matchId!,ct);
        if(latest==null)return "missing";
        if(latest.Digest!=digest)return "conflict";
        if(latest.Scored)return "already-scored";
        throw new InvalidDataException("Battle result changed during scoring.");
    }
    private static FilterDefinition<BattleResultDocument> Exact(BattleResultDocument row)
    {
        var f=Builders<BattleResultDocument>.Filter;
        return f.Eq(x=>x.Id,row.Id) & f.Eq(x=>x.MatchId,row.MatchId) &
            f.Eq(x=>x.Digest,row.Digest) & f.Eq(x=>x.Snapshot,row.Snapshot) &
            f.Eq(x=>x.AcceptedUtc,row.AcceptedUtc) &
            f.Eq(x=>x.TerminalPhase,row.TerminalPhase) & f.Eq(x=>x.Scored,row.Scored) &
            f.Eq(x=>x.ScoredUtc,row.ScoredUtc) & f.Eq(x=>x.Settled,row.Settled) &
            f.Eq(x=>x.SettledUtc,row.SettledUtc);
    }
    private static void Validate(BattleResultDocument row,string? matchId,DateTime now)
    {
        if(row==null || !Guid.TryParseExact(row.Id,"N",out _) || row.Id!=row.Id.ToLowerInvariant() ||
            row.MatchId!=matchId || !System.Text.RegularExpressions.Regex.IsMatch(row.MatchId??"",@"\A[a-zA-Z0-9_-]{1,64}\z") ||
            !System.Text.RegularExpressions.Regex.IsMatch(row.Digest??"",@"\A[0-9a-f]{64}\z") ||
            row.Snapshot is not {Length:>0 and <= TerminalResultDigest.MaximumPayloadBytes} ||
            row.AcceptedUtc.Kind!=DateTimeKind.Utc || row.AcceptedUtc<DateTime.UnixEpoch || row.AcceptedUtc>now ||
            (row.Scored ? row.ScoredUtc is not { } scored || scored.Kind!=DateTimeKind.Utc ||
                scored<row.AcceptedUtc || scored>now : row.ScoredUtc!=null) ||
            (row.Settled ? !row.Scored || row.SettledUtc is not { } settled ||
                settled.Kind!=DateTimeKind.Utc || settled<row.ScoredUtc || settled>now : row.SettledUtc!=null) ||
            TerminalResultDigest.Compute(row.Snapshot)!=row.Digest)
            throw new InvalidDataException("Invalid persisted battle result.");
        var terminal=TerminalOutbox.ValidatePayload(row.Snapshot,row.MatchId!,row.Digest!);
        if(row.TerminalPhase is { } phase && phase!=terminal.Phase)
            throw new InvalidDataException("Persisted battle phase differs from terminal evidence.");
        if(row.Scored && terminal.Phase!=BattlePhase.Ended)
            throw new InvalidDataException("An aborted battle has a scored marker.");
    }
}

public readonly record struct BattleResultPrunePage(int Inspected, long Removed);
