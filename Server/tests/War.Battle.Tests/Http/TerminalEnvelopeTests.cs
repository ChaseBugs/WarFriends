using System.Net;
using System.Text;
using System.Text.Json;
using War.BattleServer;
using War.Infrastructure;
using War.Shared;

namespace War.Battle.Tests.Http;

internal static class TerminalEnvelopeTests
{
    internal static async Task<int> RunAsync()
    {
        CheckEncodedBoundaries();
        CheckCanonicalPayload();
        await CheckLocalRefusalAsync();
        return 3;
    }

    private static void CheckEncodedBoundaries()
    {
        string serverId = new('s', TerminalResultEnvelope.MaximumIdentityCharacters);
        string matchId = new('m', TerminalResultEnvelope.MaximumIdentityCharacters);
        string digest = new('a', 64);
        foreach (int size in new[] { 1, 3, 49152, TerminalResultDigest.MaximumPayloadBytes })
        {
            byte[] payload = Enumerable.Repeat((byte)0xfb, size).ToArray();
            byte[] body = TerminalResultEnvelope.Encode(serverId, matchId, digest, payload);
            using JsonDocument document = JsonDocument.Parse(body);
            Require(body.Length <= TerminalResultEnvelope.MaximumBodyBytes &&
                document.RootElement.GetProperty("snapshot").GetBytesFromBase64().AsSpan().SequenceEqual(payload),
                "Envelope roundtrip exceeded its budget or changed binary bytes.");
            Require(!Encoding.UTF8.GetString(body).Contains("\\u002B", StringComparison.Ordinal),
                "Base64 '+' expanded into HTML-safe JSON escapes.");
            if (size == TerminalResultDigest.MaximumPayloadBytes)
            {
                Require(body.Length == TerminalResultEnvelope.MaximumBodyBytes,
                    "The derived body budget does not match maximum metadata and payload.");
            }
        }
    }

    private static void CheckCanonicalPayload()
    {
        const string MatchId = "maximum-terminal-envelope";
        byte[] payload = TerminalPayloadFixture.Create(MatchId, TerminalResultDigest.MaximumPayloadBytes);
        byte[] body = TerminalResultEnvelope.Encode("local-1", MatchId, TerminalResultDigest.Compute(payload), payload);
        Require(body.Length > TerminalResultDigest.MaximumPayloadBytes,
            "The regression fixture no longer crosses the old HTTP budget.");
    }

    private static async Task CheckLocalRefusalAsync()
    {
        using var handler = new CountingHandler();
        using var client = new HttpClient(handler);
        var forwarder = new BackendResultForwarder(client, Enumerable.Repeat((byte)2, 32).ToArray(), "local-1");
        var endpoint = new Uri("http://127.0.0.1/internal/battle/results/accept");
        byte[][] invalidPayloads = [Array.Empty<byte>(), new byte[TerminalResultDigest.MaximumPayloadBytes + 1]];
        foreach (byte[] payload in invalidPayloads)
        {
            try
            {
                await forwarder.AcceptAsync(endpoint, "fixture", new string('a', 64), payload, CancellationToken.None);
                throw new InvalidOperationException("Invalid payload reached a successful HTTP submission.");
            }
            catch (InvalidDataException)
            {
            }
        }

        try
        {
            await forwarder.AcceptAsync(endpoint, new string('m', 65), new string('a', 64), [1],
                CancellationToken.None);
            throw new InvalidOperationException("Unbounded metadata reached HTTP.");
        }
        catch (InvalidDataException)
        {
        }
        Require(handler.Sent == 0, "Invalid terminal envelope performed network I/O.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private sealed class CountingHandler : HttpMessageHandler
    {
        public int Sent { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Sent++;
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"code\":\"accepted\"}")
            });
        }
    }
}
