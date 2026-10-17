using System.Text.Json.Nodes;
using War.BattleServer;
using War.Infrastructure;
using War.Persistence;
using War.Protocol;

/// <summary>Models a Backend crash after pairing but before the manifest or Worker registration exists.</summary>
internal static class UnpreparedPairCancellationChecks
{
    internal static async Task RunAsync(
        ScopedQueueLiveChecks.Scenario scenario,
        string[] playerIds,
        BattleQueueAttemptTokens issuer,
        Stores stores)
    {
        var pending = await CreatePairAsync(scenario, playerIds, issuer, stores.Queue);
        if (await stores.Manifests.Get(
            pending.Pair.MatchId!, pending.Pair.Players!, scenario.CancellationToken) != null)
        {
            throw new Exception("The interrupted allocation fixture unexpectedly has a frozen manifest.");
        }

        await VerifyCancellationAsync(scenario, stores, pending);
        byte[] frozen = await stores.Manifests.Get(
            pending.Pair.MatchId!, pending.Pair.Players!, scenario.CancellationToken) ??
            throw new Exception("Recovered cancellation did not freeze source-backed settings.");
        var unregistered = await CreatePairAsync(scenario, playerIds, issuer, stores.Queue);
        var settings = JsonNode.Parse(frozen)!.AsObject();
        settings["MatchId"] = unregistered.Pair.MatchId;
        byte[] expected = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(settings);
        await stores.Manifests.GetOrCreate(unregistered.Pair.MatchId!, unregistered.Pair.Players!,
            () => Task.FromResult(expected), scenario.CancellationToken);
        await VerifyCancellationAsync(scenario, stores, unregistered);
        byte[]? retained = await stores.Manifests.Get(
            unregistered.Pair.MatchId!, unregistered.Pair.Players!, scenario.CancellationToken);
        if (retained == null || !retained.SequenceEqual(expected))
        {
            throw new Exception("Registration recovery changed an already frozen manifest.");
        }

        Console.WriteLine(
            "PASS: missing-manifest and unregistered frozen pairs cancel with Worker proof and no grants");
    }

    private static async Task<PendingPair> CreatePairAsync(
        ScopedQueueLiveChecks.Scenario scenario,
        string[] playerIds,
        BattleQueueAttemptTokens issuer,
        BattleMatchQueueStore queue)
    {
        var grants = await Task.WhenAll(
            scenario.Left.CreateMatchQueueAttemptAsync(scenario.AccessTokens[0], scenario.CancellationToken),
            scenario.Right.CreateMatchQueueAttemptAsync(scenario.AccessTokens[1], scenario.CancellationToken));
        var now = DateTimeOffset.UtcNow;
        var left = issuer.ValidateForJoin(grants[0].Token, playerIds[0], now.ToUnixTimeSeconds());
        var right = issuer.ValidateForJoin(grants[1].Token, playerIds[1], now.ToUnixTimeSeconds());
        const string CompatibilityKey = "unprepared-cancellation.fixture";
        await queue.JoinAttemptAsync(left, CompatibilityKey, now, scenario.CancellationToken);
        var pair = await queue.JoinAttemptAsync(right, CompatibilityKey, now, scenario.CancellationToken);
        if (pair.Code != "paired")
        {
            throw new Exception("Interrupted allocation fixture could not publish its durable pair.");
        }

        return new PendingPair(grants[0].Token, pair);
    }

    private static async Task VerifyCancellationAsync(
        ScopedQueueLiveChecks.Scenario scenario, Stores stores, PendingPair pending)
    {
        var reply = await scenario.Left.CancelMatchQueueAsync(
            scenario.AccessTokens[0], pending.AttemptToken, scenario.CancellationToken);
        var result = await stores.Results.Get(pending.Pair.MatchId!, scenario.CancellationToken);
        if (reply.Code != "cancelled" || result == null)
        {
            throw new Exception("Interrupted pair cancellation did not store terminal evidence before success.");
        }

        var terminal = TerminalOutbox.ValidatePayload(result.Snapshot, pending.Pair.MatchId!, result.Digest);
        byte[] frozen = await stores.Manifests.Get(
            pending.Pair.MatchId!, pending.Pair.Players!, scenario.CancellationToken) ??
            throw new Exception("Cancellation terminal evidence has no frozen manifest.");
        if (MatchManifest.Parse(frozen).Digest() != terminal.ManifestHash)
        {
            throw new Exception("Cancellation evidence differs from its recovered frozen authority.");
        }
        if (terminal.Phase != BattlePhase.Aborted || terminal.TerminalReason != "cancelled-before-start" ||
            terminal.WinnerPlayerId.Length != 0 ||
            !terminal.Players.Select(player => player.PlayerId).SequenceEqual(pending.Pair.Players!))
        {
            throw new Exception("Interrupted pair cancellation fabricated a scored or foreign terminal result.");
        }

        foreach (string playerId in pending.Pair.Players!)
        {
            if (await stores.Grants.GetForPlayer(pending.Pair.MatchId!, playerId,
                DateTimeOffset.UtcNow.ToUnixTimeSeconds(), scenario.CancellationToken) != null)
            {
                throw new Exception("Cancellation preparation published a deliverable player grant.");
            }

            if (await stores.Queue.Existing(playerId, scenario.CancellationToken) != null)
            {
                throw new Exception("Interrupted pair cancellation left a roster member allocated.");
            }
        }
    }

    internal sealed class Stores
    {
        internal Stores(
            BattleMatchQueueStore queue,
            BattleManifestSnapshotStore manifests,
            BattleResultStore results,
            BattleGrantStore grants)
        {
            Queue = queue;
            Manifests = manifests;
            Results = results;
            Grants = grants;
        }

        internal BattleMatchQueueStore Queue { get; }
        internal BattleManifestSnapshotStore Manifests { get; }
        internal BattleResultStore Results { get; }
        internal BattleGrantStore Grants { get; }
    }

    private sealed class PendingPair
    {
        internal PendingPair(string attemptToken, BattlePairingResult pair)
        {
            AttemptToken = attemptToken;
            Pair = pair;
        }

        internal string AttemptToken { get; }
        internal BattlePairingResult Pair { get; }
    }
}
