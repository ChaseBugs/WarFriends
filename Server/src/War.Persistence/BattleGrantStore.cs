using Google.Protobuf;
using MongoDB.Driver;
using War.Protocol;

namespace War.Persistence;

public sealed class BattleGrantDocument
{
    public string Id {get;set;}="";
    public string MatchId {get;set;}="";
    public string ManifestHash {get;set;}="";
    public string PlayerA {get;set;}="";
    public string PlayerB {get;set;}="";
    public byte[] GrantA {get;set;}=[];
    public byte[] GrantB {get;set;}=[];
    public DateTime ExpiresUtc {get;set;}
}

public sealed class BattleGrantStore
{
    // The initial ticket lasts two minutes, but an admitted battle can run for
    // thirty minutes and then enter reconnect grace. Keep roster metadata long
    // enough to publish replacement tickets without keeping old tickets valid.
    private const int AssignmentRetentionSeconds=2100;
    private readonly IMongoCollection<BattleGrantDocument> grants;
    public BattleGrantStore(string uri,string databaseName)
    {
        var settings=MongoClientSettings.FromConnectionString(uri);settings.ServerSelectionTimeout=TimeSpan.FromSeconds(5);
        grants=new MongoClient(settings).GetDatabase(databaseName).GetCollection<BattleGrantDocument>("battle_grants");
    }
    public async Task Initialize(CancellationToken ct)=>await grants.Indexes.CreateManyAsync([
        new CreateIndexModel<BattleGrantDocument>(Builders<BattleGrantDocument>.IndexKeys.Ascending(x=>x.MatchId),new CreateIndexOptions{Unique=true}),
        new CreateIndexModel<BattleGrantDocument>(Builders<BattleGrantDocument>.IndexKeys.Ascending(x=>x.ExpiresUtc),new CreateIndexOptions{ExpireAfter=TimeSpan.Zero})],ct);
    public async Task<string> Publish(string matchId,string manifestHash,IEnumerable<MatchConnectionGrant> values,CancellationToken ct)
    {
        var rows=(values??throw new ArgumentNullException(nameof(values))).Select(Validate).ToArray();
        if(rows.Length!=2 || rows.Select(x=>x.PlayerId).Distinct(StringComparer.Ordinal).Count()!=2 ||
            rows.Select(x=>x.SessionId).Distinct().Count()!=2 || rows.Any(x=>x.MatchId!=matchId || x.ManifestHash!=manifestHash) ||
            rows.Any(x=>x.PlayerViews.Count!=2) ||
            rows.Any(x=>!x.PlayerViews.Select(v=>v.PlayerId).SequenceEqual(rows.Select(r=>r.PlayerId),StringComparer.Ordinal)))
            throw new InvalidDataException("Invalid battle grant assignment.");
        var doc=new BattleGrantDocument{Id=Guid.NewGuid().ToString("N"),MatchId=matchId,ManifestHash=manifestHash,
            PlayerA=rows[0].PlayerId,PlayerB=rows[1].PlayerId,GrantA=rows[0].ToByteArray(),GrantB=rows[1].ToByteArray(),
            ExpiresUtc=RetentionDate(Math.Max(rows[0].ExpiresUnixSeconds,rows[1].ExpiresUnixSeconds))};
        _=ValidateDocument(doc);
        try {await grants.InsertOneAsync(doc,cancellationToken:ct);return "published";}
        catch(MongoWriteException e) when(e.WriteError.Category==ServerErrorCategory.DuplicateKey)
        {
            var prior=await grants.Find(x=>x.MatchId==matchId).FirstOrDefaultAsync(ct);
            if(prior==null)return "conflict";
            _=ValidateDocument(prior);
            return Same(prior,doc)?"already-published":"conflict";
        }
    }
    public async Task<MatchConnectionGrant?> GetForPlayer(string matchId,string playerId,long unixNow,CancellationToken ct)
    {
        ValidateLookup(matchId,playerId,unixNow);
        var row=await grants.Find(x=>x.MatchId==matchId).FirstOrDefaultAsync(ct);
        if(row==null)return null;
        var (first,second)=ValidateDocument(row);
        var selected=playerId==row.PlayerA?first:playerId==row.PlayerB?second:null;
        if(selected?.ExpiresUnixSeconds<=unixNow)
            throw new InvalidDataException("Persisted battle grant has expired.");
        return selected;
    }

    /// <summary>Reads the roster authority even when an earlier ticket has expired.</summary>
    public async Task<MatchConnectionGrant?> GetAssignmentForPlayer(string matchId,string playerId,long unixNow,CancellationToken ct)
    {
        ValidateLookup(matchId,playerId,unixNow);
        var row=await grants.Find(x=>x.MatchId==matchId).FirstOrDefaultAsync(ct);
        if(row==null)return null;
        var (first,second)=ValidateDocument(row);
        if(row.ExpiresUtc<=DateTimeOffset.FromUnixTimeSeconds(unixNow).UtcDateTime)return null;
        return playerId==row.PlayerA?first:playerId==row.PlayerB?second:null;
    }

    /// <summary>Publishes one Worker-issued replacement without changing its peer's grant.</summary>
    public async Task<MatchConnectionGrant> ReplaceForPlayer(string matchId,string playerId,
        MatchConnectionGrant replacement,long unixNow,CancellationToken ct)
    {
        ValidateLookup(matchId,playerId,unixNow);
        var workerGrant=Validate(replacement);
        if(workerGrant.MatchId!=matchId || workerGrant.PlayerId!=playerId || workerGrant.ExpiresUnixSeconds<=unixNow)
            throw new InvalidDataException("Reconnect grant identity or lifetime differs from the assignment.");
        for(int attempt=0;attempt<8;attempt++)
        {
            var next=workerGrant.Clone();
            var row=await grants.Find(x=>x.MatchId==matchId).FirstOrDefaultAsync(ct)
                ?? throw new InvalidDataException("Battle grant assignment is missing.");
            var (first,second)=ValidateDocument(row);
            if(row.ExpiresUtc<=DateTimeOffset.FromUnixTimeSeconds(unixNow).UtcDateTime)
                throw new InvalidDataException("Battle grant assignment has expired.");
            var prior=playerId==row.PlayerA?first:playerId==row.PlayerB?second:
                throw new InvalidDataException("Player is not in the battle grant assignment.");
            if(next.ManifestHash!=row.ManifestHash || next.Host!=prior.Host || next.Port!=prior.Port ||
               next.SessionId==(playerId==row.PlayerA?second:first).SessionId ||
               next.PlayerViews.Count!=0)
                throw new InvalidDataException("Reconnect grant differs from durable match authority.");
            next.PlayerViews.AddRange(prior.PlayerViews);
            byte[] replacementBytes=next.ToByteArray();
            if(replacementBytes.AsSpan().SequenceEqual(playerId==row.PlayerA?row.GrantA:row.GrantB))
                return next;
            var priorClaims=AdmissionClaims(prior);
            var nextClaims=AdmissionClaims(next);
            if(nextClaims.ConnectionGeneration<=priorClaims.ConnectionGeneration ||
               nextClaims.IssuedUnixSeconds<priorClaims.IssuedUnixSeconds ||
               next.SessionId==prior.SessionId || next.Ticket==prior.Ticket ||
               next.SessionKey.Equals(prior.SessionKey))
                throw new InvalidDataException("Reconnect generation did not advance from durable authority.");
            var peer=playerId==row.PlayerA?second:first;
            DateTime retention=RetentionDate(Math.Max(next.ExpiresUnixSeconds,peer.ExpiresUnixSeconds));
            var filter=Builders<BattleGrantDocument>.Filter.Eq(x=>x.Id,row.Id) &
                Builders<BattleGrantDocument>.Filter.Eq(x=>x.MatchId,matchId) &
                Builders<BattleGrantDocument>.Filter.Eq(x=>x.GrantA,row.GrantA) &
                Builders<BattleGrantDocument>.Filter.Eq(x=>x.GrantB,row.GrantB);
            var update=playerId==row.PlayerA
                ?Builders<BattleGrantDocument>.Update.Set(x=>x.GrantA,replacementBytes).Set(x=>x.ExpiresUtc,retention)
                :Builders<BattleGrantDocument>.Update.Set(x=>x.GrantB,replacementBytes).Set(x=>x.ExpiresUtc,retention);
            var result=await grants.UpdateOneAsync(filter,update,cancellationToken:ct);
            if(result.ModifiedCount==1)return next;
        }
        throw new InvalidDataException("Battle grant assignment changed repeatedly; retry reconnect.");
    }
    private static (MatchConnectionGrant First,MatchConnectionGrant Second) ValidateDocument(BattleGrantDocument row)
    {
        if(row==null || !Guid.TryParseExact(row.Id,"N",out _) || row.Id!=row.Id.ToLowerInvariant() ||
           !ValidMatch(row.MatchId) ||
           !System.Text.RegularExpressions.Regex.IsMatch(row.ManifestHash??"",@"\A[0-9a-f]{64}\z") ||
           !Guid.TryParseExact(row.PlayerA,"N",out _) || row.PlayerA!=row.PlayerA.ToLowerInvariant() ||
           !Guid.TryParseExact(row.PlayerB,"N",out _) || row.PlayerB!=row.PlayerB.ToLowerInvariant() ||
           row.PlayerA==row.PlayerB || row.GrantA is not {Length:>0 and <=16384} ||
           row.GrantB is not {Length:>0 and <=16384} ||
           row.ExpiresUtc.Kind!=DateTimeKind.Utc || row.ExpiresUtc<DateTime.UnixEpoch)
            throw new InvalidDataException("Invalid persisted battle grant assignment.");
        MatchConnectionGrant first,second;
        try {first=MatchConnectionGrant.Parser.ParseFrom(row.GrantA);
             second=MatchConnectionGrant.Parser.ParseFrom(row.GrantB);}
        catch(InvalidProtocolBufferException e){throw new InvalidDataException("Invalid persisted battle grant protobuf.",e);}
        if(!first.ToByteArray().AsSpan().SequenceEqual(row.GrantA) ||
           !second.ToByteArray().AsSpan().SequenceEqual(row.GrantB))
            throw new InvalidDataException("Noncanonical persisted battle grant bytes.");
        first=Validate(first);second=Validate(second);
        var roster=new[]{row.PlayerA,row.PlayerB};
        if(first.MatchId!=row.MatchId || second.MatchId!=row.MatchId ||
           first.ManifestHash!=row.ManifestHash || second.ManifestHash!=row.ManifestHash ||
           first.PlayerId!=row.PlayerA || second.PlayerId!=row.PlayerB ||
           first.SessionId==second.SessionId ||
           first.Host!=second.Host || first.Port!=second.Port ||
           first.Ticket==second.Ticket || first.SessionKey.Equals(second.SessionKey) ||
           (row.ExpiresUtc!=DateTimeOffset.FromUnixTimeSeconds(Math.Max(first.ExpiresUnixSeconds,second.ExpiresUnixSeconds)).UtcDateTime &&
            row.ExpiresUtc!=RetentionDate(Math.Max(first.ExpiresUnixSeconds,second.ExpiresUnixSeconds))) ||
           first.PlayerViews.Count!=2 || second.PlayerViews.Count!=2 ||
           !first.PlayerViews.Select(x=>x.PlayerId).SequenceEqual(roster,StringComparer.Ordinal) ||
           !second.PlayerViews.Select(x=>x.PlayerId).SequenceEqual(roster,StringComparer.Ordinal) ||
           first.PlayerViews[0].Fraction==first.PlayerViews[1].Fraction ||
           !first.PlayerViews.SequenceEqual(second.PlayerViews))
            throw new InvalidDataException("Persisted battle grant assignment differs from its roster authority.");
        return (first,second);
    }
    private static MatchConnectionGrant Validate(MatchConnectionGrant value)
    {
        if(value==null || !ValidMatch(value.MatchId) || !System.Text.RegularExpressions.Regex.IsMatch(value.ManifestHash??"",@"\A[0-9a-f]{64}\z") ||
            !Guid.TryParseExact(value.PlayerId,"N",out _) || value.PlayerId!=value.PlayerId.ToLowerInvariant() ||
            Uri.CheckHostName(value.Host)==UriHostNameType.Unknown || value.Port is <1 or >65535 || value.Ticket.Length is <10 or >4096 ||
            value.SessionKey.Length!=32 || value.SessionId==0 || value.ExpiresUnixSeconds is <1 or >253402300799)
            throw new InvalidDataException("Invalid battle grant.");
        if(value.PlayerViews.Count!=0)
        {
            if(value.PlayerViews.Count!=2 || value.PlayerViews.Select(x=>x.PlayerId).Distinct(StringComparer.Ordinal).Count()!=2)
                throw new InvalidDataException("Invalid battle grant player views.");
            foreach(var view in value.PlayerViews)ValidateView(view);
        }
        return value.Clone();
    }
    private static void ValidateView(BattlePlayerView view)
    {
        if(view.Fraction is not (1 or 2) || view.DefendPosition is <0 or >1)
            throw new InvalidDataException("Invalid battle grant player placement.");
        var shared=new War.Shared.BattlePlayerPresentation(view.PlayerId,view.DisplayName,view.Level,view.ArmyPower,view.Skill,
            view.LeagueMedals,view.BeginnersLeague,view.LeagueId,view.Country,view.IsVip,view.VisualIds.ToArray(),
            view.Weapons.Select(x=>new War.Shared.BattleWeaponPresentation(x.Slot,x.WeaponIndex,x.SourceId,x.UpgradeIndex)).ToArray(),
            view.Units.Select(x=>new War.Shared.BattleUnitPresentation(x.SourceId,x.UpgradeIndex,x.SpecialIndex,x.EliteIndex,x.Tier)).ToArray());
        War.Shared.BattlePlayerPresentation.Validate(shared);
    }
    private static bool Same(BattleGrantDocument a,BattleGrantDocument b)=>a.MatchId==b.MatchId && a.ManifestHash==b.ManifestHash &&
        a.PlayerA==b.PlayerA && a.PlayerB==b.PlayerB && a.GrantA.AsSpan().SequenceEqual(b.GrantA) && a.GrantB.AsSpan().SequenceEqual(b.GrantB) && a.ExpiresUtc==b.ExpiresUtc;
    private static bool ValidMatch(string? value)=>System.Text.RegularExpressions.Regex.IsMatch(value??"",@"\A[a-zA-Z0-9_-]{1,64}\z");
    private static void ValidateLookup(string matchId,string playerId,long unixNow)
    {
        if(!ValidMatch(matchId) || !Guid.TryParseExact(playerId,"N",out _) ||
           playerId!=playerId.ToLowerInvariant() || unixNow is <0 or >253402300799)
            throw new InvalidDataException("Invalid battle grant lookup.");
    }
    private static DateTime RetentionDate(long ticketExpiry)
    {
        if(ticketExpiry is <1 or >253402300799-AssignmentRetentionSeconds)
            throw new InvalidDataException("Battle grant retention exceeds supported time.");
        return DateTimeOffset.FromUnixTimeSeconds(ticketExpiry+AssignmentRetentionSeconds).UtcDateTime;
    }
    private static MatchAdmission AdmissionClaims(MatchConnectionGrant grant)
    {
        try
        {
            string[] parts=grant.Ticket.Split('.');
            if(parts.Length!=2)throw new InvalidDataException("Invalid match admission ticket shape.");
            var claims=MatchAdmission.Parser.ParseFrom(Convert.FromBase64String(parts[0]));
            if(claims.MatchId!=grant.MatchId || claims.PlayerId!=grant.PlayerId ||
               claims.ManifestHash!=grant.ManifestHash || claims.SessionId!=grant.SessionId ||
               claims.ExpiresUnixSeconds!=grant.ExpiresUnixSeconds || claims.ConnectionGeneration>16)
                throw new InvalidDataException("Match admission ticket differs from its grant.");
            return claims;
        }
        catch(Exception e) when(e is FormatException or InvalidProtocolBufferException)
        {throw new InvalidDataException("Invalid match admission ticket encoding.",e);}
    }
}
