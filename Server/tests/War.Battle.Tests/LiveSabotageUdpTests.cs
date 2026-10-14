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

internal static class LiveSabotageUdpTests
{
    internal static async Task<int> Run(string directory)
    {
        string[] mechanicalUnitIds =
        [
            "ID_UNIT-HUMVEE", "ID_UNIT-BUGGY", "ID_UNIT-TRANSPORTER",
            "ID_UNIT-TANK", "ID_UNIT-HELICOPTER", "ID_UNIT-ASSAULTHELI",
            "ID_UNIT-DRONE", "ID_UNIT-MECH"
        ];

        int checks = 0;
        foreach (string unitId in mechanicalUnitIds)
        {
            try
            {
                checks += await VerifyOneUnit(directory, unitId);
            }
            catch (Exception error)
            {
                throw new Exception($"SABOTAGE UDP case failed for {unitId}.", error);
            }
        }
        checks += await VerifyOneUnit(directory, "ID_UNIT-DRONE", cardSpawned: true);
        return checks;
    }

    internal static Task<int> RunCardDrone(string directory,
        Func<TerminalOutbox.Evidence, CancellationToken, Task<int>> verifyBackend,
        Uri? automaticEndpoint = null, byte[]? controlKey = null,
        Func<string, CancellationToken, Task<TerminalOutbox.Evidence?>>? readBackend = null) =>
        VerifyOneUnit(directory, "ID_UNIT-DRONE", true, verifyBackend,
            automaticEndpoint, controlKey, readBackend);

    private static async Task<int> VerifyOneUnit(string directory, string unitId,
        bool cardSpawned = false,
        Func<TerminalOutbox.Evidence, CancellationToken, Task<int>>? verifyBackend = null,
        Uri? automaticEndpoint = null, byte[]? controlKey = null,
        Func<string, CancellationToken, Task<TerminalOutbox.Evidence?>>? readBackend = null)
    {
        int checks = 0;
        void Check(bool condition, string description)
        {
            if (!condition) throw new Exception(description);
            checks++;
        }

        var content = BattleCombatContent.Load(Path.Combine(directory,
            "combat-content-manifest.json"));
        var map = content.Maps.Single(source =>
            source.Source.EndsWith("Park_Multiplayer.unity",
                StringComparison.Ordinal));
        var attackerCover = map.Covers.First(cover =>
            cover.Main && cover.Fraction == 1);
        var defenderCover = map.Covers.First(cover =>
            cover.Main && cover.Fraction == 2);
        var weapon = content.Stats.CreateManifest(
            "Google2u.AssaultRifle_AK47", 0);
        string attackerId = new('a', 32);
        string defenderId = new('b', 32);

        var manifest = new MatchManifest(
            "sabotage-live-udp-" + (cardSpawned ? "card-drone" : unitId), "local-1", "Park_Multiplayer", map.SourceHash,
            content.Revision, MatchManifest.RifleCombatMode, 10, 90, 120,
            [
                new(attackerId, weapon, 1, attackerCover.SourceIndex, 1,
                    new(1000), 0, 0, 0)
                {
                    EquippedArmyUnitIds = ["ID_UNIT-ASSAULT"],
                    ArmyNormalUpgradeIndexes = [0],
                    ArmySpecialUpgradeIndexes = [-1],
                    ArmyEliteUpgradeIndexes = [-1],
                    ArmyHealthFactors = [new ArmyHealthFactors(1f, 1f)],
                    ArmyDamageScales = [1f],
                    ArmySpeedCoefficients = [1f],
                    ArmyAccuracyCoefficients = [1f]
                },
                new(defenderId, weapon, 2, defenderCover.SourceIndex, 1,
                    new(1000), 0, 0, 0)
                {
                    EquippedArmyUnitIds = [cardSpawned ? "ID_UNIT-ASSAULT" : unitId],
                    ArmyNormalUpgradeIndexes = [0],
                    ArmySpecialUpgradeIndexes = [-1],
                    ArmyEliteUpgradeIndexes = [-1],
                    ArmyHealthFactors = [new ArmyHealthFactors(1f, 1f)],
                    ArmyDamageScales = [1f],
                    ArmySpeedCoefficients = [1f],
                    ArmyAccuracyCoefficients = [1f]
                }
            ])
        {
            SceneMasterPlayerId = attackerId,
            Allocations =
            [
                new(attackerId, ["SABOTAGE"], [], [0], [-1], [-1]),
                new(defenderId, cardSpawned ? ["HEAVYDRONE"] : [], [], [0], [-1], [-1])
            ]
        };
        content.ValidateAllocation(manifest);

        string manifestFile = Path.Combine(Path.GetTempPath(),
            "war-sabotage-udp-" + Guid.NewGuid().ToString("N") + ".json");
        File.WriteAllText(manifestFile, JsonSerializer.Serialize(manifest));
        using var portProbe = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0));
        int port = ((IPEndPoint)portProbe.Client.LocalEndPoint!).Port;
        portProbe.Close();

        string signingKey = Convert.ToBase64String(
            RandomNumberGenerator.GetBytes(32));
        var tokens = new MatchTokens(signingKey);
        string outboxDirectory = Path.Combine(Path.GetTempPath(),
            "war-sabotage-outbox-" + Guid.NewGuid().ToString("N"));
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Battle:SigningKey"] = signingKey,
                ["Battle:ControlKey"] = controlKey == null ? null : Convert.ToBase64String(controlKey),
                ["Battle:BackendResultEndpoint"] = automaticEndpoint?.AbsoluteUri,
                ["Battle:ServerId"] = manifest.ServerId,
                ["Battle:Port"] = port.ToString(),
                ["Battle:MatchManifestPath"] = manifestFile,
                ["Battle:ResultOutboxPath"] = outboxDirectory,
                ["Battle:CombatContentManifestPath"] = Path.Combine(directory,
                    "combat-content-manifest.json")
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
                MatchId = admission.MatchId,
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
            using var attacker = new MatchConnection(Grant(attackerId, 951));
            using var defender = new MatchConnection(Grant(defenderId, 952));
            Check((await attacker.ConnectAsync(timeout.Token)).Code == "admitted" &&
                  (await defender.ConnectAsync(timeout.Token)).Code == "admitted",
                "both signed UDP players enter the source Park match");

            var attackerSelection = await attacker.SelectCardsAsync(
                ["SABOTAGE"], [0], [-1], [-1], [], timeout.Token);
            var defenderSelection = await defender.SelectCardsAsync(
                cardSpawned ? ["HEAVYDRONE"] : [], [0], [-1], [-1], [], timeout.Token);
            Check(attackerSelection.Code == "cards-selected" &&
                  defenderSelection.Code == "cards-selected",
                $"UDP card selections match the Backend-owned SABOTAGE allocation: {attackerSelection.Code}, {defenderSelection.Code}");

            await attacker.ReadyAsync(timeout.Token);
            await defender.ReadyAsync(timeout.Token);
            MatchReply state;
            do
            {
                await Task.Delay(100, timeout.Token);
                state = await attacker.PollAsync(timeout.Token);
            }
            while (state.Snapshot.Phase != BattlePhase.Running);

            string spawnRequestId = new string('d', 32);
            if (cardSpawned)
            {
                Check((await defender.UseUnitCardAsync(spawnRequestId,
                    "HEAVYDRONE", timeout.Token)).Code == "unit-card-activated",
                    "the defending UDP player activates its allocated HEAVYDRONE");
            }
            else
            {
                var armyOffer = await defender.PollArmyAsync(timeout.Token);
                int unitOption = armyOffer.OptionIndexes.First(index =>
                    ArmyOptionIdentityCatalog.Get(index).UnitId == unitId);
                Check((await defender.DeployArmyAsync(unitOption,
                      timeout.Token)).Code == "army-deploying",
                    $"the defending UDP player deploys its assigned {unitId}");
            }

            IReadOnlyList<BattleArmyEntityState> before;
            do
            {
                await Task.Delay(100, timeout.Token);
                before = await attacker.FetchArmyEntitiesAsync(timeout.Token);
            }
            while (!before.Any(entity => entity.UnitId == unitId));
            var target = before.First(entity => entity.UnitId == unitId);
            var defenderTarget = (await defender.FetchArmyEntitiesAsync(
                timeout.Token)).Single(entity => entity.EntityKey == target.EntityKey);
            Check(target.OwnerPlayerId == defenderId &&
                  defenderTarget.OwnerPlayerId == defenderId &&
                  defenderTarget.UnitId == target.UnitId && target.Health > 0,
                $"both UDP players see the same live {unitId} target");

            string requestId = new string('c', 32);
            MatchReply used = await attacker.UseSabotageAsync(requestId,
                timeout.Token);
            var afterSabotage = await defender.FetchArmyEntitiesAsync(timeout.Token);
            Check(used.Code == "sabotage-applied" &&
                  used.Snapshot.CardActivations == (cardSpawned ? 2u : 1u) &&
                  afterSabotage.All(entity => entity.EntityKey != target.EntityKey),
                $"authenticated UDP SABOTAGE spends one card and removes {unitId}: {used.Code}, {used.Snapshot.CardActivations}, {afterSabotage.Count}");
            MatchReply retry = await attacker.UseSabotageAsync(requestId,
                timeout.Token);
            Check(retry.Code == "sabotage-applied" &&
                  retry.Snapshot.CardActivations == (cardSpawned ? 2u : 1u),
                "a repeated request ID cannot spend or kill twice over UDP");

            async Task<List<MatchEvent>> Events(MatchConnection peer)
            {
                var result = new List<MatchEvent>();
                ulong cursor = 0;
                while (true)
                {
                    var page = await peer.PollEventsAsync(cursor,
                        timeout.Token);
                    Check(page.Code == "events",
                        "UDP event cursor remains valid");
                    result.AddRange(page.Events);
                    if (page.Events.Count == 0 ||
                        page.Events[^1].EventId == page.LatestEventId)
                        return result;
                    cursor = page.Events[^1].EventId;
                }
            }

            var attackerEvents = await Events(attacker);
            var defenderEvents = await Events(defender);
            static bool IsSabotageEvent(MatchEvent gameEvent, string ownerId,
                string targetUnitId) =>
                gameEvent.Kind == MatchEventKind.CardEffectApplied &&
                gameEvent.ActorId == ownerId ||
                gameEvent.Kind == MatchEventKind.ArmyDied &&
                gameEvent.ArmyUnitId == targetUnitId;
            var attackerCardEvents = attackerEvents.Where(gameEvent =>
                IsSabotageEvent(gameEvent, attackerId, unitId)).ToArray();
            var defenderCardEvents = defenderEvents.Where(gameEvent =>
                IsSabotageEvent(gameEvent, attackerId, unitId)).ToArray();
            Check(attackerCardEvents.SequenceEqual(defenderCardEvents) &&
                  attackerCardEvents.Count(gameEvent =>
                      gameEvent.Kind == MatchEventKind.CardEffectApplied) == 1 &&
                  attackerCardEvents.Count(gameEvent =>
                      gameEvent.Kind == MatchEventKind.ArmyDied) == 1,
                $"both UDP sockets replay the same card use and {unitId} death");

            if (cardSpawned)
            {
                Check((await defender.ForfeitAsync(timeout.Token)).Code == "forfeited",
                    "the card Drone UDP match reaches a normal terminal state");
                TerminalOutbox.Evidence? saved = null;
                if (readBackend != null)
                {
                    while (saved == null)
                    {
                        saved = await readBackend(manifest.MatchId, timeout.Token);
                        if (saved == null) await Task.Delay(100, timeout.Token);
                    }
                    string acknowledged = Path.Combine(outboxDirectory, manifest.MatchId + ".ack");
                    while (!File.Exists(acknowledged))
                        await Task.Delay(100, timeout.Token);
                    var acknowledgedOutbox = new TerminalOutbox(outboxDirectory);
                    Check(acknowledgedOutbox.Contains(manifest.MatchId, manifest.Digest(),
                              [attackerId, defenderId]) && acknowledgedOutbox.PendingPage().Count == 0,
                        "automatic Worker forwarding durably acknowledges the accepted card result");
                }
                else
                {
                    string resultFile = Path.Combine(outboxDirectory, manifest.MatchId + ".wfr");
                    while (!File.Exists(resultFile))
                        await Task.Delay(100, timeout.Token);
                    var outbox = new TerminalOutbox(outboxDirectory);
                    while (saved == null)
                    {
                        saved = outbox.PendingPage().SingleOrDefault(row =>
                            row.Snapshot.MatchId == manifest.MatchId);
                        if (saved == null) await Task.Delay(100, timeout.Token);
                    }
                }
                var kill = saved.Snapshot.DirectArmyKills.Single();
                Check(kill.EntityKey == target.EntityKey &&
                      kill.VictimOwnerPlayerId == defenderId &&
                      kill.AttackerPlayerId == attackerId &&
                      kill.VictimSourceCardId == "HEAVYDRONE" &&
                      kill.VictimSpawnRequestId == spawnRequestId &&
                      kill.VictimSpawnTick == target.SpawnTick,
                    "Worker outbox retains the exact UDP card Drone spawn and killer proof");
                var stats = BattleSabotageKillStatsProjection.FromPayload(
                    saved.Snapshot.ToByteArray(), manifest.MatchId, saved.Digest);
                Check(stats.Single(row => row.PlayerId == attackerId) is
                      { Kills: 1, OneHitKills: 1, VehiclesDestroyed: 1, TanksDestroyed: 0 },
                    "persisted UDP terminal evidence exposes one source-shaped card kill");
                if (verifyBackend != null)
                    checks += await verifyBackend(saved, timeout.Token);
            }
        }
        finally
        {
            await worker.StopAsync(CancellationToken.None);
            File.Delete(manifestFile);
        }

        return checks;
    }
}
