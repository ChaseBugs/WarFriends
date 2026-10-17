using System.Net;
using System.Net.Http.Headers;
using Google.Protobuf;
using War.Client;
using War.Protocol;

/// <summary>Exercises authenticated protobuf consent through the actual Backend process.</summary>
internal static class LiveRematchConsentChecks
{
    internal static async Task RunAsync(Settings settings, CancellationToken cancellationToken)
    {
        using var backend = new BackendClient(settings.Endpoint, true);
        var before = await backend.ReadRematchConsentAsync(settings.MatchId, settings.Tokens[0], cancellationToken);
        Require(before.Status == "not-requested" && before.Revision == 0 && before.AcceptedPlayerIds.Count == 0,
            "Reading consent must not create intent or start a deadline.");
        var first = await backend.AcceptRematchAsync(settings.MatchId, settings.Tokens[0], cancellationToken);
        var observed = await backend.ReadRematchConsentAsync(settings.MatchId, settings.Tokens[1], cancellationToken);
        Require(first.Status == "waiting" && observed.Equals(first), "The other participant must see one consent.");
        var replay = await backend.AcceptRematchAsync(settings.MatchId, settings.Tokens[0], cancellationToken);
        Require(replay.Equals(first), "HTTP retries must not renew the consent window.");
        var ready = await backend.AcceptRematchAsync(settings.MatchId, settings.Tokens[1], cancellationToken);
        Require(ready.Status == "ready" && ready.AcceptedPlayerIds.Count == 2 &&
            ready.ExpiresUnixMilliseconds == first.ExpiresUnixMilliseconds,
            "Only the second participant can complete the unchanged consent window.");
        var cancelled = await backend.CancelRematchAsync(settings.MatchId, settings.Tokens[0], cancellationToken);
        var denied = await backend.AcceptRematchAsync(settings.MatchId, settings.Tokens[1], cancellationToken);
        Require(cancelled.Status == "cancelled" && denied.Equals(cancelled), "Late acceptance reopened cancellation.");
        await VerifyRequestBoundaryAsync(backend, settings, cancellationToken);
        Console.WriteLine("PASS: authenticated protobuf rematch SDK read/accept/cancel, replay and request boundaries");
    }

    private static async Task VerifyRequestBoundaryAsync(
        BackendClient backend, Settings settings, CancellationToken cancellationToken)
    {
        using var http = new HttpClient { BaseAddress = settings.Endpoint };
        byte[] valid = new MatchGrantRequest { MatchId = settings.MatchId }.ToByteArray();
        await ExpectAsync(http, new Request("invalid", valid, HttpStatusCode.Unauthorized), cancellationToken);
        await ExpectAsync(http, new Request(settings.Tokens[0],
            new MatchGrantRequest { MatchId = "invalid" }.ToByteArray(), HttpStatusCode.BadRequest), cancellationToken);
        await ExpectAsync(http, new Request(settings.Tokens[0],
            valid.Concat(new byte[] { 16, 1 }).ToArray(), HttpStatusCode.BadRequest), cancellationToken);
        var outsider = await backend.RegisterAsync(new RegisterRequest
        {
            Username = "outside" + Guid.NewGuid().ToString("N")[..8],
            Password = "ConsentFixturePassword42!",
            Locale = "en",
        }, cancellationToken);
        await ExpectAsync(http, new Request(outsider.AccessToken, valid, HttpStatusCode.Conflict), cancellationToken);
    }

    private static async Task ExpectAsync(HttpClient http, Request fixture, CancellationToken cancellationToken)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "v1/battle/rematch/accept");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", fixture.Token);
        request.Content = new ByteArrayContent(fixture.Body);
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-protobuf");
        using HttpResponseMessage response = await http.SendAsync(request, cancellationToken);
        Require(response.StatusCode == fixture.ExpectedStatus, "Unexpected rematch request boundary response.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }

    internal sealed record Settings(Uri Endpoint, string[] Tokens, string MatchId);

    private sealed record Request(string Token, byte[] Body, HttpStatusCode ExpectedStatus);
}
