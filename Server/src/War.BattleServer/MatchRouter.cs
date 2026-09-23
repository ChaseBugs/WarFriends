using System.Net;
using System.Security.Cryptography;
using Google.Protobuf;
using War.Protocol;

namespace War.BattleServer;

public sealed record MatchRegistrationResult(string Code,string ManifestHash,
    IReadOnlyList<MatchConnectionGrant>? Grants=null);

/// <summary>Single-writer bounded host registry. UDP packets cannot allocate matches.</summary>
public sealed class MatchRouter
{
    private readonly Dictionary<string, MatchEndpoint> matches;
    private readonly string serverId;
    private readonly string signingKey;
    private readonly MatchTokens tokens;
    private readonly string publicHost;
    private readonly uint publicPort;
    private readonly IReadOnlyList<RecoveredBattleMap>? maps;
    private readonly BattleCombatContent? content;
    private readonly int maxMatches;
    private readonly Dictionary<string,MatchConnectionGrant[]> issued=new(StringComparer.Ordinal);
    private readonly Dictionary<string,ulong[]> issuedGenerations=new(StringComparer.Ordinal);
    private readonly Dictionary<string,List<ulong>> reservedByMatch=new(StringComparer.Ordinal);
    private sealed record ReconnectReceipt(string MatchId,string PlayerId,MatchConnectionGrant Grant);
    private readonly Dictionary<string,ReconnectReceipt> reconnectReceipts=new(StringComparer.Ordinal);
    private readonly Dictionary<string,List<string>> reconnectRequestsByMatch=new(StringComparer.Ordinal);
    private readonly HashSet<ulong> issuedSessions=[];
    private readonly HashSet<string> publishedTerminals=new(StringComparer.Ordinal);
    private ulong currentTick;
    public int Count => matches.Count;
    public Dictionary<ulong,IPEndPoint> ActiveSessionEndpoints() => matches.Values
        .SelectMany(match=>match.ActiveSessionEndpoints).ToDictionary(pair=>pair.Key,pair=>pair.Value);
    public IEnumerable<string> MatchIds => matches.Keys;
    public bool ContainsMatch(string matchId) => matches.ContainsKey(matchId);
    public MatchRouter(IEnumerable<MatchManifest> manifests, string serverId, string signingKey,
        IReadOnlyList<RecoveredBattleMap>? maps = null,BattleCombatContent? content=null,
        string publicHost="127.0.0.1",uint publicPort=30000,int maxMatches=32)
    {
        if(maxMatches is <1 or >1024)throw new InvalidDataException("Invalid match capacity.");
        this.maxMatches=maxMatches;
        var all = manifests.Take(maxMatches+1).ToArray();
        if (all.Length > maxMatches) throw new InvalidDataException("Match allocation exceeds configured capacity.");
        this.serverId=serverId;
        this.signingKey=signingKey;
        tokens=new MatchTokens(signingKey);
        if(Uri.CheckHostName(publicHost)==UriHostNameType.Unknown || publicPort is <1 or >65535)
            throw new InvalidDataException("Invalid public battle endpoint.");
        this.publicHost=publicHost;
        this.publicPort=publicPort;
        this.maps=maps;
        this.content=content;
        matches=new Dictionary<string,MatchEndpoint>(StringComparer.Ordinal);
        foreach(var manifest in all)
            if(Register(manifest).Code!="registered")throw new InvalidDataException("Duplicate startup match allocation.");
    }
    public MatchRegistrationResult Register(MatchManifest source,long? unixNow=null)
    {
        var manifest=MatchManifest.Validate(source);
        long now=unixNow??DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        if(now is <0 or >MatchTokens.MaximumUnixSecond)throw new InvalidDataException("Invalid match grant time.");
        if(manifest.ServerId!=serverId)return new("wrong-host","");
        if(matches.TryGetValue(manifest.MatchId,out var prior))
        {
            if(prior.ManifestHash!=manifest.Digest())return new("duplicate-match","");
            if(prior.TerminalSnapshot!=null)return new("match-terminal",prior.ManifestHash);
            if(issued[manifest.MatchId].Any(grant=>grant.ExpiresUnixSeconds<=now))
                return new("admission-expired",prior.ManifestHash);
            return new("existing-match",prior.ManifestHash,CloneGrants(issued[manifest.MatchId]));
        }
        if(matches.Count>=maxMatches)return new("match-capacity","");
        if(now>MatchTokens.MaximumUnixSecond-MatchTokens.GrantLifetimeSeconds)
            throw new InvalidDataException("Match grant expiration exceeds supported time.");
        var map=maps?.SingleOrDefault(x=>Path.GetFileNameWithoutExtension(x.Source)==manifest.MapId);
        var endpoint=new MatchEndpoint(manifest,signingKey,map,content,currentTick);
        if (manifest.Allocations is { } allocations)
            endpoint.ConfigureBattleAllocations(allocations);
        var grants=new MatchConnectionGrant[2];
        var reservedSessions=new List<ulong>(2);
        try
        {
            for(int i=0;i<2;i++)
            {
                ulong session;
                do {session=BitConverter.ToUInt64(RandomNumberGenerator.GetBytes(8));}
                while(session==0 || !issuedSessions.Add(session));
                reservedSessions.Add(session);
                var claims=new MatchAdmission {MatchId=manifest.MatchId,
                    PlayerId=manifest.Players[i].PlayerId,ServerId=serverId,
                    ManifestHash=endpoint.ManifestHash,SessionId=session,
                    IssuedUnixSeconds=now,ExpiresUnixSeconds=now+MatchTokens.GrantLifetimeSeconds};
                grants[i]=new MatchConnectionGrant {Host=publicHost,Port=publicPort,
                    Ticket=tokens.Sign(claims),SessionKey=ByteString.CopyFrom(tokens.SessionKey(claims)),
                    SessionId=session,MatchId=manifest.MatchId,PlayerId=claims.PlayerId,
                    ManifestHash=endpoint.ManifestHash,ExpiresUnixSeconds=claims.ExpiresUnixSeconds};
            }
            endpoint.Advance(currentTick);
            matches.Add(manifest.MatchId,endpoint);
            issued.Add(manifest.MatchId,grants);
            issuedGenerations.Add(manifest.MatchId,new ulong[2]);
            reservedByMatch.Add(manifest.MatchId,reservedSessions);
            reconnectRequestsByMatch.Add(manifest.MatchId,[]);
        }
        catch
        {
            matches.Remove(manifest.MatchId);
            issued.Remove(manifest.MatchId);
            issuedGenerations.Remove(manifest.MatchId);
            reservedByMatch.Remove(manifest.MatchId);
            reconnectRequestsByMatch.Remove(manifest.MatchId);
            foreach(var session in reservedSessions)issuedSessions.Remove(session);
            throw;
        }
        return new("registered",endpoint.ManifestHash,CloneGrants(grants));
    }
    private static IReadOnlyList<MatchConnectionGrant> CloneGrants(MatchConnectionGrant[] source)
        =>Array.AsReadOnly(source.Select(grant=>grant.Clone()).ToArray());
    public MatchRegistrationResult CancelBeforeStart(string matchId)
    {
        if(!matches.TryGetValue(matchId,out var endpoint))return new("unknown-match","");
        if(endpoint.CancelBeforeStart())return new("cancelled-before-start",endpoint.ManifestHash);
        return endpoint.TerminalSnapshot?.TerminalReason=="cancelled-before-start"
            ?new("already-cancelled",endpoint.ManifestHash)
            :new("cancel-unavailable",endpoint.ManifestHash);
    }
    public MatchRegistrationResult Reconnect(string matchId,string playerId,string requestId,long? unixNow=null)
    {
        if(!Guid.TryParseExact(requestId,"N",out _) || requestId!=requestId.ToLowerInvariant())
            return new("invalid-reconnect","");
        long now=unixNow??DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        if(now is <0 or >MatchTokens.MaximumUnixSecond)throw new InvalidDataException("Invalid match grant time.");
        if(reconnectReceipts.TryGetValue(requestId,out var receipt))
            return receipt.MatchId==matchId && receipt.PlayerId==playerId
                ?receipt.Grant.ExpiresUnixSeconds<=now
                    ?new("reconnect-expired",receipt.Grant.ManifestHash)
                    :new("reconnect-existing",receipt.Grant.ManifestHash,[receipt.Grant.Clone()])
                :new("reconnect-conflict","");
        if(!matches.TryGetValue(matchId,out var endpoint))return new("unknown-match","");
        var grants=issued[matchId];
        int index=Array.FindIndex(grants,g=>g.PlayerId==playerId);
        if(index<0)return new("unknown-player","");
        if(!endpoint.CanReconnect(playerId))return new("reconnect-unavailable","");
        if(now>MatchTokens.MaximumUnixSecond-MatchTokens.GrantLifetimeSeconds)
            throw new InvalidDataException("Reconnect grant expiration exceeds supported time.");
        ulong generation=issuedGenerations[matchId][index];
        var priorGrant=grants[index];
        if(generation>=16)return new("reconnect-limit","");
        ulong session;
        do {session=BitConverter.ToUInt64(RandomNumberGenerator.GetBytes(8));}
        while(session==0 || !issuedSessions.Add(session));
        try
        {
            var claims=new MatchAdmission {MatchId=matchId,PlayerId=playerId,ServerId=serverId,
                ManifestHash=endpoint.ManifestHash,SessionId=session,ConnectionGeneration=generation+1,
                IssuedUnixSeconds=now,ExpiresUnixSeconds=now+MatchTokens.GrantLifetimeSeconds};
            var next=new MatchConnectionGrant {Host=publicHost,Port=publicPort,
                Ticket=tokens.Sign(claims),SessionKey=ByteString.CopyFrom(tokens.SessionKey(claims)),
                SessionId=session,MatchId=matchId,PlayerId=playerId,
                ManifestHash=endpoint.ManifestHash,ExpiresUnixSeconds=claims.ExpiresUnixSeconds};
            var resultGrant=next.Clone();
            issuedGenerations[matchId][index]=generation+1;
            grants[index]=next;
            reservedByMatch[matchId].Add(session);
            reconnectReceipts.Add(requestId,new ReconnectReceipt(matchId,playerId,next.Clone()));
            reconnectRequestsByMatch[matchId].Add(requestId);
            return new("reconnect-issued",endpoint.ManifestHash,[resultGrant]);
        }
        catch
        {
            issuedGenerations[matchId][index]=generation;
            grants[index]=priorGrant;
            reservedByMatch[matchId].Remove(session);
            reconnectReceipts.Remove(requestId);
            reconnectRequestsByMatch[matchId].Remove(requestId);
            issuedSessions.Remove(session);
            throw;
        }
    }
    public bool Owns(ulong session) => matches.Values.Any(m => m.Owns(session));
    public IEnumerable<MatchSnapshot> UnpublishedTerminals()
        =>matches.Where(x=>!publishedTerminals.Contains(x.Key))
            .Select(x=>x.Value.TerminalSnapshot).OfType<MatchSnapshot>();
    public int AbortForHostShutdown()
    {
        int aborted=0;
        foreach(var endpoint in matches.Values)
            if(endpoint.AbortForHostShutdown())aborted++;
        return aborted;
    }
    public void MarkTerminalPublished(string matchId)
    {
        if(!matches.ContainsKey(matchId))throw new InvalidOperationException("Unknown terminal match.");
        publishedTerminals.Add(matchId);
    }
    public void Advance(ulong tick)
    {
        if(tick<currentTick)throw new InvalidOperationException("Match registry tick moved backwards.");
        currentTick=tick;
        foreach(var match in matches.Values)match.Advance(tick);
        foreach(var id in matches.Where(x=>x.Value.Expired).Select(x=>x.Key).ToArray())
        {
            matches.Remove(id);
            foreach(var session in reservedByMatch[id])issuedSessions.Remove(session);
            issued.Remove(id);
            issuedGenerations.Remove(id);
            reservedByMatch.Remove(id);
            foreach(var requestId in reconnectRequestsByMatch[id])reconnectReceipts.Remove(requestId);
            reconnectRequestsByMatch.Remove(id);
            publishedTerminals.Remove(id);
        }
    }
    public byte[]? Handle(Packet packet, byte[] bytes, IPEndPoint endpoint, long now)
    {
        MatchEndpoint? match;
        if (packet.BodyCase == Packet.BodyOneofCase.MatchHello)
        {
            // Compatibility for the original single-match harness only. Multiple
            // allocations require an explicit ID, subsequently authenticated by ticket.
            if (packet.MatchHello.MatchId.Length == 0 && matches.Count == 1) match = matches.Values.Single();
            else if (!matches.TryGetValue(packet.MatchHello.MatchId, out match)) return null;
            if (Owns(packet.SessionId) && !match.Owns(packet.SessionId)) return null;
        }
        else match = matches.Values.FirstOrDefault(m => m.Owns(packet.SessionId));
        return match?.Handle(packet, bytes, endpoint, now);
    }
}
