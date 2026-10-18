using System.Numerics;
using War.BattleServer;
using War.Client;
using War.Protocol;
using War.Shared;

/// <summary>Checks two signed SDK peers observing mixed grenade commands and reliable lifecycle events.</summary>
internal static class MixedGrenadeUdpTests
{
    private const int TimeoutSeconds = 30;
    private const int PollMilliseconds = 35;
    private const int GrenadeSlot = 2;
    private const int RifleSlot = 0;
    private const int MaximumEventPages = 16;
    private const ulong FirstSession = 9911;
    private const ulong SecondSession = 9912;
    private const float SwipeLength = 7;
    private const float HeldSeconds = 0.05f;

    internal static async Task<int> RunAsync(string directory)
    {
        await using var fixture = new MixedBattleUdpFixture(directory);
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(TimeoutSeconds));
        await fixture.StartAsync(deadline.Token);
        using MatchConnection first = fixture.CreateConnection(fixture.Manifest.Players[0].PlayerId, FirstSession);
        using MatchConnection second = fixture.CreateConnection(fixture.Manifest.Players[1].PlayerId, SecondSession);
        int checks = Require((await first.ConnectAsync(deadline.Token)).Code == "admitted" &&
            (await second.ConnectAsync(deadline.Token)).Code == "admitted",
            "Both signed mixed peers must be admitted.");
        checks += await RejectForgedLanesAsync(first, fixture.Manifest.Allocations![0], deadline.Token);
        checks += await SelectLanesAsync(first, fixture.Manifest.Allocations![0], deadline.Token);
        checks += await SelectLanesAsync(second, fixture.Manifest.Allocations![1], deadline.Token);
        await first.ReadyAsync(deadline.Token);
        await second.ReadyAsync(deadline.Token);
        await ObserveAsync(first, snapshot => snapshot.Phase == BattlePhase.Running, deadline.Token);
        checks += await CheckThrowAsync(fixture, first, second, deadline.Token);
        checks += await CheckEventsAsync(first, second, fixture.Manifest.Players[0].PlayerId, deadline.Token);
        Console.WriteLine("Mixed grenade UDP artifacts: " + fixture.RunDirectory);
        return checks;
    }

    private static async Task<int> RejectForgedLanesAsync(MatchConnection peer, BattleAllocationProjection allocation,
        CancellationToken cancellationToken)
    {
        int[] claimed = allocation.NormalUpgradeIndexes.ToArray();
        claimed[0]++;
        MatchReply rejected = await peer.SelectCardsAsync([], claimed, allocation.SpecialUpgradeIndexes,
            allocation.EliteUpgradeIndexes, [], cancellationToken);
        return Require(rejected.Code == "invalid-card-selection" &&
            !rejected.Snapshot.Players.Single(player => player.PlayerId == allocation.PlayerId).CardsSelected,
            "An authenticated peer promoted an unowned unit stage or consumed selection through a rejected assertion.");
    }

    private static async Task<int> SelectLanesAsync(MatchConnection peer, BattleAllocationProjection allocation,
        CancellationToken cancellationToken)
    {
        MatchReply reply = await peer.SelectCardsAsync([], allocation.NormalUpgradeIndexes,
            allocation.SpecialUpgradeIndexes, allocation.EliteUpgradeIndexes, [], cancellationToken);
        return Require(reply.Code == "cards-selected" && reply.Snapshot.Players.Single(player =>
            player.PlayerId == allocation.PlayerId).NormalUpgradeIndexes.SequenceEqual(allocation.NormalUpgradeIndexes),
            "The signed starter upgrade lanes did not survive SDK/UDP selection.");
    }

    private static async Task<int> CheckThrowAsync(MixedBattleUdpFixture fixture, MatchConnection first,
        MatchConnection second, CancellationToken cancellationToken)
    {
        string owner = fixture.Manifest.Players[0].PlayerId;
        MatchReply before = await first.PollAsync(cancellationToken);
        int rifleAmmo = before.Snapshot.Players.Single(player => player.PlayerId == owner).ClipAmmo;
        MatchReply selection = await first.SwitchWeaponAsync(GrenadeSlot, cancellationToken);
        int checks = Require(selection.Code == "weapon-selected", "The mixed UDP Worker rejected the FRAG slot.");
        MatchSnapshot peerSelection = await ObserveAsync(second, snapshot => snapshot.Players.Single(player =>
            player.PlayerId == owner).ActiveWeaponSlot == GrenadeSlot, cancellationToken);
        checks += Require(peerSelection.Players.Single(player => player.PlayerId == owner).RiflePose.Layers[0].Clip ==
            RiflePoseClip.GrenadeIdle, "The other UDP peer did not observe the active grenade pose.");
        int grenadeAmmo = peerSelection.Players.Single(player => player.PlayerId == owner).ClipAmmo;
        var map = fixture.Content.Maps.Single(candidate => candidate.SourceHash == fixture.Manifest.MapRevision);
        Vector3 start = map.Covers[fixture.Manifest.Players[0].StartCover].Position;
        Vector3 direction = map.Covers[fixture.Manifest.Players[1].StartCover].Position - start;
        direction.Y = 0;
        Vector3 end = start + Vector3.Normalize(direction) * SwipeLength;
        MatchReply thrown = await first.GrenadeSwipeThrowAsync(start.X, start.Y, start.Z,
            end.X, end.Y, end.Z, HeldSeconds, cancellationToken);
        checks += Require(thrown.Code == "grenade-throwing", "The mixed UDP Worker rejected the source swipe.");
        await ObserveAsync(first, snapshot => snapshot.Players.Single(player =>
            player.PlayerId == owner).ShotsFired == 1,
            cancellationToken);
        MatchSnapshot peerFlight = await ObserveAsync(second, snapshot => snapshot.Projectiles.Any(projectile =>
            projectile.OwnerPlayerId == owner && projectile.Kind == "grenade"), cancellationToken);
        checks += Require(peerFlight.Players.Single(player => player.PlayerId == owner).ClipAmmo == grenadeAmmo - 1,
            "The peer did not observe exactly one active-slot grenade debit.");
        checks += Require((await first.SwitchWeaponAsync(RifleSlot, cancellationToken)).Code == "weapon-selected",
            "The mixed UDP owner could not return to rifle with a grenade in flight.");
        MatchSnapshot returned = await ObserveAsync(second, snapshot => snapshot.Players.Single(player =>
            player.PlayerId == owner).ActiveWeaponSlot == RifleSlot && snapshot.Projectiles.Count == 0,
            cancellationToken);
        checks += Require(returned.Phase == BattlePhase.Running && returned.MatchId == fixture.Manifest.MatchId &&
            returned.ManifestHash == fixture.Manifest.Digest() &&
            returned.Players.Single(player => player.PlayerId == owner).ClipAmmo == rifleAmmo,
            "The peer lost the signed match, running phase or inactive rifle ammunition after grenade impact.");
        MatchReply ownerReply = await first.PollAsync(cancellationToken);
        BattlePlayerState ownerView = ownerReply.Snapshot.Players.Single(player => player.PlayerId == owner);
        BattlePlayerState peerView = returned.Players.Single(player => player.PlayerId == owner);
        // Peers poll different ticks; compare settled inventory fields instead of unrelated animation clocks.
        checks += Require(ownerReply.Snapshot.ManifestHash == returned.ManifestHash &&
            ownerView.ActiveWeaponSlot == peerView.ActiveWeaponSlot && ownerView.ClipAmmo == peerView.ClipAmmo &&
            ownerView.ShotsFired == peerView.ShotsFired && ownerView.ShotsFired == 1,
            "The two SDK peers disagree about the settled weapon, ammunition or shot count.");
        return checks;
    }

    private static async Task<int> CheckEventsAsync(MatchConnection first, MatchConnection second, string owner,
        CancellationToken cancellationToken)
    {
        List<MatchEvent> firstEvents = await ReadEventsAsync(first, cancellationToken);
        List<MatchEvent> secondEvents = await ReadEventsAsync(second, cancellationToken);
        MatchEvent shot = firstEvents.Single(item => item.ActorId == owner && item.Kind == MatchEventKind.Shot);
        MatchEvent impact = firstEvents.Single(item => item.ActorId == owner && item.Kind == MatchEventKind.Impact);
        return Require(firstEvents.SequenceEqual(secondEvents) && shot.ProjectileId > 0 &&
            shot.ProjectileId == impact.ProjectileId && shot.EventId < impact.EventId,
            "Two mixed UDP peers did not replay the same ordered grenade shot and impact.");
    }

    private static async Task<List<MatchEvent>> ReadEventsAsync(MatchConnection peer,
        CancellationToken cancellationToken)
    {
        var events = new List<MatchEvent>();
        ulong cursor = 0;
        for (int page = 0; page < MaximumEventPages; page++)
        {
            MatchEventBatch batch = await peer.PollEventsAsync(cursor, cancellationToken);
            Require(batch.Code == "events", "The reliable mixed event cursor was rejected.");
            if (batch.Events.Count == 0)
            {
                return events;
            }
            events.AddRange(batch.Events);
            cursor = batch.Events[^1].EventId;
        }
        throw new InvalidDataException("The mixed event drain exceeded its bounded test history.");
    }

    private static async Task<MatchSnapshot> ObserveAsync(MatchConnection peer, Func<MatchSnapshot, bool> expected,
        CancellationToken cancellationToken)
    {
        while (true)
        {
            MatchReply reply = await peer.PollAsync(cancellationToken);
            Require(reply.Code == "state", "The signed mixed snapshot request failed.");
            if (expected(reply.Snapshot))
            {
                return reply.Snapshot;
            }
            await Task.Delay(PollMilliseconds, cancellationToken);
        }
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
        return 1;
    }
}
