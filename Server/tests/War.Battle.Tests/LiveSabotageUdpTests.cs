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
            "sabotage-live-udp", "local-1", "Park_Multiplayer", map.SourceHash,
            content.Revision, MatchManifest.RifleCombatMode, 10, 90, 120,
            [
                new(attackerId, weapon, 1, attackerCover.SourceIndex, 1,
                    new(1000), 0, 0, 0)
                {
                    EquippedArmyUnitIds = ["ID_UNIT-ASSAULT"],
                    ArmyNormalUpgradeIndexes = [0],
                    ArmySpecialUpgradeIndexes = [-1],
                    ArmyEliteUpgradeIndexes = [-1],
                    ArmyHealthFactors = [new ArmyHealthFactors(1f, 1f)]
                },
                new(defenderId, weapon, 2, defenderCover.SourceIndex, 1,
                    new(1000), 0, 0, 0)
                {
                    EquippedArmyUnitIds = ["ID_UNIT-HUMVEE"],
                    ArmyNormalUpgradeIndexes = [0],
                    ArmySpecialUpgradeIndexes = [-1],
                    ArmyEliteUpgradeIndexes = [-1],
                    ArmyHealthFactors = [new ArmyHealthFactors(1f, 1f)]
                }
            ])
        {
            SceneMasterPlayerId = attackerId,
            Allocations =
            [
                new(attackerId, ["SABOTAGE"], [], [0], [-1], [-1]),
                new(defenderId, [], [], [0], [-1], [-1])
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
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Battle:SigningKey"] = signingKey,
                ["Battle:ServerId"] = manifest.ServerId,
                ["Battle:Port"] = port.ToString(),
                ["Battle:MatchManifestPath"] = manifestFile,
                ["Battle:ResultOutboxPath"] = Path.Combine(Path.GetTempPath(),
                    "war-sabotage-outbox-" + Guid.NewGuid().ToString("N")),
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
                [], [0], [-1], [-1], [], timeout.Token);
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

            var armyOffer = await defender.PollArmyAsync(timeout.Token);
            int humveeOption = armyOffer.OptionIndexes.First(index =>
                ArmyOptionIdentityCatalog.Get(index).UnitId == "ID_UNIT-HUMVEE");
            Check((await defender.DeployArmyAsync(humveeOption,
                  timeout.Token)).Code == "army-deploying",
                "the defending UDP player deploys its assigned Humvee");

            IReadOnlyList<BattleArmyEntityState> before;
            do
            {
                await Task.Delay(100, timeout.Token);
                before = await attacker.FetchArmyEntitiesAsync(timeout.Token);
            }
            while (!before.Any(entity => entity.UnitId == "ID_UNIT-HUMVEE"));
            var humvee = before.Single(entity =>
                entity.UnitId == "ID_UNIT-HUMVEE");
            var defenderHumvee = (await defender.FetchArmyEntitiesAsync(
                timeout.Token)).Single(entity => entity.EntityKey == humvee.EntityKey);
            Check(humvee.OwnerPlayerId == defenderId &&
                  defenderHumvee.OwnerPlayerId == defenderId &&
                  defenderHumvee.UnitId == humvee.UnitId,
                "both UDP players see the same host-owned mechanical target");

            string requestId = new string('c', 32);
            MatchReply used = await attacker.UseSabotageAsync(requestId,
                timeout.Token);
            var afterSabotage = await defender.FetchArmyEntitiesAsync(timeout.Token);
            Check(used.Code == "sabotage-applied" &&
                  used.Snapshot.CardActivations == 1 &&
                  afterSabotage.All(entity => entity.EntityKey != humvee.EntityKey),
                $"authenticated UDP SABOTAGE spends one card and removes the Humvee: {used.Code}, {used.Snapshot.CardActivations}, {afterSabotage.Count}");
            MatchReply retry = await attacker.UseSabotageAsync(requestId,
                timeout.Token);
            Check(retry.Code == "sabotage-applied" &&
                  retry.Snapshot.CardActivations == 1,
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
            Check(attackerEvents.SequenceEqual(defenderEvents) &&
                  attackerEvents.Any(gameEvent =>
                      gameEvent.Kind == MatchEventKind.CardEffectApplied &&
                      gameEvent.ActorId == attackerId) &&
                  attackerEvents.Any(gameEvent =>
                      gameEvent.Kind == MatchEventKind.ArmyDied &&
                      gameEvent.ArmyUnitId == "ID_UNIT-HUMVEE"),
                "both UDP sockets replay the same card use and Humvee death");
        }
        finally
        {
            await worker.StopAsync(CancellationToken.None);
            File.Delete(manifestFile);
        }

        return checks;
    }
}
