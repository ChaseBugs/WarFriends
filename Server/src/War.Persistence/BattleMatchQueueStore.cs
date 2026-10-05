using MongoDB.Bson;
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
    private static readonly TransactionOptions QueueTransaction=new(readConcern:ReadConcern.Snapshot,writeConcern:WriteConcern.WMajority);
    private readonly MongoClient client;
    private readonly IMongoCollection<BattleQueueTicketDocument> tickets;
    private readonly IMongoCollection<BattlePairDocument> pairs;
    public BattleMatchQueueStore(string uri,string databaseName)
    {
        var settings=MongoClientSettings.FromConnectionString(uri);settings.ServerSelectionTimeout=TimeSpan.FromSeconds(5);
        client=new MongoClient(settings);
        var db=client.GetDatabase(databaseName);
        tickets=db.GetCollection<BattleQueueTicketDocument>("battle_queue_tickets");
        pairs=db.GetCollection<BattlePairDocument>("battle_pairs");
    }
    public async Task Initialize(CancellationToken ct)
    {
        var hello=await client.GetDatabase("admin").RunCommandAsync<BsonDocument>(new BsonDocument("hello",1),cancellationToken:ct);
        if(!hello.TryGetValue("setName",out var replicaName) || !replicaName.IsString || string.IsNullOrWhiteSpace(replicaName.AsString))
            throw new InvalidOperationException("Battle matchmaking requires a MongoDB replica set for atomic pair publication and cancellation.");
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
        string activeTicketId=ticket.Id;
        try {await tickets.InsertOneAsync(ticket,cancellationToken:ct);}
        catch(MongoWriteException e) when(e.WriteError.Category==ServerErrorCategory.DuplicateKey)
        {
            var prior=await tickets.Find(x=>x.PlayerId==playerId).FirstOrDefaultAsync(ct);
            if(prior==null)throw;
            ValidateTicket(prior);
            if(prior.CompatibilityKey!=compatibilityKey)throw new InvalidDataException("Player already has a different matchmaking ticket.");
            if(prior.ExpiresUtc<=now.UtcDateTime)
            {
                await tickets.DeleteOneAsync(x=>x.Id==prior.Id && x.ExpiresUtc==prior.ExpiresUtc,ct);
                return await Join(playerId,compatibilityKey,now,ct);
            }
            activeTicketId=prior.Id;
        }
        for(int attempt=0;attempt<16;attempt++)
        {
            using var session=await client.StartSessionAsync(cancellationToken:ct);
            try
            {
                var result=await session.WithTransactionAsync(async (s,token)=>
                {
                    var ownPair=await PairFor(s,playerId,token);
                    if(ownPair!=null)return Result("paired",ownPair);
                    var candidate=await tickets.Find(s,x=>x.CompatibilityKey==compatibilityKey && x.PlayerId!=playerId &&
                        x.JoinedUtc<=now.UtcDateTime && x.ExpiresUtc>now.UtcDateTime)
                        .SortBy(x=>x.JoinedUtc).ThenBy(x=>x.PlayerId).FirstOrDefaultAsync(token);
                    if(candidate==null)return new BattlePairingResult("waiting",null,null);
                    ValidateTicket(candidate);
                    if(await PairFor(s,candidate.PlayerId,token)!=null)
                    {
                        await tickets.DeleteOneAsync(s,x=>x.Id==candidate.Id,null,token);
                        return new BattlePairingResult("retry",null,null);
                    }
                    var pair=new BattlePairDocument{Id=Guid.NewGuid().ToString("N"),MatchId="m"+Guid.NewGuid().ToString("N"),
                        CompatibilityKey=compatibilityKey,Players=[candidate.PlayerId,playerId],CreatedUtc=now.UtcDateTime};
                    await pairs.InsertOneAsync(s,pair,cancellationToken:token);
                    var consumed=await tickets.DeleteManyAsync(s,
                        Builders<BattleQueueTicketDocument>.Filter.In(x=>x.Id,new[]{candidate.Id,activeTicketId}),null,token);
                    if(consumed.DeletedCount!=2)throw new PairingRetryException();
                    return Result("paired",pair);
                },QueueTransaction,ct);
                if(result.Code!="retry")return result;
            }
            catch(PairingRetryException){continue;}
            catch(MongoWriteException e) when(e.WriteError.Category==ServerErrorCategory.DuplicateKey){continue;}
        }
        existingPair=await PairFor(playerId,ct);
        return existingPair==null?new("waiting",null,null):Result("paired",existingPair);
    }
    public async Task<BattlePairingResult?> Existing(string playerId,CancellationToken ct)
    {
        if(!Guid.TryParseExact(playerId,"N",out _) || playerId!=playerId.ToLowerInvariant())
            throw new InvalidDataException("Invalid matchmaking player identity.");
        var pair=await PairFor(playerId,ct);
        return pair==null?null:Result("paired",pair);
    }
    public async Task<BattlePairingResult?> ForMatch(string matchId,CancellationToken ct)
    {
        if(!System.Text.RegularExpressions.Regex.IsMatch(matchId??"",@"\Am[0-9a-f]{32}\z"))
            throw new InvalidDataException("Invalid allocator match identity.");
        var pair=await pairs.Find(x=>x.MatchId==matchId).FirstOrDefaultAsync(ct);
        return pair==null?null:Result("paired",pair);
    }
    public async Task<bool> Release(string matchId,IReadOnlyList<string> playerIds,CancellationToken ct)
    {
        if(!System.Text.RegularExpressions.Regex.IsMatch(matchId??"",@"\Am[0-9a-f]{32}\z") ||
            playerIds is not {Count:2} || playerIds.Any(x=>!Guid.TryParseExact(x,"N",out _) || x!=x.ToLowerInvariant()) ||
            playerIds[0]==playerIds[1])
            throw new InvalidDataException("Invalid allocator release identity.");
        var row=await pairs.Find(x=>x.MatchId==matchId).FirstOrDefaultAsync(ct);
        if(row==null)return false;
        var checkedRow=Result("paired",row);
        if(!checkedRow.Players!.SequenceEqual(playerIds,StringComparer.Ordinal))
            throw new InvalidDataException("Terminal roster differs from durable pair.");
        var deleted=await pairs.DeleteOneAsync(x=>x.Id==row.Id && x.MatchId==matchId && x.Players==playerIds.ToArray(),ct);
        return deleted.DeletedCount==1;
    }
    public async Task<string> Cancel(string playerId,DateTimeOffset now,CancellationToken ct)
    {
        Validate(playerId,"cancel",now);
        using var session=await client.StartSessionAsync(cancellationToken:ct);
        return await session.WithTransactionAsync(async (s,token)=>
        {
            if(await PairFor(s,playerId,token)!=null)return "already-paired";
            var ticket=await tickets.Find(s,x=>x.PlayerId==playerId).FirstOrDefaultAsync(token);
            if(ticket==null)return "not-queued";
            ValidateTicket(ticket);
            var deleted=await tickets.DeleteOneAsync(s,x=>x.Id==ticket.Id && x.PlayerId==playerId,null,token);
            return deleted.DeletedCount==1?"cancelled":"not-queued";
        },QueueTransaction,ct);
    }
    private async Task<BattlePairDocument?> PairFor(string playerId,CancellationToken ct)=>
        await pairs.Find(Builders<BattlePairDocument>.Filter.AnyEq(x=>x.Players,playerId)).FirstOrDefaultAsync(ct);
    private async Task<BattlePairDocument?> PairFor(IClientSessionHandle session,string playerId,CancellationToken ct)=>
        await pairs.Find(session,Builders<BattlePairDocument>.Filter.AnyEq(x=>x.Players,playerId)).FirstOrDefaultAsync(ct);
    private sealed class PairingRetryException:Exception;
    private static BattlePairingResult Result(string code,BattlePairDocument pair)
    {
        if(!ValidId(pair.Id) || pair.Players is not {Length:2} ||
            pair.Players.Any(x=>!ValidId(x)) || pair.Players.Distinct(StringComparer.Ordinal).Count()!=2 ||
            !ValidKey(pair.CompatibilityKey) || !System.Text.RegularExpressions.Regex.IsMatch(pair.MatchId??"",@"\Am[0-9a-f]{32}\z") ||
            pair.CreatedUtc.Kind!=DateTimeKind.Utc || pair.CreatedUtc<DateTime.UnixEpoch)
            throw new InvalidDataException("Invalid durable battle pairing.");
        return new(code,pair.MatchId,Array.AsReadOnly(pair.Players.ToArray()));
    }
    private static void ValidateTicket(BattleQueueTicketDocument ticket)
    {
        if(!ValidId(ticket.Id) || !ValidId(ticket.PlayerId) || !ValidKey(ticket.CompatibilityKey) ||
            ticket.JoinedUtc.Kind!=DateTimeKind.Utc || ticket.JoinedUtc<DateTime.UnixEpoch ||
            ticket.JoinedUtc>DateTime.MaxValue.AddSeconds(-120) ||
            ticket.ExpiresUtc.Kind!=DateTimeKind.Utc ||
            ticket.ExpiresUtc!=ticket.JoinedUtc.AddSeconds(120))
            throw new InvalidDataException("Invalid durable matchmaking ticket.");
    }
    private static void Validate(string playerId,string key,DateTimeOffset now)
    {
        if(!ValidId(playerId) || !ValidKey(key) ||
            now<DateTimeOffset.UnixEpoch || now.ToUnixTimeSeconds()>253402300679)
            throw new InvalidDataException("Invalid matchmaking admission.");
    }
    private static bool ValidId(string? value)=>Guid.TryParseExact(value,"N",out _) && value==value.ToLowerInvariant();
    private static bool ValidKey(string? value)=>System.Text.RegularExpressions.Regex.IsMatch(value??"",@"\A[a-zA-Z0-9_.:-]{1,128}\z");
}
