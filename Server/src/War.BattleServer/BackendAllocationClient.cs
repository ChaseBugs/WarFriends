using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.Shared;

namespace War.BattleServer;

public sealed class BackendAllocationClient
{
    private readonly HttpClient http;
    private readonly byte[] controlKey;
    private readonly string serverId;
    public BackendAllocationClient(HttpClient http, byte[] controlKey, string serverId)
    {
        this.http=http??throw new ArgumentNullException(nameof(http));
        if(controlKey is not {Length:32})throw new InvalidDataException("Backend allocation control key must be 256-bit.");
        this.controlKey=controlKey.ToArray();
        var checkedServerId=serverId??throw new InvalidDataException("Missing allocation server identity.");
        if(!System.Text.RegularExpressions.Regex.IsMatch(checkedServerId,@"\A[a-zA-Z0-9-]{1,64}\z"))
            throw new InvalidDataException("Invalid allocation server identity.");
        this.serverId=checkedServerId;
    }
    public async Task<BattleAllocationProjection[]> ReadAsync(Uri endpoint,IEnumerable<string> playerIds,CancellationToken ct)
    {
        if(endpoint==null || !endpoint.IsAbsoluteUri || endpoint.Scheme is not ("http" or "https"))
            throw new InvalidDataException("Invalid Backend allocation endpoint.");
        var ids=(playerIds??throw new ArgumentNullException(nameof(playerIds))).ToArray();
        if(ids.Length!=2 || ids.Any(string.IsNullOrWhiteSpace) || ids.Distinct(StringComparer.Ordinal).Count()!=2)
            throw new InvalidDataException("Invalid allocation participant set.");
        byte[] body=JsonSerializer.SerializeToUtf8Bytes(new {serverId,playerIds=ids});
        string timestamp=DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(System.Globalization.CultureInfo.InvariantCulture);
        byte[] prefix=Encoding.UTF8.GetBytes("war/allocation/read/v1/"+timestamp+"\n");
        byte[] signed=new byte[prefix.Length+body.Length];prefix.CopyTo(signed,0);body.CopyTo(signed,prefix.Length);
        using var request=new HttpRequestMessage(HttpMethod.Post,endpoint){Content=new ByteArrayContent(body)};
        request.Content.Headers.ContentType=new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        request.Headers.Add("X-War-Control-Time",timestamp);
        request.Headers.Add("X-War-Control-Mac",Convert.ToHexString(HMACSHA256.HashData(controlKey,signed)));
        using var response=await http.SendAsync(request,HttpCompletionOption.ResponseHeadersRead,ct);
        if(!response.IsSuccessStatusCode)throw new HttpRequestException("Backend allocation read failed: "+(int)response.StatusCode);
        var values=await response.Content.ReadFromJsonAsync<BattleAllocationProjection[]>(cancellationToken:ct)
            ?? throw new InvalidDataException("Backend allocation response is empty.");
        if(values.Length!=2)throw new InvalidDataException("Backend allocation response is incomplete.");
        var checkedValues=values.Select(BattleAllocationProjection.Validate).ToArray();
        if(!checkedValues.Select(x=>x.PlayerId).SequenceEqual(ids,StringComparer.Ordinal))
            throw new InvalidDataException("Backend allocation response order or identity differs from the request.");
        return checkedValues;
    }
}
