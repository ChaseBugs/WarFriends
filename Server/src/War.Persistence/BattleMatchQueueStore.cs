using MongoDB.Driver;

namespace War.Persistence;

public sealed class BattleQueueTicketDocument
{
    public string Id {get;set;}="";
    public string PlayerId {get;set;}="";
    public string CompatibilityKey {get;set;}="";
    public DateTime JoinedUtc {get;set;}
    public DateTime ExpiresUtc {get;set;}
}
public sealed class BattlePairDocument
{
    public string Id {get;set;}="";
    public string MatchId {get;set;}="";
    public string CompatibilityKey {get;set;}="";
    public string[] Players {get;set;}=[];
    public DateTime CreatedUtc {get;set;}
}
public sealed record BattlePairingResult(string Code,string? MatchId,IReadOnlyList<string>? Players);

/// <summary>Durable allocator pairing primitive. Compatibility keys are server policy, never client assertions.</summary>
public sealed class BattleMatchQueueStore
{
    private readonly IMongoCollection<BattleQueueTicketDocument> tickets;
    private readonly IMongoCollection<BattlePairDocument> pairs;
    public BattleMatchQueueStore(string uri,string databaseName)
    {
        var settings=MongoClientSettings.FromConnectionString(uri);settings.ServerSelectionTimeout=TimeSpan.FromSeconds(5);
        var db=new MongoClient(settings).GetDatabase(databaseName);
        tickets=db.GetCollection<BattleQueueTicketDocument>("battle_queue_tickets");
        pairs=db.GetCollection<BattlePairDocument>("battle_pairs");
    }
    public async Task Initialize(CancellationToken ct)
    {
        await tickets.Indexes.CreateManyAsync([
            new CreateIndexModel<BattleQueueTicketDocument>(Builders<BattleQueueTicketDocument>.IndexKeys.Ascending(x=>x.PlayerId),new CreateIndexOptions{Unique=true}),
            new CreateIndexModel<BattleQueueTicketDocument>(Builders<BattleQueueTicketDocument>.IndexKeys.Ascending(x=>x.CompatibilityKey).Ascending(x=>x.JoinedUtc).Ascending(x=>x.PlayerId)),
            new CreateIndexModel<BattleQueueTicketDocument>(Builders<BattleQueueTicketDocument>.IndexKeys.Ascending(x=>x.ExpiresUtc),new CreateIndexOptions{ExpireAfter=TimeSpan.Zero})],ct);
        await pairs.Indexes.CreateManyAsync([
            new CreateIndexModel<BattlePairDocument>(Builders<BattlePairDocument>.IndexKeys.Ascending(x=>x.MatchId),new CreateIndexOptions{Unique=true}),
            new CreateIndexModel<BattlePairDocument>(Builders<BattlePairDocument>.IndexKeys.Ascending(x=>x.Players),new CreateIndexOptions{Unique=true})],ct);
    }
    public async Task<BattlePairingResult> Join(string playerId,string compatibilityKey,DateTimeOffset now,CancellationToken ct)
    {
        Validate(playerId,compatibilityKey,now);
        var existingPair=await PairFor(playerId,ct);
        if(existingPair!=null)return Result("paired",existingPair);
        var ticket=new BattleQueueTicketDocument{Id=Guid.NewGuid().ToString("N"),PlayerId=playerId,
            CompatibilityKey=compatibilityKey,JoinedUtc=now.UtcDateTime,ExpiresUtc=now.AddSeconds(120).UtcDateTime};
        try {await tickets.InsertOneAsync(ticket,cancellationToken:ct);}
        catch(MongoWriteException e) when(e.WriteError.Category==ServerErrorCategory.DuplicateKey)
        {
            var prior=await tickets.Find(x=>x.PlayerId==playerId).FirstOrDefaultAsync(ct);
            if(prior==null)throw;
            if(prior.CompatibilityKey!=compatibilityKey)throw new InvalidDataException("Player already has a different matchmaking ticket.");
            if(prior.ExpiresUtc<=now.UtcDateTime)
            {
                await tickets.DeleteOneAsync(x=>x.Id==prior.Id && x.ExpiresUtc==prior.ExpiresUtc,ct);
                return await Join(playerId,compatibilityKey,now,ct);
            }
            if(prior.JoinedUtc>now.UtcDateTime || prior.ExpiresUtc!=prior.JoinedUtc.AddSeconds(120))
                throw new InvalidDataException("Existing matchmaking ticket has invalid lifetime authority.");
        }
        for(int attempt=0;attempt<16;attempt++)
        {
            existingPair=await PairFor(playerId,ct);
            if(existingPair!=null)return Result("paired",existingPair);
            var candidate=await tickets.Find(x=>x.CompatibilityKey==compatibilityKey && x.PlayerId!=playerId && x.ExpiresUtc>now.UtcDateTime)
                .SortBy(x=>x.JoinedUtc).ThenBy(x=>x.PlayerId).FirstOrDefaultAsync(ct);
            if(candidate==null)return new("waiting",null,null);
            var candidatePair=await PairFor(candidate.PlayerId,ct);
            if(candidatePair!=null){await tickets.DeleteOneAsync(x=>x.PlayerId==candidate.PlayerId,ct);continue;}
            string matchId="m"+Guid.NewGuid().ToString("N");
            var pair=new BattlePairDocument{Id=Guid.NewGuid().ToString("N"),MatchId=matchId,
                CompatibilityKey=compatibilityKey,Players=[candidate.PlayerId,playerId],CreatedUtc=now.UtcDateTime};
            try
            {
                await pairs.InsertOneAsync(pair,cancellationToken:ct);
                await tickets.DeleteManyAsync(Builders<BattleQueueTicketDocument>.Filter.In(x=>x.PlayerId,pair.Players),ct);
                return Result("paired",pair);
            }
            catch(MongoWriteException e) when(e.WriteError.Category==ServerErrorCategory.DuplicateKey){continue;}
        }
        existingPair=await PairFor(playerId,ct);
        return existingPair==null?new("waiting",null,null):Result("paired",existingPair);
    }
    public async Task<string> Cancel(string playerId,DateTimeOffset now,CancellationToken ct)
    {
        Validate(playerId,"cancel",now);
        if(await PairFor(playerId,ct)!=null)return "already-paired";
        var deleted=await tickets.DeleteOneAsync(x=>x.PlayerId==playerId,ct);
        return deleted.DeletedCount==1?"cancelled":"not-queued";
    }
    private async Task<BattlePairDocument?> PairFor(string playerId,CancellationToken ct)=>
        await pairs.Find(Builders<BattlePairDocument>.Filter.AnyEq(x=>x.Players,playerId)).FirstOrDefaultAsync(ct);
    private static BattlePairingResult Result(string code,BattlePairDocument pair)
    {
        if(pair.Players is not {Length:2} || pair.Players.Distinct(StringComparer.Ordinal).Count()!=2 ||
            !ValidKey(pair.CompatibilityKey) || !System.Text.RegularExpressions.Regex.IsMatch(pair.MatchId??"",@"\Am[0-9a-f]{32}\z"))
            throw new InvalidDataException("Invalid durable battle pairing.");
        return new(code,pair.MatchId,Array.AsReadOnly(pair.Players.ToArray()));
    }
    private static void Validate(string playerId,string key,DateTimeOffset now)
    {
        if(!Guid.TryParseExact(playerId,"N",out _) || playerId!=playerId.ToLowerInvariant() || !ValidKey(key) ||
            now<DateTimeOffset.UnixEpoch || now.ToUnixTimeSeconds()>253402300799)
            throw new InvalidDataException("Invalid matchmaking admission.");
    }
    private static bool ValidKey(string? value)=>System.Text.RegularExpressions.Regex.IsMatch(value??"",@"\A[a-zA-Z0-9_.:-]{1,128}\z");
}
