using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace War.BattleServer;

public sealed class BackendResultForwarder
{
    private readonly HttpClient http;
    private readonly byte[] controlKey;
    private readonly string serverId;
    public BackendResultForwarder(HttpClient http, byte[] controlKey, string serverId)
    {
        this.http = http ?? throw new ArgumentNullException(nameof(http));
        if (controlKey is not { Length: 32 }) throw new InvalidDataException("Backend result control key must be 256-bit.");
        this.controlKey = controlKey.ToArray();
        var checkedServerId = serverId ?? throw new InvalidDataException("Missing result server identity.");
        if (!System.Text.RegularExpressions.Regex.IsMatch(checkedServerId, @"\A[a-zA-Z0-9-]{1,64}\z")) throw new InvalidDataException("Invalid result server identity.");
        this.serverId = checkedServerId;
    }
    public async Task<string> AcceptAsync(Uri endpoint, string matchId, string digest, byte[] snapshot, CancellationToken ct)
    {
        if (endpoint == null || !endpoint.IsAbsoluteUri || endpoint.Scheme is not ("http" or "https") ||
            string.IsNullOrWhiteSpace(matchId) || string.IsNullOrWhiteSpace(digest) || snapshot is not { Length: > 0 and <= 65536 })
            throw new InvalidDataException("Invalid Backend result submission.");
        var body = JsonSerializer.SerializeToUtf8Bytes(new { serverId, matchId, digest, snapshot = Convert.ToBase64String(snapshot) });
        string timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(System.Globalization.CultureInfo.InvariantCulture);
        byte[] prefix = Encoding.UTF8.GetBytes("war/result/accept/v1/" + timestamp + "\n");
        byte[] signed = new byte[prefix.Length + body.Length]; prefix.CopyTo(signed, 0); body.CopyTo(signed, prefix.Length);
        using var request = new HttpRequestMessage(HttpMethod.Post, endpoint) { Content = new ByteArrayContent(body) };
        request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        request.Headers.Add("X-War-Control-Time", timestamp);
        request.Headers.Add("X-War-Control-Mac", Convert.ToHexString(HMACSHA256.HashData(controlKey, signed)));
        using var response = await http.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct);
        if ((int)response.StatusCode == 409) return "conflict";
        if (!response.IsSuccessStatusCode) throw new HttpRequestException("Backend result acceptance failed: " + (int)response.StatusCode);
        var json = await response.Content.ReadFromJsonAsync<JsonElement>(cancellationToken: ct);
        if (!json.TryGetProperty("code", out var code) || code.ValueKind != JsonValueKind.String)
            throw new InvalidDataException("Backend result acceptance response is missing its code.");
        var value = code.GetString();
        if (value is not ("accepted" or "already-accepted"))
            throw new InvalidDataException("Backend result acceptance response contains an invalid code.");
        return value;
    }
}
