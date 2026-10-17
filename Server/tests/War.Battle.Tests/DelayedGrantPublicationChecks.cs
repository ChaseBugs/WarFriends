using System.Text.Json;
using System.Text.Json.Nodes;
using War.Backend;
using War.Infrastructure;
using War.Persistence;

/// <summary>Holds a real Worker registration reply while Backend cancellation accepts its terminal result.</summary>
internal static class DelayedGrantPublicationChecks
{
    internal static async Task RunAsync(
        ScopedQueueLiveChecks.Scenario scenario,
        UnpreparedPairCancellationChecks.Stores stores,
        BattleQueueAttemptIdentity[] attempts,
        Settings settings)
    {
        const string CompatibilityKey = "delayed-publication.fixture";
        var now = DateTimeOffset.UtcNow;
        await stores.Queue.JoinAttemptAsync(attempts[0], CompatibilityKey, now, scenario.CancellationToken);
        var pair = await stores.Queue.JoinAttemptAsync(attempts[1], CompatibilityKey, now, scenario.CancellationToken);
        var root = JsonNode.Parse(settings.ManifestTemplate)!.AsObject();
        root["MatchId"] = pair.MatchId;
        byte[] frozen = JsonSerializer.SerializeToUtf8Bytes(root);
        await stores.Manifests.GetOrCreate(pair.MatchId!, pair.Players!, () => Task.FromResult(frozen),
            scenario.CancellationToken);
        using var handler = new HeldRegistrationHandler();
        using var http = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(5) };
        var provisioner = new BattleMatchProvisioner(new BattleMatchControlClient(http, settings.ControlKey),
            stores.Grants, settings.Endpoint);
        var provision = provisioner.Provision(frozen, scenario.CancellationToken);
        await handler.Registered.Task.WaitAsync(scenario.CancellationToken);
        var cancelled = await scenario.Left.CancelMatchQueueAsync(
            scenario.AccessTokens[0], settings.AttemptToken, scenario.CancellationToken);
        if (cancelled.Code != "cancelled")
        {
            throw new Exception("Delayed publication fixture could not cancel its registered Worker match.");
        }

        handler.Release.TrySetResult(true);
        string code = await provision;
        var grant = await stores.Grants.GetForPlayer(pair.MatchId!, attempts[0].PlayerId,
            DateTimeOffset.UtcNow.ToUnixTimeSeconds(), scenario.CancellationToken);
        if (code != "cancelled" || grant != null)
        {
            throw new Exception("A delayed registration response published a grant after accepted cancellation.");
        }

        await VerifyTerminalReplayAsync(stores, pair.MatchId!, scenario.CancellationToken);
        Console.WriteLine("PASS: delayed real Worker registration cannot publish a cancelled pair's grant");
    }

    private static async Task VerifyTerminalReplayAsync(
        UnpreparedPairCancellationChecks.Stores stores, string matchId, CancellationToken cancellationToken)
    {
        var result = await stores.Results.Get(matchId, cancellationToken) ??
            throw new Exception("Cancelled pair has no accepted terminal evidence.");
        var replies = await Task.WhenAll(
            stores.Results.AcceptAndReleasePairAsync(matchId, result.Digest, result.Snapshot, cancellationToken),
            stores.Results.AcceptAndReleasePairAsync(matchId, result.Digest, result.Snapshot, cancellationToken));
        if (replies.Any(reply => reply != "already-accepted") ||
            await stores.Queue.ForMatch(matchId, cancellationToken) != null)
        {
            throw new Exception("Concurrent terminal replay changed the accepted result or recreated its pair.");
        }
    }

    internal sealed class Settings
    {
        internal Settings(byte[] manifestTemplate, byte[] controlKey, Uri endpoint, string attemptToken)
        {
            ManifestTemplate = manifestTemplate;
            ControlKey = controlKey;
            Endpoint = endpoint;
            AttemptToken = attemptToken;
        }

        internal byte[] ManifestTemplate { get; }
        internal byte[] ControlKey { get; }
        internal Uri Endpoint { get; }
        internal string AttemptToken { get; }
    }

    private sealed class HeldRegistrationHandler : DelegatingHandler
    {
        internal HeldRegistrationHandler() : base(new HttpClientHandler()) { }

        internal TaskCompletionSource<bool> Registered { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        internal TaskCompletionSource<bool> Release { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            Registered.TrySetResult(true);
            try
            {
                await Release.Task.WaitAsync(cancellationToken);
                return response;
            }
            catch
            {
                response.Dispose();
                throw;
            }
        }
    }
}
