using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using War.BattleServer;
using War.Infrastructure;
using War.Shared;

namespace War.Battle.Tests.Http;

internal static class BackendLargeTerminalHttpTests
{
    private const string ResultPath = "/internal/battle/results/accept";
    private const string ResultDomain = "war/result/accept/v1/";
    private const int SingleByteChunkBytes = 6;
    private const int FinalChunkBytes = 5;

    internal static async Task<int> RunAsync(HttpClient client, byte[] key, IMongoCollection<BsonDocument> results)
    {
        string matchId = "large-http-" + Guid.NewGuid().ToString("N");
        byte[] payload = TerminalPayloadFixture.Create(matchId, TerminalResultDigest.MaximumPayloadBytes);
        string digest = TerminalResultDigest.Compute(payload);
        var forwarder = new BackendResultForwarder(client, key, "local-1");
        var endpoint = new Uri(client.BaseAddress!, ResultPath);
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(15));
        string accepted = await forwarder.AcceptAsync(endpoint, matchId, digest, payload, deadline.Token);
        string replay = await forwarder.AcceptAsync(endpoint, matchId, digest, payload, deadline.Token);
        BsonDocument stored = await results.Find(new BsonDocument("MatchId", matchId)).SingleAsync();
        Require(accepted == "accepted" && replay == "already-accepted" &&
            stored["Snapshot"].AsByteArray.AsSpan().SequenceEqual(payload) && !stored["Settled"].AsBoolean,
            "The maximum binary terminal lost its exact durable replay.");

        await CheckExactBodyLimitAsync(client, key,
            TerminalResultEnvelope.Encode("local-1", matchId, digest, payload));
        await CheckBinaryOversizeAsync(client, key, results);
        await CheckOtherRouteLimitAsync(client);
        Console.WriteLine($"PASS: {payload.Length}-byte terminal and {TerminalResultEnvelope.MaximumBodyBytes}-byte " +
            "declared/chunked envelope replay; binary excess and other-route budgets remain closed");
        return 9;
    }

    private static async Task CheckExactBodyLimitAsync(HttpClient client, byte[] key, byte[] encoded)
    {
        byte[] exact = new byte[TerminalResultEnvelope.MaximumBodyBytes];
        encoded.CopyTo(exact, 0);
        // Existing JSON parsing permits trailing whitespace; pad only the transport envelope.
        Array.Fill(exact, (byte)' ', encoded.Length, exact.Length - encoded.Length);
        foreach (bool chunked in new[] { false, true })
        {
            using HttpRequestMessage request = SignedRequest(key, exact);
            request.Headers.TransferEncodingChunked = chunked;
            using HttpResponseMessage response = await client.SendAsync(request);
            Require(response.StatusCode == HttpStatusCode.OK,
                $"Exact result envelope chunked={chunked} returned {(int)response.StatusCode}.");
            using JsonDocument json = JsonDocument.Parse(await response.Content.ReadAsByteArrayAsync());
            Require(response.StatusCode == HttpStatusCode.OK &&
                json.RootElement.GetProperty("code").GetString() == "already-accepted",
                "The exact result HTTP budget refused a valid declared/chunked replay.");
        }
        await CheckSingleByteChunksAsync(client.BaseAddress!, key, exact);
    }

    private static async Task CheckSingleByteChunksAsync(Uri endpoint, byte[] key, byte[] body)
    {
        string stamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            .ToString(System.Globalization.CultureInfo.InvariantCulture);
        byte[] signed = Encoding.UTF8.GetBytes(ResultDomain + stamp + "\n").Concat(body).ToArray();
        string mac = Convert.ToHexString(HMACSHA256.HashData(key, signed));
        string headers = $"POST {ResultPath} HTTP/1.1\r\nHost: {endpoint.Authority}\r\n" +
            $"Transfer-Encoding: chunked\r\nConnection: close\r\nX-War-Control-Time: {stamp}\r\n" +
            $"X-War-Control-Mac: {mac}\r\n\r\n";
        byte[] framed = new byte[body.Length * SingleByteChunkBytes + FinalChunkBytes];
        for (int index = 0; index < body.Length; index++)
        {
            int offset = index * SingleByteChunkBytes;
            framed[offset] = (byte)'1';
            framed[offset + 1] = (byte)'\r';
            framed[offset + 2] = (byte)'\n';
            framed[offset + 3] = body[index];
            framed[offset + 4] = (byte)'\r';
            framed[offset + 5] = (byte)'\n';
        }
        "0\r\n\r\n"u8.CopyTo(framed.AsSpan(body.Length * SingleByteChunkBytes));
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(15));
        using var socket = new TcpClient { NoDelay = true };
        await socket.ConnectAsync(endpoint.Host, endpoint.Port, deadline.Token);
        await using NetworkStream stream = socket.GetStream();
        await stream.WriteAsync(Encoding.ASCII.GetBytes(headers), deadline.Token);
        await stream.WriteAsync(framed, deadline.Token);
        using var response = new StreamReader(stream, Encoding.UTF8, leaveOpen: true);
        string text = await response.ReadToEndAsync(deadline.Token);
        Require(text.StartsWith("HTTP/1.1 200 ", StringComparison.Ordinal) &&
            text.Contains("already-accepted", StringComparison.Ordinal),
            "Canonical one-byte chunks could not carry the exact decoded envelope budget.");
    }

    private static async Task CheckBinaryOversizeAsync(HttpClient client, byte[] key,
        IMongoCollection<BsonDocument> results)
    {
        long before = await results.CountDocumentsAsync(FilterDefinition<BsonDocument>.Empty);
        byte[] malformed = JsonSerializer.SerializeToUtf8Bytes(new
        {
            serverId = "local-1", matchId = "oversized-binary-fixture", digest = new string('a', 64),
            snapshot = Convert.ToBase64String(new byte[TerminalResultDigest.MaximumPayloadBytes + 1])
        });
        Require(malformed.Length <= TerminalResultEnvelope.MaximumBodyBytes,
            "Binary oversize fixture no longer fits the independent JSON budget.");
        using HttpRequestMessage request = SignedRequest(key, malformed);
        using HttpResponseMessage response = await client.SendAsync(request);
        Require(response.StatusCode == HttpStatusCode.BadRequest &&
            await results.CountDocumentsAsync(FilterDefinition<BsonDocument>.Empty) == before,
            "A signed over-budget binary snapshot changed durable authority.");
    }

    private static async Task CheckOtherRouteLimitAsync(HttpClient client)
    {
        const int ProtobufBodyLimit = 65536;
        foreach (bool chunked in new[] { false, true })
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, "/v1/accounts/register")
            {
                Content = new ByteArrayContent(new byte[ProtobufBodyLimit + 1])
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-protobuf");
            request.Headers.TransferEncodingChunked = chunked;
            using HttpResponseMessage response = await client.SendAsync(request);
            Require(response.StatusCode == HttpStatusCode.RequestEntityTooLarge,
                "The larger result envelope widened an unrelated API limit.");
        }
    }

    private static HttpRequestMessage SignedRequest(byte[] key, byte[] body)
    {
        string stamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            .ToString(System.Globalization.CultureInfo.InvariantCulture);
        byte[] prefix = Encoding.UTF8.GetBytes(ResultDomain + stamp + "\n");
        var request = new HttpRequestMessage(HttpMethod.Post, ResultPath) { Content = new ByteArrayContent(body) };
        request.Headers.Add("X-War-Control-Time", stamp);
        request.Headers.Add("X-War-Control-Mac",
            Convert.ToHexString(HMACSHA256.HashData(key, prefix.Concat(body).ToArray())));
        return request;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
