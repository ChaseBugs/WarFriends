using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using War.BattleServer;
using War.Infrastructure;
using War.Shared;

namespace War.Battle.Tests.Http;

/// <summary>Checks the actual internal HTTP body/MAC boundary and durable terminal replay.</summary>
internal static class BackendInternalHttpTests
{
    private const int ControlBodyBytes = 65536;
    private const int AllocationBodyBytes = 2048;
    private const int HttpTimeoutSeconds = 10;
    private const int ExpiredSignatureSeconds = 60;
    private static readonly Route[] Routes =
    [
        new("/internal/battle/results/accept", "war/result/accept/v1/", TerminalResultEnvelope.MaximumBodyBytes),
        new("/internal/battle/allocations/read", "war/allocation/read/v1/", AllocationBodyBytes),
        new("/internal/battle/matches/provision", "war/match/provision/v1/", ControlBodyBytes)
    ];

    internal static async Task RunAsync(string uri, string databaseName, string baseUrl)
    {
        byte[] key = Convert.FromBase64String(Environment.GetEnvironmentVariable("Battle__ControlKey")
            ?? throw new InvalidOperationException("The owned smoke control key is required."));
        IMongoDatabase database = new MongoClient(uri).GetDatabase(databaseName);
        IMongoCollection<BsonDocument> results = database.GetCollection<BsonDocument>("battle_results");
        long before = await results.CountDocumentsAsync(FilterDefinition<BsonDocument>.Empty);
        using var client = new HttpClient
        {
            BaseAddress = new Uri(baseUrl),
            Timeout = TimeSpan.FromSeconds(HttpTimeoutSeconds)
        };
        int checks = 0;
        foreach (Route route in Routes)
        {
            checks += await CheckBoundaryAsync(client, route, key);
        }
        Require(await results.CountDocumentsAsync(FilterDefinition<BsonDocument>.Empty) == before,
            "Rejected internal requests changed durable terminal authority.");
        checks += await CheckAcceptedReplayAsync(client, key, results);
        checks += await BackendLargeTerminalHttpTests.RunAsync(client, key, results);
        Console.WriteLine($"PASS: {checks + 1} native Backend internal body/MAC/terminal-replay checks");
    }

    private static async Task<int> CheckBoundaryAsync(HttpClient client, Route route, byte[] key)
    {
        foreach (bool chunked in new[] { false, true })
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, route.Path)
            {
                Content = new ByteArrayContent(new byte[route.MaximumBytes + 1]),
                Version = HttpVersion.Version11
            };
            request.Headers.TransferEncodingChunked = chunked;
            using HttpResponseMessage response = await SendOversizeAsync(client, request, route, chunked);
            Require(response.StatusCode == HttpStatusCode.RequestEntityTooLarge,
                $"{route.Path}: oversized chunked={chunked} returned {(int)response.StatusCode}, expected 413.");
            Require(response.Headers.ConnectionClose == true,
                route.Path + ": oversized HTTP/1 response left its connection reusable.");
        }

        using var atLimit = new ByteArrayContent(new byte[route.MaximumBytes]);
        using HttpResponseMessage boundary = await client.PostAsync(route.Path, atLimit);
        Require(boundary.StatusCode == HttpStatusCode.Unauthorized,
            route.Path + ": an in-budget unsigned body did not reach the MAC boundary.");
        byte[] malformed = Encoding.UTF8.GetBytes("{}");
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        using HttpRequestMessage signed = CreateSigned(route, malformed, key, now);
        using HttpResponseMessage validMac = await client.SendAsync(signed);
        Require(validMac.StatusCode == HttpStatusCode.BadRequest,
            route.Path + ": a valid signature did not reach payload validation.");
        using HttpRequestMessage stale = CreateSigned(route, malformed, key, now - ExpiredSignatureSeconds);
        using HttpResponseMessage expired = await client.SendAsync(stale);
        Require(expired.StatusCode == HttpStatusCode.Unauthorized,
            route.Path + ": an expired signature reached payload authority.");
        using HttpRequestMessage wrongDomain = CreateSigned(route with { Domain = "wrong-domain/" },
            malformed, key, now);
        using HttpResponseMessage mismatch = await client.SendAsync(wrongDomain);
        Require(mismatch.StatusCode == HttpStatusCode.Unauthorized,
            route.Path + ": a different MAC domain reached payload authority.");
        return 6;
    }

    private static async Task<int> CheckAcceptedReplayAsync(HttpClient client, byte[] key,
        IMongoCollection<BsonDocument> results)
    {
        string matchId = "http-proof-" + Guid.NewGuid().ToString("N");
        string revision = new('a', 64);
        var weapon = new WeaponManifest("http-boundary-fixture", 2, 3, 0.1, 0.2);
        var manifest = new MatchManifest(matchId, "local-1", "fixture-map", revision, revision,
            MatchManifest.PrototypeMode, 10, 60, 10,
            new[] { "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb" }
                .Select(id => new ParticipantManifest(id, weapon)).ToArray());
        byte[] payload = AtomicTerminalAcceptanceTests.FinishBattle(manifest);
        byte[] body = JsonSerializer.SerializeToUtf8Bytes(new
        {
            serverId = manifest.ServerId,
            matchId,
            digest = TerminalResultDigest.Compute(payload),
            snapshot = Convert.ToBase64String(payload)
        });
        foreach (string expected in new[] { "accepted", "already-accepted" })
        {
            using HttpRequestMessage request = CreateSigned(Routes[0], body, key,
                DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            using HttpResponseMessage response = await client.SendAsync(request);
            using JsonDocument json = JsonDocument.Parse(await response.Content.ReadAsByteArrayAsync());
            Require(response.StatusCode == HttpStatusCode.OK &&
                json.RootElement.GetProperty("code").GetString() == expected,
                "Signed terminal acceptance/replay changed its response.");
        }
        BsonDocument stored = await results.Find(new BsonDocument("MatchId", matchId)).SingleAsync();
        Require(stored["Snapshot"].AsByteArray.AsSpan().SequenceEqual(payload) &&
            !stored["Settled"].AsBoolean,
            "Accepted terminal bytes changed or unscored evidence became settled.");
        return 3;
    }

    private static async Task<HttpResponseMessage> SendOversizeAsync(HttpClient client,
        HttpRequestMessage request, Route route, bool chunked)
    {
        try
        {
            return await client.SendAsync(request);
        }
        catch (HttpRequestException failure)
        {
            throw new InvalidOperationException(
                $"Oversize response failed for {route.Path}, chunked={chunked}.", failure);
        }
    }

    private static HttpRequestMessage CreateSigned(Route route, byte[] body, byte[] key, long timestamp)
    {
        string stamp = timestamp.ToString(System.Globalization.CultureInfo.InvariantCulture);
        byte[] prefix = Encoding.UTF8.GetBytes(route.Domain + stamp + "\n");
        byte[] signed = new byte[prefix.Length + body.Length];
        prefix.CopyTo(signed, 0);
        body.CopyTo(signed, prefix.Length);
        var request = new HttpRequestMessage(HttpMethod.Post, route.Path)
        {
            Content = new ByteArrayContent(body)
        };
        request.Headers.Add("X-War-Control-Time", stamp);
        request.Headers.Add("X-War-Control-Mac", Convert.ToHexString(HMACSHA256.HashData(key, signed)));
        return request;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private sealed record Route(string Path, string Domain, int MaximumBytes);
}
