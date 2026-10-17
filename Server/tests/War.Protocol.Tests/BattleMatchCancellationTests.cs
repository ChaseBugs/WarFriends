using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.Infrastructure;

/// <summary>Checks signed cancellation identity, acknowledgement validation and bounded response handling.</summary>
internal static class BattleMatchCancellationTests
{
    private const int ControlTimeoutSeconds = 5;
    private const string MatchId = "cancel-control-fixture";
    private static readonly string ManifestHash = new('a', 64);
    private static readonly byte[] ControlKey = Enumerable.Repeat((byte)7, 32).ToArray();
    private static readonly Uri Endpoint = new("http://127.0.0.1:30001/internal/matches/cancel");

    internal static async Task<int> RunAsync()
    {
        int checks = await VerifySuccessAsync();
        checks += await VerifyInvalidRepliesAsync();
        checks += await VerifyInvalidRequestsAsync();
        checks += await VerifyEvidenceRepliesAsync();
        Console.WriteLine("PASS: " + checks + " hash-bound Worker cancellation checks");
        return checks;
    }

    internal static async Task VerifyLiveReplayAsync(string endpoint, string matchId, string manifestHash)
    {
        string encodedKey = Environment.GetEnvironmentVariable("Battle__ControlKey") ??
            throw new InvalidOperationException("Set the server-only control key for the live cancellation check.");
        using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(ControlTimeoutSeconds) };
        var client = new BattleMatchCancellationClient(http, Convert.FromBase64String(encodedKey));
        string code = await client.CancelAsync(new Uri(endpoint), matchId, manifestHash, CancellationToken.None);
        Require(code == "already-cancelled", "The actual Worker must replay its persisted cancellation identity.");
        var evidence = await client.CancelAndReadAsync(
            new Uri(endpoint.TrimEnd('/')[..^"/cancel".Length]), matchId, manifestHash, CancellationToken.None);
        var terminal = War.Protocol.MatchSnapshot.Parser.ParseFrom(evidence.Payload);
        Require(terminal.MatchId == matchId && terminal.ManifestHash == manifestHash &&
            terminal.TerminalReason == "cancelled-before-start" &&
            terminal.Phase == War.Protocol.BattlePhase.Aborted,
            "The signed C# client must retrieve this exact cancellation's terminal proof.");
        string conflictingHash = (manifestHash[0] == '0' ? "1" : "0") + manifestHash.Substring(1);
        try
        {
            await client.CancelAsync(new Uri(endpoint), matchId, conflictingHash, CancellationToken.None);
        }
        catch (HttpRequestException failure) when (failure.StatusCode == HttpStatusCode.Conflict)
        {
            Console.WriteLine("PASS: signed cancellation client replays the real Worker " +
                "and rejects conflicting authority");
            return;
        }

        throw new Exception("A conflicting hash must not acknowledge an already-cancelled match.");
    }

    private static async Task<int> VerifyEvidenceRepliesAsync()
    {
        byte[] payload = [1, 2, 3];
        string digest = War.Shared.TerminalResultDigest.Compute(payload);
        string valid = JsonSerializer.Serialize(new
        {
            matchId = MatchId, digest, snapshot = Convert.ToBase64String(payload)
        });
        string[] replies =
        [
            valid,
            valid.Replace(digest, new string('0', 64)),
            valid.Replace(MatchId, "different-match"),
            valid.Replace("AQID", "invalid-base64"),
            "{}",
            new string('x', 90001)
        ];
        for (int index = 0; index < replies.Length; index++)
        {
            string text = replies[index];
            using var http = new HttpClient(new ReplyHandler(request =>
            {
                if (request.RequestUri!.AbsolutePath.EndsWith("/cancel", StringComparison.Ordinal))
                {
                    return Reply("already-cancelled", MatchId, ManifestHash);
                }

                Require(request.RequestUri.AbsolutePath == "/internal/results/find",
                    "Evidence must use the targeted result endpoint.");
                byte[] body = request.Content!.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                string timestamp = request.Headers.GetValues("X-War-Control-Time").Single();
                byte[] signed = Encoding.UTF8.GetBytes("war/result/find/v1/" + timestamp + "\n").Concat(body).ToArray();
                Require(request.Headers.GetValues("X-War-Control-Mac").Single() ==
                    Convert.ToHexString(HMACSHA256.HashData(ControlKey, signed)),
                    "Result lookup must use its separate authentication domain.");
                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(text) };
            }));
            var client = new BattleMatchCancellationClient(http, ControlKey);
            try
            {
                var evidence = await client.CancelAndReadAsync(
                    new Uri("http://127.0.0.1:30001/internal/matches"), MatchId, ManifestHash, CancellationToken.None);
                Require(index == 0 && evidence.Digest == digest && evidence.Payload.SequenceEqual(payload),
                    "Only exact, bounded, digest-checked evidence can reach Backend validation.");
            }
            catch (InvalidDataException) when (index != 0)
            {
                continue;
            }

            Require(index == 0, "Invalid cancellation evidence was accepted.");
        }

        return replies.Length;
    }

    private static async Task<int> VerifySuccessAsync()
    {
        foreach (string code in new[] { "cancelled-before-start", "already-cancelled" })
        {
            using var http = new HttpClient(new ReplyHandler(request =>
            {
                byte[] body = request.Content!.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                using JsonDocument document = JsonDocument.Parse(body);
                Require(document.RootElement.GetProperty("matchId").GetString() == MatchId &&
                    document.RootElement.GetProperty("manifestHash").GetString() == ManifestHash,
                    "Cancellation must bind both frozen identity fields.");
                string timestamp = request.Headers.GetValues("X-War-Control-Time").Single();
                byte[] prefix = Encoding.UTF8.GetBytes("war/match/control/v1/" + timestamp + "\n");
                byte[] signed = prefix.Concat(body).ToArray();
                Require(request.Headers.GetValues("X-War-Control-Mac").Single() ==
                    Convert.ToHexString(HMACSHA256.HashData(ControlKey, signed)),
                    "The exact cancellation body must be authenticated.");
                return Reply(code, MatchId, ManifestHash);
            }));
            var client = new BattleMatchCancellationClient(http, ControlKey);
            Require(await client.CancelAsync(Endpoint, MatchId, ManifestHash, CancellationToken.None) == code,
                "An exact terminal acknowledgement must remain replay-safe.");
        }

        return 6;
    }

    private static async Task<int> VerifyInvalidRepliesAsync()
    {
        HttpResponseMessage[] replies =
        [
            Reply("cancelled-before-start", "other-match", ManifestHash),
            Reply("already-cancelled", MatchId, new string('b', 64)),
            Reply("cancel-unavailable", MatchId, ManifestHash),
            new(HttpStatusCode.OK) { Content = new StringContent("{}") },
            new(HttpStatusCode.OK) { Content = new StringContent("not-json") },
            new(HttpStatusCode.OK) { Content = new StringContent(JsonSerializer.Serialize(new
                { code = "already-cancelled", matchId = MatchId, manifestHash = ManifestHash, extra = true })) },
            new(HttpStatusCode.OK) { Content = new StringContent(new string('x', 1025)) }
        ];
        foreach (HttpResponseMessage reply in replies)
        {
            using var http = new HttpClient(new ReplyHandler(_ => reply));
            var client = new BattleMatchCancellationClient(http, ControlKey);
            bool hasRejected = false;
            try
            {
                await client.CancelAsync(Endpoint, MatchId, ManifestHash, CancellationToken.None);
            }
            catch (InvalidDataException)
            {
                hasRejected = true;
            }

            Require(hasRejected, "An invalid or oversized cancellation reply must not become success.");
        }

        foreach (HttpStatusCode status in new[] { HttpStatusCode.Conflict, HttpStatusCode.Accepted })
        {
            using var http = new HttpClient(new ReplyHandler(_ => new HttpResponseMessage(status)));
            var client = new BattleMatchCancellationClient(http, ControlKey);
            bool hasRejected = false;
            try
            {
                await client.CancelAsync(Endpoint, MatchId, ManifestHash, CancellationToken.None);
            }
            catch (HttpRequestException failure) when (failure.StatusCode == status)
            {
                hasRejected = true;
            }

            Require(hasRejected, "A refusal or asynchronous acceptance is not a durable cancellation acknowledgement.");
        }

        return replies.Length + 2;
    }

    private static async Task<int> VerifyInvalidRequestsAsync()
    {
        (Uri Endpoint, string MatchId, string Hash)[] invalid =
        [
            (Endpoint, "", ManifestHash),
            (Endpoint, MatchId, new string('A', 64)),
            (new Uri("file:///cancel"), MatchId, ManifestHash)
        ];
        using var http = new HttpClient(new ReplyHandler(
            _ => throw new Exception("Invalid cancellation authority reached HTTP.")));
        var client = new BattleMatchCancellationClient(http, ControlKey);
        foreach (var request in invalid)
        {
            bool hasRejected = false;
            try
            {
                await client.CancelAsync(request.Endpoint, request.MatchId, request.Hash, CancellationToken.None);
            }
            catch (InvalidDataException)
            {
                hasRejected = true;
            }

            Require(hasRejected, "Invalid cancellation identity must fail before sending a request.");
        }

        return invalid.Length;
    }

    private static HttpResponseMessage Reply(string code, string matchId, string manifestHash)
    {
        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(JsonSerializer.Serialize(new { code, matchId, manifestHash }))
        };
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private sealed class ReplyHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> _reply;

        internal ReplyHandler(Func<HttpRequestMessage, HttpResponseMessage> reply)
        {
            _reply = reply;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_reply(request));
        }
    }
}
