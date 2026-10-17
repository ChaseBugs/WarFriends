using MongoDB.Driver;
using War.BattleServer;
using War.Client;
using War.Persistence;

/// <summary>Stops the real Worker after consent and verifies retry uses the committed admission snapshot.</summary>
internal static class LiveRematchProvisionRecoveryChecks
{
    internal static async Task RunAsync(Scenario scenario, CancellationToken cancellationToken)
    {
        var hooks = scenario.Settings.WorkerRecovery
            ?? throw new InvalidDataException("Owned Worker recovery hooks are missing.");
        hooks.Stop();
        try
        {
            FrozenReservation frozen = await CaptureDeferredAsync(scenario, cancellationToken);
            await VerifyFrozenRetryAsync(scenario, frozen, cancellationToken);
            Console.WriteLine("PASS: real rematch Worker outage retains reservation " +
                "and replays frozen profile authority");
        }
        finally
        {
            // The hook checks its owned process, so restoration is safe after both success and failure.
            await hooks.RestartAsync();
        }
    }

    private static async Task<FrozenReservation> CaptureDeferredAsync(
        Scenario scenario, CancellationToken cancellationToken)
    {
        try
        {
            await scenario.Backend.AllocateRematchAsync(
                scenario.SourceMatchId, scenario.Settings.Tokens[0], cancellationToken);
            throw new InvalidDataException("An offline Worker must not deliver a paired rematch.");
        }
        catch (HttpRequestException exception) when (
            exception.Message.Contains("Backend status 503", StringComparison.Ordinal) &&
            exception.Message.Contains("rematch_provision_deferred", StringComparison.Ordinal))
        {
            // The accepted failure is checked against durable reservation and grant authority below.
        }
        var consent = await scenario.Backend.ReadRematchConsentAsync(
            scenario.SourceMatchId, scenario.Settings.Tokens[0], cancellationToken);
        Require(consent.Status == "allocated" && consent.NextMatchId != scenario.SourceMatchId,
            "Worker outage must retain one fresh committed reservation.");
        byte[] bytes = await scenario.Stores.Snapshots.GetForParticipantsAsync(
            consent.NextMatchId, consent.AcceptedPlayerIds.ToArray(), cancellationToken)
            ?? throw new InvalidDataException("Deferred rematch lost its frozen admission payload.");
        MatchManifest manifest = MatchManifest.Parse(bytes);
        foreach (var player in manifest.Players)
        {
            var pair = await scenario.Stores.Queue.Existing(player.PlayerId, cancellationToken);
            Require(pair?.MatchId == manifest.MatchId,
                "Deferred registration must not release either participant.");
        }
        Require(await scenario.Stores.Results.Get(manifest.MatchId, cancellationToken) == null,
            "A Worker outage must not fabricate a terminal result.");
        await RequireNoGrantAsync(scenario, manifest.MatchId, cancellationToken);
        return new FrozenReservation(manifest, bytes);
    }

    private static async Task VerifyFrozenRetryAsync(
        Scenario scenario, FrozenReservation frozen, CancellationToken cancellationToken)
    {
        var hooks = scenario.Settings.WorkerRecovery
            ?? throw new InvalidDataException("Owned Worker recovery hooks are missing.");
        var profiles = scenario.Stores.Database.GetCollection<LegacyPlayerDocument>("legacyPlayers");
        string playerId = frozen.Manifest.Players[0].PlayerId;
        var profile = await profiles.Find(player => player.Id == playerId).SingleAsync(cancellationToken);
        const string ChangedDisplayName = "ChangedAfterReservation";
        Require(profile.Name != ChangedDisplayName, "Recovery fixture requires a distinct profile change.");
        UpdateResult changed = await profiles.UpdateOneAsync(player => player.Id == playerId,
            Builders<LegacyPlayerDocument>.Update.Set(player => player.Name, ChangedDisplayName),
            cancellationToken: cancellationToken);
        try
        {
            Require(changed.ModifiedCount == 1, "Recovery fixture did not change the durable profile.");
            await hooks.RestartAsync();
            var allocated = await scenario.Backend.AllocateRematchAsync(
                scenario.SourceMatchId, scenario.Settings.Tokens[0], cancellationToken);
            Require(allocated.Code == "paired" && allocated.MatchId == frozen.Manifest.MatchId,
                "Recovery must provision the original reserved identity.");
            var grant = await scenario.Backend.MatchGrantAsync(
                allocated.MatchId, scenario.Settings.Tokens[0], cancellationToken);
            string frozenName = frozen.Manifest.Presentations?[0].DisplayName
                ?? throw new InvalidDataException("Frozen admission profile is missing.");
            Require(grant.ManifestHash == frozen.Manifest.Digest() &&
                grant.PlayerViews.Single(player => player.PlayerId == playerId).DisplayName == frozenName &&
                frozenName != ChangedDisplayName, "Retry rebuilt admission authority from changed profile state.");
            byte[] replay = await scenario.Stores.Snapshots.Get(allocated.MatchId,
                frozen.Manifest.Players.Select(player => player.PlayerId).ToArray(), cancellationToken)
                ?? throw new InvalidDataException("Recovered admission payload is missing.");
            Require(replay.SequenceEqual(frozen.Bytes), "Worker recovery rewrote the frozen admission bytes.");
        }
        finally
        {
            await profiles.UpdateOneAsync(player => player.Id == playerId,
                Builders<LegacyPlayerDocument>.Update.Set(player => player.Name, profile.Name),
                cancellationToken: CancellationToken.None);
        }
    }

    private static async Task RequireNoGrantAsync(
        Scenario scenario, string matchId, CancellationToken cancellationToken)
    {
        try
        {
            await scenario.Backend.MatchGrantAsync(matchId, scenario.Settings.Tokens[0], cancellationToken);
        }
        catch (HttpRequestException exception) when (
            exception.Message.Contains("Backend status 404", StringComparison.Ordinal))
        {
            return;
        }
        throw new InvalidDataException("Deferred Worker registration published a premature connection capability.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }

    internal sealed record Scenario(BackendClient Backend, LiveSameOpponentRematchChecks.Settings Settings,
        LiveSameOpponentRematchChecks.Stores Stores, string SourceMatchId);

    private sealed record FrozenReservation(MatchManifest Manifest, byte[] Bytes);
}
