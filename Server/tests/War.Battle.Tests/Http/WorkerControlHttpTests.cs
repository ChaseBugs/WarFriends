using System.Net;
using System.Security.Cryptography;
using System.Text;
using War.BattleServer.Transport.Control;

namespace War.Battle.Tests.Http;

internal static class WorkerControlHttpTests
{
    private static readonly Route[] Routes =
    [
        new("/internal/matches", WorkerControlPolicy.MatchDomain, WorkerControlPolicy.MaximumBodyBytes),
        new("/internal/matches/reconnect", WorkerControlPolicy.MatchDomain, WorkerControlPolicy.ReconnectBodyBytes),
        new("/internal/matches/cancel", WorkerControlPolicy.MatchDomain, WorkerControlPolicy.CancellationBodyBytes),
        new("/internal/results/poll", WorkerControlPolicy.ResultPollDomain, WorkerControlPolicy.ResultPollBodyBytes),
        new("/internal/results/find", WorkerControlPolicy.ResultFindDomain,
            WorkerControlPolicy.ResultReferenceBodyBytes),
        new("/internal/results/ack", WorkerControlPolicy.ResultAckDomain, WorkerControlPolicy.ResultReferenceBodyBytes)
    ];

    internal static async Task RunAsync(string baseUrl)
    {
        byte[] key = Convert.FromBase64String(Environment.GetEnvironmentVariable("Battle__ControlKey")!);
        using var client = new HttpClient { BaseAddress = new Uri(baseUrl), Timeout = TimeSpan.FromSeconds(10) };
        string outbox = Environment.GetEnvironmentVariable("Battle__ResultOutboxPath")!;
        int priorRecords = Directory.EnumerateFiles(outbox, "*.wfr", SearchOption.AllDirectories).Count();
        foreach (Route route in Routes)
        {
            await CheckRouteAsync(client, key, route);
        }
        Require(Directory.EnumerateFiles(outbox, "*.wfr", SearchOption.AllDirectories).Count() == priorRecords,
            "Rejected control requests published terminal records.");
        Console.WriteLine("PASS: 37 native Worker body/MAC/shape/no-terminal-write checks across six routes");
    }

    private static async Task CheckRouteAsync(HttpClient client, byte[] key, Route route)
    {
        foreach (bool chunked in new[] { false, true })
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, route.Path)
            {
                Content = new ByteArrayContent(new byte[route.Limit + 1])
            };
            request.Headers.TransferEncodingChunked = chunked;
            using HttpResponseMessage response = await client.SendAsync(request);
            Require(response.StatusCode == HttpStatusCode.RequestEntityTooLarge,
                route.Path + ": oversized control body did not return 413.");
            Require(response.Headers.ConnectionClose == true,
                route.Path + ": oversized Worker HTTP/1 response kept its connection reusable.");
        }

        using var atLimit = new ByteArrayContent(new byte[route.Limit]);
        using HttpResponseMessage unsigned = await client.PostAsync(route.Path, atLimit);
        Require(unsigned.StatusCode == HttpStatusCode.Unauthorized, route.Path + ": unsigned limit changed.");
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        using HttpRequestMessage malformed = Signed(route, key, now);
        using HttpResponseMessage validMac = await client.SendAsync(malformed);
        HttpStatusCode expected = route.Path.EndsWith("/poll", StringComparison.Ordinal) ?
            HttpStatusCode.OK : HttpStatusCode.BadRequest;
        Require(validMac.StatusCode == expected, route.Path + ": signed shape mapping changed.");
        using HttpRequestMessage stale = Signed(route, key, now - 60);
        using HttpResponseMessage expired = await client.SendAsync(stale);
        Require(expired.StatusCode == HttpStatusCode.Unauthorized, route.Path + ": stale control MAC accepted.");
        using HttpRequestMessage wrongDomain = Signed(route with { Domain = "wrong-domain/" }, key, now);
        using HttpResponseMessage mismatch = await client.SendAsync(wrongDomain);
        Require(mismatch.StatusCode == HttpStatusCode.Unauthorized, route.Path + ": MAC domain changed.");
    }

    private static HttpRequestMessage Signed(Route route, byte[] key, long timestamp)
    {
        string stamp = timestamp.ToString(System.Globalization.CultureInfo.InvariantCulture);
        byte[] body = "{}"u8.ToArray();
        byte[] prefix = Encoding.UTF8.GetBytes(route.Domain + stamp + "\n");
        byte[] payload = prefix.Concat(body).ToArray();
        var request = new HttpRequestMessage(HttpMethod.Post, route.Path)
        {
            Content = new ByteArrayContent(body)
        };
        request.Headers.Add("X-War-Control-Time", stamp);
        request.Headers.Add("X-War-Control-Mac", Convert.ToHexString(HMACSHA256.HashData(key, payload)));
        return request;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private sealed record Route(string Path, string Domain, int Limit);
}
