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
            rows[0].ExpiresUnixSeconds!=rows[1].ExpiresUnixSeconds || rows.Any(x=>x.PlayerViews.Count!=2) ||
            rows.Any(x=>!x.PlayerViews.Select(v=>v.PlayerId).SequenceEqual(rows.Select(r=>r.PlayerId),StringComparer.Ordinal)))
            throw new InvalidDataException("Invalid battle grant assignment.");
        var doc=new BattleGrantDocument{Id=Guid.NewGuid().ToString("N"),MatchId=matchId,ManifestHash=manifestHash,
            PlayerA=rows[0].PlayerId,PlayerB=rows[1].PlayerId,GrantA=rows[0].ToByteArray(),GrantB=rows[1].ToByteArray(),
            ExpiresUtc=DateTimeOffset.FromUnixTimeSeconds(rows[0].ExpiresUnixSeconds).UtcDateTime};
        try {await grants.InsertOneAsync(doc,cancellationToken:ct);return "published";}
        catch(MongoWriteException e) when(e.WriteError.Category==ServerErrorCategory.DuplicateKey)
        {
            var prior=await grants.Find(x=>x.MatchId==matchId).FirstOrDefaultAsync(ct);
            return prior!=null && Same(prior,doc)?"already-published":"conflict";
        }
    }
    public async Task<MatchConnectionGrant?> GetForPlayer(string matchId,string playerId,long unixNow,CancellationToken ct)
    {
        if(!ValidMatch(matchId) || !Guid.TryParseExact(playerId,"N",out _) || playerId!=playerId.ToLowerInvariant() || unixNow<0)
            throw new InvalidDataException("Invalid battle grant lookup.");
        var row=await grants.Find(x=>x.MatchId==matchId && (x.PlayerA==playerId || x.PlayerB==playerId)).FirstOrDefaultAsync(ct);
        if(row==null)return null;
        byte[] bytes=row.PlayerA==playerId?row.GrantA:row.GrantB;
        MatchConnectionGrant grant;
        try {grant=MatchConnectionGrant.Parser.ParseFrom(bytes);}catch(InvalidProtocolBufferException e){throw new InvalidDataException("Invalid persisted battle grant.",e);}
        grant=Validate(grant);
        if(grant.MatchId!=row.MatchId || grant.ManifestHash!=row.ManifestHash || grant.PlayerId!=playerId ||
            grant.ExpiresUnixSeconds<=unixNow || row.ExpiresUtc!=DateTimeOffset.FromUnixTimeSeconds(grant.ExpiresUnixSeconds).UtcDateTime)
            throw new InvalidDataException("Persisted battle grant authority differs from its index.");
        return grant.Clone();
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
}
