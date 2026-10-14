using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text.Json;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using War.BattleServer;
using War.Client;
using War.Protocol;

internal static class LiveGrenadesBurstUdpTests
{
    internal static async Task<int> Run(string contentDirectory)
    {
        int checks = 0;
        void Check(bool condition, string description)
        {
            if (!condition) throw new Exception(description);
            checks++;
        }

        var content = BattleCombatContent.Load(Path.Combine(contentDirectory,
            "combat-content-manifest.json"));
        var template = MatchManifest.Read(Path.Combine(contentDirectory,
            "local-rifle-match-template.json"));
        var attackerId = template.Players[0].PlayerId;
        var defenderId = template.Players[1].PlayerId;
        var manifest = template with
        {
            MatchId = "cluster-grenade-udp",
            SceneMasterPlayerId = attackerId,
            Players = template.Players.Select(player =>
                player with { PlayerLevel = 22 }).ToArray(),
            Allocations =
            [
                new(attackerId, ["CLUSTERGRENADE", "STREAKBOOST"], [], [0], [-1], [-1]),
                new(defenderId, ["CLUSTERGRENADE", "CRATEBLOCKER"], [], [0], [-1], [-1])
            ]
        };
        content.ValidateAllocation(manifest);

        string manifestFile = Path.Combine(Path.GetTempPath(),
            "war-cluster-grenade-" + Guid.NewGuid().ToString("N") + ".json");
        File.WriteAllText(manifestFile, JsonSerializer.Serialize(manifest));
        using var portProbe = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0));
        int port = ((IPEndPoint)portProbe.Client.LocalEndPoint!).Port;
        portProbe.Close();

        string signingKey = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        var tokens = new MatchTokens(signingKey);
        var configuration = new ConfigurationBuilder().AddInMemoryCollection(
            new Dictionary<string, string?>
            {
                ["Battle:SigningKey"] = signingKey,
                ["Battle:ServerId"] = manifest.ServerId,
                ["Battle:Port"] = port.ToString(),
                ["Battle:MatchManifestPath"] = manifestFile,
                ["Battle:ResultOutboxPath"] = Path.Combine(Path.GetTempPath(),
                    "war-cluster-outbox-" + Guid.NewGuid().ToString("N")),
                ["Battle:CombatContentManifestPath"] = Path.Combine(
                    contentDirectory, "combat-content-manifest.json")
            }).Build();
        using var worker = new NetworkWorker(configuration,
            NullLogger<NetworkWorker>.Instance);

        MatchConnectionGrant Grant(string playerId, ulong sessionId)
        {
            long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var admission = new MatchAdmission
            {
                MatchId = manifest.MatchId,
                ServerId = manifest.ServerId,
                PlayerId = playerId,
                SessionId = sessionId,
                ManifestHash = manifest.Digest(),
                IssuedUnixSeconds = now,
                ExpiresUnixSeconds = now + 120
            };
            return new MatchConnectionGrant
            {
                Host = "127.0.0.1",
                Port = (uint)port,
                PlayerId = playerId,
                SessionId = sessionId,
                MatchId = manifest.MatchId,
                ManifestHash = admission.ManifestHash,
                ExpiresUnixSeconds = admission.ExpiresUnixSeconds,
                Ticket = tokens.Sign(admission),
                SessionKey = ByteString.CopyFrom(tokens.SessionKey(admission))
            };
        }

        try
        {
            await worker.StartAsync(CancellationToken.None);
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(35));
            using var attacker = new MatchConnection(Grant(attackerId, 971));
            using var defender = new MatchConnection(Grant(defenderId, 972));
            Check((await attacker.ConnectAsync(timeout.Token)).Code == "admitted" &&
                  (await defender.ConnectAsync(timeout.Token)).Code == "admitted",
                "both signed clients enter the Cluster Grenade match");

            var attackerCards = await attacker.SelectCardsAsync(
                ["CLUSTERGRENADE", "STREAKBOOST"], [], [], [], [], timeout.Token);
            var defenderCards = await defender.SelectCardsAsync(
                ["CLUSTERGRENADE", "CRATEBLOCKER"], [], [], [], [], timeout.Token);
            Check(attackerCards.Code == "cards-selected" &&
                  defenderCards.Code == "cards-selected",
                "both clients select their Backend-allocated card stock: " +
                attackerCards.Code + ", " + defenderCards.Code);
            await attacker.ReadyAsync(timeout.Token);
            await defender.ReadyAsync(timeout.Token);
            MatchReply state;
            do
            {
                await Task.Delay(100, timeout.Token);
                state = await attacker.PollAsync(timeout.Token);
            }
            while (state.Snapshot.Phase != BattlePhase.Running);

            string boostRequest = new('a', 32);
            string blockRequest = new('b', 32);
            var boost = await attacker.UseScoreMultiplierAsync(boostRequest,
                "STREAKBOOST", timeout.Token);
            var block = await defender.UseScoreMultiplierAsync(blockRequest,
                "CRATEBLOCKER", timeout.Token);
            Check(boost.Code == "score-card-active" &&
                  block.Code == "score-card-active" &&
                  block.Snapshot.CardActivations == 2,
                "two authenticated SDK peers activate their own source score cards");
            var boostReplay = await attacker.UseScoreMultiplierAsync(boostRequest,
                "STREAKBOOST", timeout.Token);
            var boostConflict = await defender.UseScoreMultiplierAsync(boostRequest,
                "STREAKBOOST", timeout.Token);
            Check(boostReplay.Code == "score-card-active" &&
                  boostConflict.Code == "score-card-request-conflict" &&
                  boostConflict.Snapshot.CardActivations == 2,
                "UDP replay and cross-player conflict cannot spend score cards twice");

            float defenderHealth = state.Snapshot.Players[1].Health;
            string requestId = new('c', 32);
            var used = await attacker.UseGrenadesBurstAsync(requestId,
                timeout.Token);
            Check(used.Code == "grenades-burst-active" &&
                  used.Snapshot.CardActivations == 3,
                "signed Cluster Grenade command spends one selected card");
            var replay = await attacker.UseGrenadesBurstAsync(requestId,
                timeout.Token);
            Check(replay.Code == used.Code &&
                  replay.Snapshot.CardActivations == 3,
                "request replay does not spend another card");
            var conflict = await defender.UseGrenadesBurstAsync(requestId,
                timeout.Token);
            Check(conflict.Code == "grenades-burst-request-conflict" &&
                  conflict.Snapshot.CardActivations == 3,
                "the other player cannot claim the same card request");

            IReadOnlyList<MatchEvent> attackerEvents;
            MatchReply attackerState;
            bool sawHostProjectile = false;
            do
            {
                await Task.Delay(100, timeout.Token);
                attackerState = await attacker.PollAsync(timeout.Token);
                sawHostProjectile |= attackerState.Snapshot.Projectiles.Any(row =>
                    row.Kind == "pvp-bonus-grenade" &&
                    row.OwnerPlayerId == attackerId);
                attackerEvents = await ReadEvents(attacker, timeout.Token);
            }
            while (GrenadeEvents(attackerEvents, MatchEventKind.Impact).Length < 3);
            var defenderState = await defender.PollAsync(timeout.Token);
            var defenderEvents = await ReadEvents(defender, timeout.Token);
            var shots = GrenadeEvents(attackerEvents, MatchEventKind.Shot);
            var impacts = GrenadeEvents(attackerEvents, MatchEventKind.Impact);
            Check(shots.Length == 3 && impacts.Length == 3 &&
                  shots.Select(shot => shot.ProjectileId).SequenceEqual(
                      impacts.Select(impact => impact.ProjectileId)),
                "all three host grenade flights publish matching shots and impacts");
            Check(sawHostProjectile,
                "SDK snapshot carries a live host-owned grenade pose for Unity");
            Check(attackerState.Snapshot.Players[1].Health < defenderHealth &&
                  defenderState.Snapshot.Players[1].Health ==
                      attackerState.Snapshot.Players[1].Health,
                "both SDK peers observe the same host-confirmed opponent damage");
            Check(GrenadeEvents(defenderEvents, MatchEventKind.Shot)
                      .SequenceEqual(shots) &&
                  GrenadeEvents(defenderEvents, MatchEventKind.Impact)
                      .SequenceEqual(impacts),
                "both SDK peers replay identical grenade projectile evidence");
        }
        finally
        {
            await worker.StopAsync(CancellationToken.None);
            File.Delete(manifestFile);
        }
        return checks;
    }

    private static MatchEvent[] GrenadeEvents(IReadOnlyList<MatchEvent> events,
        MatchEventKind kind) => events.Where(item => item.Kind == kind &&
            item.Reason == "pvp-bonus-grenade").ToArray();

    private static async Task<IReadOnlyList<MatchEvent>> ReadEvents(
        MatchConnection connection, CancellationToken cancellationToken)
    {
        var events = new List<MatchEvent>();
        ulong cursor = 0;
        while (true)
        {
            var page = await connection.PollEventsAsync(cursor, cancellationToken);
            if (page.Code != "events")
                throw new Exception("Grenade event cursor failed: " + page.Code);
            events.AddRange(page.Events);
            if (page.Events.Count == 0 ||
                page.Events[^1].EventId == page.LatestEventId)
                return events;
            cursor = page.Events[^1].EventId;
        }
    }
}
