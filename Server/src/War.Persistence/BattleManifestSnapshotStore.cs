using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;
using MongoDB.Driver;

namespace War.Persistence;

public sealed class BattleManifestSnapshotDocument
{
    public string Id {get;set;}="";
    public string[] Players {get;set;}=[];
    public byte[] Manifest {get;set;}=[];
    public string Sha256 {get;set;}="";
    public DateTime CreatedUtc {get;set;}
}

/// <summary>Freezes a paired match's exact manifest bytes before Worker registration.</summary>
public sealed class BattleManifestSnapshotStore
{
    private readonly IMongoCollection<BattleManifestSnapshotDocument> snapshots;
    public BattleManifestSnapshotStore(string uri,string databaseName)
    {
        var settings=MongoClientSettings.FromConnectionString(uri);settings.ServerSelectionTimeout=TimeSpan.FromSeconds(5);
        snapshots=new MongoClient(settings).GetDatabase(databaseName)
            .GetCollection<BattleManifestSnapshotDocument>("battle_manifest_snapshots");
    }

    public async Task<byte[]> GetOrCreate(string matchId,IReadOnlyList<string> players,Func<Task<byte[]>> create,CancellationToken ct)
    {
        ValidateIdentity(matchId,players);
        var existing=await snapshots.Find(x=>x.Id==matchId).FirstOrDefaultAsync(ct);
        if(existing!=null)return Validate(existing,matchId,players);
        byte[] bytes=await create();
        var document=new BattleManifestSnapshotDocument {Id=matchId,Players=players.ToArray(),Manifest=bytes.ToArray(),
            Sha256=Convert.ToHexStringLower(SHA256.HashData(bytes)),CreatedUtc=DateTime.UtcNow};
        _=Validate(document,matchId,players);
        try {await snapshots.InsertOneAsync(document,cancellationToken:ct);return document.Manifest.ToArray();}
        catch(MongoWriteException e) when(e.WriteError.Category==ServerErrorCategory.DuplicateKey)
        {
            existing=await snapshots.Find(x=>x.Id==matchId).FirstOrDefaultAsync(ct);
            if(existing==null)throw new InvalidDataException("Concurrent manifest snapshot is unavailable.");
            return Validate(existing,matchId,players);
        }
    }

    public async Task<byte[]?> Get(string matchId,IReadOnlyList<string> players,CancellationToken ct)
    {
        ValidateIdentity(matchId,players);
        var row=await snapshots.Find(x=>x.Id==matchId).FirstOrDefaultAsync(ct);
        return row==null?null:Validate(row,matchId,players);
    }

    public static byte[] Validate(BattleManifestSnapshotDocument document,string matchId,IReadOnlyList<string> players)
    {
        ValidateIdentity(matchId,players);
        if(document==null || document.Id!=matchId || document.Players is not {Length:2} ||
            !document.Players.SequenceEqual(players,StringComparer.Ordinal) ||
            document.Manifest is not {Length:>1 and <=65536} ||
            !Regex.IsMatch(document.Sha256??"",@"\A[0-9a-f]{64}\z") ||
            Convert.ToHexStringLower(SHA256.HashData(document.Manifest))!=document.Sha256 ||
            document.CreatedUtc.Kind!=DateTimeKind.Utc || document.CreatedUtc<DateTime.UnixEpoch ||
            document.CreatedUtc>DateTime.UtcNow.AddMinutes(1))
            throw new InvalidDataException("Invalid durable battle manifest snapshot.");
        try
        {
            using var json=JsonDocument.Parse(document.Manifest);
            var root=json.RootElement;
            if(root.ValueKind!=JsonValueKind.Object || root.GetProperty("MatchId").GetString()!=matchId ||
                root.GetProperty("Players").EnumerateArray().Select(x=>x.GetProperty("PlayerId").GetString())
                    .SequenceEqual(players,StringComparer.Ordinal)==false)
                throw new InvalidDataException("Manifest snapshot roster differs from its durable index.");
        }
        catch(Exception e) when(e is JsonException or KeyNotFoundException or InvalidOperationException)
        {throw new InvalidDataException("Malformed durable battle manifest snapshot.",e);}
        return document.Manifest.ToArray();
    }

    private static void ValidateIdentity(string matchId,IReadOnlyList<string> players)
    {
        if(!Regex.IsMatch(matchId??"",@"\Am[0-9a-f]{32}\z") || players is not {Count:2} ||
            players.Any(x=>!Guid.TryParseExact(x,"N",out _) || x!=x.ToLowerInvariant()) ||
            players[0]==players[1])
            throw new InvalidDataException("Invalid manifest snapshot identity.");
    }
}
