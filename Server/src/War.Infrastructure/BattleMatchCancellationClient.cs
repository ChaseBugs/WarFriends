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
    private const int MaximumEvidenceReplyBytes = 90000;
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
        if (response.StatusCode == HttpStatusCode.Conflict &&
            await IsUnknownMatchAsync(response, cancellationToken))
        {
            throw new BattleMatchNotRegisteredException();
        }

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new HttpRequestException("Battle cancellation failed: " + (int)response.StatusCode,
                null, response.StatusCode);
        }

        using JsonDocument document = await ReadReplyAsync(response, cancellationToken);
        return ValidateReply(document.RootElement, matchId, manifestHash);
    }

    /// <summary>Cancels the exact registration and retrieves retained proof for Backend validation.</summary>
    public async Task<(string Digest, byte[] Payload)> CancelAndReadAsync(
        Uri registrationEndpoint, string matchId, string manifestHash, CancellationToken cancellationToken)
    {
        ValidateRequest(registrationEndpoint, matchId, manifestHash);
        var cancelEndpoint = new Uri(registrationEndpoint.AbsoluteUri.TrimEnd('/') + "/cancel");
        await CancelAsync(cancelEndpoint, matchId, manifestHash, cancellationToken);
        var resultEndpoint = new Uri(new Uri(registrationEndpoint.AbsoluteUri.TrimEnd('/')), "results/find");
        byte[] body = JsonSerializer.SerializeToUtf8Bytes(new { matchId, manifestHash });
        using var request = CreateSignedRequest(resultEndpoint, body, "war/result/find/v1/");
        using var response = await _http.SendAsync(
            request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new HttpRequestException("Cancellation evidence unavailable: " + (int)response.StatusCode,
                null, response.StatusCode);
        }

        using var document = await ReadReplyAsync(response, cancellationToken, MaximumEvidenceReplyBytes);
        return DecodeEvidence(document.RootElement, matchId);
    }

    private static (string Digest, byte[] Payload) DecodeEvidence(JsonElement root, string matchId)
    {
        if (root.ValueKind != JsonValueKind.Object || root.EnumerateObject().Count() != 3 ||
            !root.TryGetProperty("matchId", out var match) || match.ValueKind != JsonValueKind.String ||
            match.GetString() != matchId ||
            !root.TryGetProperty("digest", out var digest) || digest.ValueKind != JsonValueKind.String ||
            !root.TryGetProperty("snapshot", out var snapshot) || snapshot.ValueKind != JsonValueKind.String)
        {
            throw new InvalidDataException("Invalid cancellation evidence envelope.");
        }

        byte[] payload;
        try
        {
            payload = Convert.FromBase64String(snapshot.GetString()!);
        }
        catch (FormatException failure)
        {
            throw new InvalidDataException("Invalid cancellation evidence encoding.", failure);
        }

        string hash = digest.GetString()!;
        if (payload.Length is < 1 or > War.Shared.TerminalResultDigest.MaximumPayloadBytes ||
            !Regex.IsMatch(hash, @"\A[0-9a-f]{64}\z") ||
            War.Shared.TerminalResultDigest.Compute(payload) != hash)
        {
            throw new InvalidDataException("Cancellation evidence digest differs from its payload.");
        }

        return (hash, payload);
    }

    private static async Task<bool> IsUnknownMatchAsync(
        HttpResponseMessage response, CancellationToken cancellationToken)
    {
        try
        {
            using var document = await ReadReplyAsync(response, cancellationToken);
            var root = document.RootElement;
            return root.ValueKind == JsonValueKind.Object && root.EnumerateObject().Count() == 1 &&
                root.TryGetProperty("code", out var code) && code.ValueKind == JsonValueKind.String &&
                code.GetString() == "unknown-match";
        }
        catch (InvalidDataException)
        {
            // An ambiguous refusal must never authorize a registration-recovery attempt.
            return false;
        }
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

    private HttpRequestMessage CreateSignedRequest(Uri endpoint, byte[] body, string domain = SigningDomain)
    {
        string timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);
        byte[] prefix = Encoding.UTF8.GetBytes(domain + timestamp + "\n");
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
        HttpResponseMessage response, CancellationToken cancellationToken, int maximumBytes = MaximumReplyBytes)
    {
        using Stream stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        byte[] bytes = new byte[maximumBytes + 1];
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

        if (length > maximumBytes)
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
