using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.Infrastructure;

/// <summary>Requests a hash-bound prestart cancellation from the trusted Worker control endpoint.</summary>
public sealed class BattleMatchCancellationClient
{
    private const int ControlKeyBytes = 32;
    private const int MaximumReplyBytes = 1024;
    private const string SigningDomain = "war/match/control/v1/";
    private readonly HttpClient _http;
    private readonly byte[] _controlKey;

    /// <summary>Copies a server-only control key; the caller retains ownership of the injected HTTP client.</summary>
    public BattleMatchCancellationClient(HttpClient http, byte[] controlKey)
    {
        _http = http ?? throw new ArgumentNullException(nameof(http));
        if (controlKey is not { Length: ControlKeyBytes })
        {
            throw new InvalidDataException("Battle cancellation requires a 256-bit control key.");
        }

        _controlKey = controlKey.ToArray();
    }

    /// <summary>Returns success only for the exact requested identity and frozen manifest hash.</summary>
    public async Task<string> CancelAsync(
        Uri endpoint, string matchId, string manifestHash, CancellationToken cancellationToken)
    {
        ValidateRequest(endpoint, matchId, manifestHash);
        byte[] body = JsonSerializer.SerializeToUtf8Bytes(new { matchId, manifestHash });
        using HttpRequestMessage request = CreateSignedRequest(endpoint, body);
        using HttpResponseMessage response = await _http.SendAsync(
            request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new HttpRequestException("Battle cancellation failed: " + (int)response.StatusCode,
                null, response.StatusCode);
        }

        using JsonDocument document = await ReadReplyAsync(response, cancellationToken);
        return ValidateReply(document.RootElement, matchId, manifestHash);
    }

    private static void ValidateRequest(Uri endpoint, string matchId, string manifestHash)
    {
        if (endpoint == null || !endpoint.IsAbsoluteUri || endpoint.Scheme is not ("http" or "https") ||
            !Regex.IsMatch(matchId ?? "", @"\A[a-zA-Z0-9_-]{1,64}\z") ||
            !Regex.IsMatch(manifestHash ?? "", @"\A[0-9a-f]{64}\z"))
        {
            throw new InvalidDataException("Invalid hash-bound battle cancellation request.");
        }
    }

    private HttpRequestMessage CreateSignedRequest(Uri endpoint, byte[] body)
    {
        string timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);
        byte[] prefix = Encoding.UTF8.GetBytes(SigningDomain + timestamp + "\n");
        byte[] signed = new byte[prefix.Length + body.Length];
        prefix.CopyTo(signed, 0);
        body.CopyTo(signed, prefix.Length);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
        {
            Content = new ByteArrayContent(body)
        };
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        request.Headers.Add("X-War-Control-Time", timestamp);
        request.Headers.Add("X-War-Control-Mac", Convert.ToHexString(HMACSHA256.HashData(_controlKey, signed)));
        return request;
    }

    private static async Task<JsonDocument> ReadReplyAsync(
        HttpResponseMessage response, CancellationToken cancellationToken)
    {
        using Stream stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        byte[] bytes = new byte[MaximumReplyBytes + 1];
        int length = 0;
        while (length < bytes.Length)
        {
            int read = await stream.ReadAsync(bytes.AsMemory(length), cancellationToken);
            if (read == 0)
            {
                break;
            }

            length += read;
        }

        if (length > MaximumReplyBytes)
        {
            throw new InvalidDataException("Battle cancellation response exceeded its byte limit.");
        }

        try
        {
            return JsonDocument.Parse(bytes.AsMemory(0, length));
        }
        catch (JsonException failure)
        {
            throw new InvalidDataException("Malformed battle cancellation response.", failure);
        }
    }

    private static string ValidateReply(JsonElement root, string matchId, string manifestHash)
    {
        if (root.ValueKind != JsonValueKind.Object || root.EnumerateObject().Count() != 3 ||
            !root.TryGetProperty("code", out JsonElement code) || code.ValueKind != JsonValueKind.String ||
            code.GetString() is not ("cancelled-before-start" or "already-cancelled") ||
            !root.TryGetProperty("matchId", out JsonElement match) || match.ValueKind != JsonValueKind.String ||
            match.GetString() != matchId ||
            !root.TryGetProperty("manifestHash", out JsonElement hash) || hash.ValueKind != JsonValueKind.String ||
            hash.GetString() != manifestHash)
        {
            throw new InvalidDataException("Cancellation acknowledgement differs from frozen match authority.");
        }

        return code.GetString()!;
    }
}
