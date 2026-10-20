using War.Client;
using War.Protocol;

/// <summary>Checks secondary lifetimes through SDK sockets and a fresh reconnect generation.</summary>
internal static class CoopCrewUdpTests
{
    private const ulong FirstSession = 3201;
    private const ulong PeerSession = 3202;
    private const ulong ReconnectSession = 3203;

    internal static async Task Run(CoopObstacleVolleyRuntimeTests.Sources sources, string directory)
    {
        await using var host = new CoopCrewUdpHost(sources, directory);
        string firstId = sources.Manifest.Players[0].PlayerId;
        string peerId = sources.Manifest.Players[1].PlayerId;
        using var peer = new MatchConnection(host.CreateGrant(peerId, PeerSession, 0));
        BattleCoopEnemySpawn expected;
        using (var first = new MatchConnection(host.CreateGrant(firstId, FirstSession, 0)))
        {
            await first.ConnectAsync(host.Token);
            await peer.ConnectAsync(host.Token);
            await first.ReadyAsync(host.Token);
            Require((await peer.ReadyAsync(host.Token)).Snapshot.Coop.Started, "Both SDK clients must start co-op.");
            BattleCoopEnemySpawn aircraft = host.PrepareAircraft();
            await VerifyPairAsync(first, peer, host, aircraft);
            host.ApplyConfirmedDamage(aircraft);
            BattleCoopEnemySpawn damaged = (await peer.PollAsync(host.Token)).Snapshot.Coop.EnemySpawns
                .Single(row => row.EntityId == aircraft.EntityId);
            Require(damaged.CrewActors[0].Health == aircraft.CrewActors[0].Health / 2 &&
                damaged.GunnerHealth == 0 && damaged.GunnerEntityId == aircraft.GunnerEntityId,
                "SDK delivery lost crew health or changed a turret identity before its respawn.");
            host.AdvanceToRespawn(aircraft.EntityId);
            expected = await VerifyPairAsync(first, peer, host, aircraft);
            Require(expected.GunnerEntityId != aircraft.GunnerEntityId && expected.GunnerHealth > 0,
                "SDK clients did not observe a distinct source gunner respawn life.");
        }

        using var resumed = new MatchConnection(host.CreateGrant(firstId, ReconnectSession, 1));
        MatchReply admission = await resumed.ConnectAsync(host.Token);
        Require(admission.Code == "admitted" && admission.Snapshot.Coop.Started,
            "A fresh authenticated generation must resume the running cooperative mission.");
        BattleCoopEnemySpawn afterReconnect = await VerifyPairAsync(resumed, peer, host, expected);
        Require(SameLifetimes(afterReconnect, expected),
            "Reconnect changed secondary identities, crew vitality or the current turret life.");
        Require(host.HasSentTransfer, "Secondary snapshot must exercise real SDK chunk reassembly.");
        Console.WriteLine("PASS: co-op crew SDK UDP health, turret respawn, chunk transfer " +
            "and fresh-generation reconnect");
    }

    private static async Task<BattleCoopEnemySpawn> VerifyPairAsync(MatchConnection first,
        MatchConnection peer, CoopCrewUdpHost host, BattleCoopEnemySpawn original)
    {
        Task<MatchReply> firstPoll = first.PollAsync(host.Token);
        Task<MatchReply> peerPoll = peer.PollAsync(host.Token);
        await Task.WhenAll(firstPoll, peerPoll);
        MatchSnapshot firstState = (await firstPoll).Snapshot;
        MatchSnapshot peerState = (await peerPoll).Snapshot;
        BattleCoopEnemySpawn firstAircraft = firstState.Coop.EnemySpawns
            .Single(row => row.EntityId == original.EntityId);
        BattleCoopEnemySpawn peerAircraft = peerState.Coop.EnemySpawns.Single(row => row.EntityId == original.EntityId);
        CoopEnemyViewState firstView = CoopEnemyViewProjection.FromSnapshot(firstState, first.LocalPlayerId)
            .Single(row => row.EntityId == original.EntityId);
        CoopEnemyViewState peerView = CoopEnemyViewProjection.FromSnapshot(peerState, peer.LocalPlayerId)
            .Single(row => row.EntityId == original.EntityId);
        Require(SameLifetimes(firstAircraft, peerAircraft) &&
            firstView.CrewActors.Select(actor => actor.EntityId)
                .SequenceEqual(original.CrewActors.Select(actor => actor.EntityId)) &&
            peerView.GunnerEntityId == firstView.GunnerEntityId,
            "Independent SDK sockets disagree on the host's secondary actor roster.");
        return firstAircraft;
    }

    private static bool SameLifetimes(BattleCoopEnemySpawn first, BattleCoopEnemySpawn second)
    {
        return first.CrewActors.SequenceEqual(second.CrewActors) &&
            first.GunnerEntityId == second.GunnerEntityId && first.GunnerHealth == second.GunnerHealth &&
            first.GunnerMaxHealth == second.GunnerMaxHealth && first.GunnerSpawnTick == second.GunnerSpawnTick &&
            first.GunnerRespawnTick == second.GunnerRespawnTick;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
