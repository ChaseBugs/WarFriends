using War.Client;
using War.Persistence;
using War.Protocol;

/// <summary>Plays a real UDP round and its authenticated same-opponent rematch through native services.</summary>
internal static class LiveSameOpponentRematchChecks
{
    private const int PollDelayMilliseconds = 100;
    private const int SearchTimeoutSeconds = 25;

    internal static async Task RunAsync(Settings settings, Stores stores, CancellationToken cancellationToken)
    {
        using var backend = new BackendClient(settings.Endpoint, true);
        MatchConnectionGrant[] original = await Task.WhenAll(settings.Tokens.Select(token =>
            backend.FindMatchAsync(token, TimeSpan.FromSeconds(SearchTimeoutSeconds), cancellationToken)));
        await FinishRoundAsync(original, cancellationToken);
        string oldDigest = await WaitForAcceptedAsync(stores, original[0], cancellationToken);
        await backend.AcceptRematchAsync(original[0].MatchId, settings.Tokens[0], cancellationToken);
        await RequireSecondConsentAsync(backend, settings, original[0].MatchId, cancellationToken);
        await backend.AcceptRematchAsync(original[0].MatchId, settings.Tokens[1], cancellationToken);
        MatchQueueReply[] allocation = await Task.WhenAll(settings.Tokens.Select(token =>
            backend.AllocateRematchAsync(original[0].MatchId, token, cancellationToken)));
        Require(allocation.All(reply => reply.Code == "paired" && reply.MatchId == allocation[0].MatchId) &&
            allocation[0].MatchId != original[0].MatchId, "Concurrent rematch requests did not share a fresh match.");
        MatchConnectionGrant[] next = await Task.WhenAll(settings.Tokens.Select(token =>
            backend.MatchGrantAsync(allocation[0].MatchId, token, cancellationToken)));
        for (int index = 0; index < next.Length; index++)
        {
            Require(next[index].PlayerId == original[index].PlayerId &&
                next[index].SessionId != original[index].SessionId && next[index].Ticket != original[index].Ticket &&
                !next[index].SessionKey.Equals(original[index].SessionKey), "Rematch reused an old capability.");
        }
        await VerifyFrozenSourceAsync(stores.Snapshots, original[0], next[0], cancellationToken);
        var replay = await backend.AllocateRematchAsync(original[0].MatchId, settings.Tokens[0], cancellationToken);
        var grantReplay = await backend.MatchGrantAsync(replay.MatchId, settings.Tokens[0], cancellationToken);
        Require(grantReplay.Equals(next[0]), "Provisioning replay changed the delivered capability.");
        await FinishRoundAsync(next, cancellationToken);
        await WaitForAcceptedAsync(stores, next[0], cancellationToken);
        var completed = await backend.AllocateRematchAsync(original[0].MatchId, settings.Tokens[0], cancellationToken);
        Require(completed.Code == "completed" && completed.MatchId == next[0].MatchId &&
            (await stores.Results.Get(original[0].MatchId, cancellationToken))?.Digest == oldDigest,
            "Completed rematch retry reopened a round or changed the original result.");
        Console.WriteLine("PASS: real same-opponent rematch allocation, " +
            "fresh UDP grants, stable replay and accepted results");
    }

    private static async Task RequireSecondConsentAsync(BackendClient backend, Settings settings,
        string matchId, CancellationToken cancellationToken)
    {
        try
        {
            await backend.AllocateRematchAsync(matchId, settings.Tokens[0], cancellationToken);
        }
        catch (HttpRequestException exception) when (exception.Message.Contains("Backend status 409"))
        {
            return;
        }
        throw new InvalidDataException("One participant allocated a match without the opponent's consent.");
    }

    private static async Task FinishRoundAsync(MatchConnectionGrant[] grants, CancellationToken cancellationToken)
    {
        using var first = new MatchConnection(grants[0]);
        using var second = new MatchConnection(grants[1]);
        Require((await first.ConnectAsync(cancellationToken)).Code == "admitted" &&
            (await second.ConnectAsync(cancellationToken)).Code == "admitted", "UDP admission failed.");
        await first.ReadyAsync(cancellationToken);
        await second.ReadyAsync(cancellationToken);
        MatchReply observed;
        do
        {
            await Task.Delay(PollDelayMilliseconds, cancellationToken);
            observed = await first.PollAsync(cancellationToken);
        } while (observed.Snapshot.Phase != BattlePhase.Running);
        Require((await second.ForfeitAsync(cancellationToken)).Snapshot.Phase == BattlePhase.Ended,
            "The rematch Worker did not produce terminal evidence.");
    }

    private static async Task<string> WaitForAcceptedAsync(
        Stores stores, MatchConnectionGrant grant, CancellationToken cancellationToken)
    {
        while (true)
        {
            var result = await stores.Results.Get(grant.MatchId, cancellationToken);
            if (result != null &&
                await stores.Queue.Existing(grant.PlayerViews[0].PlayerId, cancellationToken) == null &&
                await stores.Queue.Existing(grant.PlayerViews[1].PlayerId, cancellationToken) == null)
            {
                Require(War.BattleServer.TerminalOutbox.ValidatePayload(result.Snapshot, result.MatchId, result.Digest)
                    .ManifestHash == grant.ManifestHash,
                    "Accepted rematch evidence lost its admitted manifest binding.");
                return result.Digest;
            }
            await Task.Delay(PollDelayMilliseconds, cancellationToken);
        }
    }

    private static async Task VerifyFrozenSourceAsync(BattleManifestSnapshotStore snapshots,
        MatchConnectionGrant original, MatchConnectionGrant next, CancellationToken cancellationToken)
    {
        string[] players = original.PlayerViews.Select(player => player.PlayerId).ToArray();
        byte[] source = await snapshots.Get(original.MatchId, players, cancellationToken)
            ?? throw new InvalidDataException("The original admission manifest is missing.");
        byte[] frozen = await snapshots.Get(next.MatchId, players, cancellationToken)
            ?? throw new InvalidDataException("The new ordered admission manifest is missing.");
        var previous = War.BattleServer.MatchManifest.Parse(source);
        var generated = War.BattleServer.MatchManifest.Parse(frozen);
        Require(generated.MapId == previous.MapId && generated.Mode == previous.Mode &&
            generated.Players.Select(player => player.Fraction).SequenceEqual(
                previous.Players.Select(player => player.Fraction)) && generated.Digest() == next.ManifestHash,
            "The admitted rematch lost source placement or frozen manifest binding.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }

    internal sealed record Settings(Uri Endpoint, string[] Tokens);

    internal sealed record Stores(BattleResultStore Results, BattleMatchQueueStore Queue,
        BattleManifestSnapshotStore Snapshots);
}
