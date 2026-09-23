using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.Protocol;

namespace War.Infrastructure;

public sealed record BattleMatchRegistration(string Code,string MatchId,string ManifestHash,
    IReadOnlyList<MatchConnectionGrant> Grants);

/// <summary>Trusted Backend allocator bridge to the loopback BattleServer control endpoint.</summary>
public sealed class BattleMatchControlClient
{
    private readonly HttpClient http;
    private readonly byte[] key;
    public BattleMatchControlClient(HttpClient http,byte[] controlKey)
    {
        this.http=http??throw new ArgumentNullException(nameof(http));
        if(controlKey is not {Length:32})throw new InvalidDataException("Battle control key must be 256-bit.");
        key=controlKey.ToArray();
    }
    public async Task<BattleMatchRegistration> RegisterAsync(Uri endpoint,byte[] canonicalManifest,
        string expectedMatchId,IEnumerable<string> expectedPlayerIds,CancellationToken ct)
    {
        if(endpoint==null || !endpoint.IsAbsoluteUri || endpoint.Scheme is not ("http" or "https") ||
            canonicalManifest is not {Length:>0 and <=65536} || !ValidMatchId(expectedMatchId))
            throw new InvalidDataException("Invalid battle registration request.");
        string[] players=(expectedPlayerIds??throw new ArgumentNullException(nameof(expectedPlayerIds))).ToArray();
        if(players.Length!=2 || players.Any(x=>!Guid.TryParseExact(x,"N",out _) || x!=x.ToLowerInvariant()) ||
            players.Distinct(StringComparer.Ordinal).Count()!=2)
            throw new InvalidDataException("Invalid battle registration roster.");
        string timestamp=DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(System.Globalization.CultureInfo.InvariantCulture);
        byte[] prefix=Encoding.UTF8.GetBytes("war/match/control/v1/"+timestamp+"\n");
        byte[] signed=new byte[prefix.Length+canonicalManifest.Length];prefix.CopyTo(signed,0);canonicalManifest.CopyTo(signed,prefix.Length);
        using var request=new HttpRequestMessage(HttpMethod.Post,endpoint){Content=new ByteArrayContent(canonicalManifest)};
        request.Content.Headers.ContentType=new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        request.Headers.Add("X-War-Control-Time",timestamp);
        request.Headers.Add("X-War-Control-Mac",Convert.ToHexString(HMACSHA256.HashData(key,signed)));
        using var response=await http.SendAsync(request,HttpCompletionOption.ResponseHeadersRead,ct);
        if(!response.IsSuccessStatusCode)throw new HttpRequestException("Battle registration failed: "+(int)response.StatusCode);
        using var document=JsonDocument.Parse(await response.Content.ReadAsByteArrayAsync(ct));
        var root=document.RootElement;
        if(root.ValueKind!=JsonValueKind.Object || root.EnumerateObject().Count()!=4 ||
            !root.TryGetProperty("code",out var codeNode) || codeNode.ValueKind!=JsonValueKind.String ||
            codeNode.GetString() is not ("registered" or "existing-match") ||
            !root.TryGetProperty("matchId",out var matchNode) || matchNode.ValueKind!=JsonValueKind.String || matchNode.GetString()!=expectedMatchId ||
            !root.TryGetProperty("manifestHash",out var hashNode) || hashNode.ValueKind!=JsonValueKind.String ||
            !System.Text.RegularExpressions.Regex.IsMatch(hashNode.GetString()??"",@"\A[0-9a-f]{64}\z") ||
            !root.TryGetProperty("grants",out var grantsNode) || grantsNode.ValueKind!=JsonValueKind.Array || grantsNode.GetArrayLength()!=2)
            throw new InvalidDataException("Invalid battle registration response.");
        string hash=hashNode.GetString()!;
        var grants=grantsNode.EnumerateArray().Select(ParseGrant).ToArray();
        for(int i=0;i<2;i++)
            if(grants[i].MatchId!=expectedMatchId || grants[i].ManifestHash!=hash || grants[i].PlayerId!=players[i])
                throw new InvalidDataException("Battle registration grant identity or order differs from the roster.");
        if(grants.Select(x=>x.SessionId).Distinct().Count()!=2)
            throw new InvalidDataException("Battle registration grants share a session identity.");
        return new BattleMatchRegistration(codeNode.GetString()!,expectedMatchId,hash,Array.AsReadOnly(grants));
    }
    private static MatchConnectionGrant ParseGrant(JsonElement row)
    {
        if(row.ValueKind!=JsonValueKind.Object || row.EnumerateObject().Count()!=9)throw new InvalidDataException("Invalid battle grant shape.");
        try
        {
            var grant=new MatchConnectionGrant
            {
                Host=row.GetProperty("host").GetString()!,Port=row.GetProperty("port").GetUInt32(),
                Ticket=row.GetProperty("ticket").GetString()!,SessionKey=Google.Protobuf.ByteString.CopyFrom(Convert.FromBase64String(row.GetProperty("sessionKey").GetString()!)),
                SessionId=row.GetProperty("sessionId").GetUInt64(),MatchId=row.GetProperty("matchId").GetString()!,
                PlayerId=row.GetProperty("playerId").GetString()!,ManifestHash=row.GetProperty("manifestHash").GetString()!,
                ExpiresUnixSeconds=row.GetProperty("expiresUnixSeconds").GetInt64()
            };
            if(Uri.CheckHostName(grant.Host)==UriHostNameType.Unknown || grant.Port is <1 or >65535 || grant.Ticket.Length is <10 or >4096 ||
                grant.SessionKey.Length!=32 || grant.SessionId==0 || !ValidMatchId(grant.MatchId) ||
                !Guid.TryParseExact(grant.PlayerId,"N",out _) || grant.PlayerId!=grant.PlayerId.ToLowerInvariant() ||
                !System.Text.RegularExpressions.Regex.IsMatch(grant.ManifestHash,@"\A[0-9a-f]{64}\z") ||
                grant.ExpiresUnixSeconds is <0 or >253402300799)
                throw new InvalidDataException("Invalid battle grant authority.");
            return grant;
        }
        catch(Exception e) when(e is KeyNotFoundException or InvalidOperationException or FormatException or OverflowException)
        {throw new InvalidDataException("Invalid battle grant encoding.",e);}
    }
    private static bool ValidMatchId(string? value)=>System.Text.RegularExpressions.Regex.IsMatch(value??"",@"\A[a-zA-Z0-9_-]{1,64}\z");
}
