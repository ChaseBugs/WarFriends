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

internal static class LiveAssaultGlassUdpTests
{
    internal static async Task<int> Run(string contentDirectory)
    {
        int checks = 0;
        void Check(bool condition, string message)
        {
            if (!condition) throw new Exception(message);
            checks++;
        }

        var content = BattleCombatContent.Load(Path.Combine(contentDirectory,
            "combat-content-manifest.json"));
        var map = content.Maps.Single(item =>
            item.Source.EndsWith("Park_Multiplayer.unity", StringComparison.Ordinal));
        var leftCover = map.Covers.First(item => item.Main && item.Fraction == 1 &&
            item.SourceIndex == 2);
        var rightCover = map.Covers.First(item => item.Main && item.Fraction == 2);
        var rifle = content.Stats.CreateManifest("Google2u.AssaultRifle_AK47", 0);
        string aircraftOwner = new('a', 32);
        string shooter = new('b', 32);
        var manifest = MatchManifest.Validate(new MatchManifest(
            "assault-glass-live-udp", "local-1", "Park_Multiplayer", map.SourceHash,
            content.Revision, MatchManifest.RifleCombatMode, 10, 180, 120,
            [
                new(aircraftOwner, rifle, 1, leftCover.SourceIndex, 1, new(1000), 0, 0, 0)
                {
                    EquippedArmyUnitIds = ["ID_UNIT-ASSAULTHELI"],
                    ArmyNormalUpgradeIndexes = [0],
                    ArmySpecialUpgradeIndexes = [-1],
                    ArmyEliteUpgradeIndexes = [-1],
                    ArmyHealthFactors = [new ArmyHealthFactors(1, 1)],
                    ArmyDamageScales = [1],
                    ArmySpeedCoefficients = [1],
                    ArmyAccuracyCoefficients = [1]
                },
                new(shooter, rifle, 2, rightCover.SourceIndex, 1, new(1000), 0, 0, 0)
                {
                    EquippedArmyUnitIds = ["ID_UNIT-ASSAULT"],
                    ArmyNormalUpgradeIndexes = [0],
                    ArmySpecialUpgradeIndexes = [-1],
                    ArmyEliteUpgradeIndexes = [-1],
                    ArmyHealthFactors = [new ArmyHealthFactors(1, 1)],
                    ArmyDamageScales = [1],
                    ArmySpeedCoefficients = [1],
                    ArmyAccuracyCoefficients = [1]
                }
            ]) { SceneMasterPlayerId = aircraftOwner });
        content.ValidateAllocation(manifest);

        string manifestFile = Path.Combine(Path.GetTempPath(),
            "war-assault-glass-" + Guid.NewGuid().ToString("N") + ".json");
        File.WriteAllText(manifestFile, JsonSerializer.Serialize(manifest));
        using var portProbe = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0));
        int port = ((IPEndPoint)portProbe.Client.LocalEndPoint!).Port;
        portProbe.Close();
        string signingKey = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        var tokens = new MatchTokens(signingKey);
        var config = new ConfigurationBuilder().AddInMemoryCollection(
            new Dictionary<string, string?>
            {
                ["Battle:SigningKey"] = signingKey,
                ["Battle:ServerId"] = manifest.ServerId,
                ["Battle:Port"] = port.ToString(),
                ["Battle:MatchManifestPath"] = manifestFile,
                ["Battle:ResultOutboxPath"] = Path.Combine(Path.GetTempPath(),
                    "war-assault-glass-outbox-" + Guid.NewGuid().ToString("N")),
                ["Battle:CombatContentManifestPath"] = Path.Combine(contentDirectory,
                    "combat-content-manifest.json")
            }).Build();
        using var worker = new NetworkWorker(config, NullLogger<NetworkWorker>.Instance);

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
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(100));
            using var ownerPeer = new MatchConnection(Grant(aircraftOwner, 9501));
            using var shooterPeer = new MatchConnection(Grant(shooter, 9502));
            Check((await ownerPeer.ConnectAsync(timeout.Token)).Code == "admitted" &&
                  (await shooterPeer.ConnectAsync(timeout.Token)).Code == "admitted",
                "two signed clients enter the real Assault Helicopter glass Worker");
            await ownerPeer.ReadyAsync(timeout.Token);
            await shooterPeer.ReadyAsync(timeout.Token);

            MatchReply state;
            do
            {
                await Task.Delay(100, timeout.Token);
                state = await ownerPeer.PollAsync(timeout.Token);
            } while (state.Snapshot.Phase != BattlePhase.Running);

            var options = await ownerPeer.PollArmyAsync(timeout.Token);
            Check(options.OptionIndexes.All(index => index == 31) &&
                  (await ownerPeer.DeployArmyAsync(31, timeout.Token)).Code == "army-deploying",
                "owner deploys only its server-issued Assault Helicopter option");

            BattleArmyEntityState? aircraft = null;
            var spawnWatch = System.Diagnostics.Stopwatch.StartNew();
            while (spawnWatch.Elapsed < TimeSpan.FromSeconds(8) && aircraft == null)
            {
                await Task.Delay(100, timeout.Token);
                aircraft = (await shooterPeer.FetchArmyEntitiesAsync(timeout.Token))
                    .SingleOrDefault(entity => entity.UnitId == "ID_UNIT-ASSAULTHELI");
            }
            Check(aircraft is { AssaultGlassHealth: > 0, AssaultRotation: not null } &&
                  aircraft.AssaultGlassHealth == aircraft.AssaultGlassMaxHealth &&
                  MatchConnection.ValidAssaultGlass(aircraft),
                "opponent receives separate full glass health in the paged UDP roster");
            float initialGlass = aircraft!.AssaultGlassHealth;

            BattleArmyEntityState? damaged = null;
            int acceptedShots = 0;
            var fireWatch = System.Diagnostics.Stopwatch.StartNew();
            while (fireWatch.Elapsed < TimeSpan.FromSeconds(45) && damaged == null)
            {
                var current = (await shooterPeer.FetchArmyEntitiesAsync(timeout.Token))
                    .SingleOrDefault(entity => entity.EntityKey == aircraft.EntityKey);
                if (current == null) break;
                var rotation = current.AssaultRotation;
                if (rotation != null)
                {
                    var glass = content.AssaultHelicopterMeshColliders.PlaceFrontGlass(
                        new(current.X, current.Y, current.Z),
                        new(rotation.X, rotation.Y, rotation.Z, rotation.W));
                    var aim = glass.Hitbox.Center;
                    var reply = await shooterPeer.FireAsync(aim.X, aim.Y, aim.Z, timeout.Token);
                    if (reply.Code is "shot-scheduled" or "shot-accepted") acceptedShots++;
                }
                await Task.Delay(220, timeout.Token);
                current = (await shooterPeer.FetchArmyEntitiesAsync(timeout.Token))
                    .SingleOrDefault(entity => entity.EntityKey == aircraft.EntityKey);
                if (current != null && current.AssaultGlassHealth < initialGlass)
                    damaged = current;
                var shooterState = await shooterPeer.PollAsync(timeout.Token);
                if (shooterState.Snapshot.Players.Single(player => player.PlayerId == shooter)
                    .ClipAmmo == 0)
                    await shooterPeer.ReloadAsync(timeout.Token);
            }
            Check(damaged != null && acceptedShots > 0 &&
                  damaged.AssaultGlassHealth < initialGlass &&
                  MatchConnection.ValidAssaultGlass(damaged),
                $"signed UDP rifle fire damages the source front glass (shots={acceptedShots}, " +
                $"health={damaged?.AssaultGlassHealth}/{initialGlass})");
            BattleArmyEntityState? ownerView = null;
            BattleArmyEntityState? shooterView = null;
            var syncWatch = System.Diagnostics.Stopwatch.StartNew();
            while (syncWatch.Elapsed < TimeSpan.FromSeconds(5))
            {
                ownerView = (await ownerPeer.FetchArmyEntitiesAsync(timeout.Token))
                    .Single(entity => entity.EntityKey == aircraft.EntityKey);
                shooterView = (await shooterPeer.FetchArmyEntitiesAsync(timeout.Token))
                    .Single(entity => entity.EntityKey == aircraft.EntityKey);
                if (ownerView.AssaultGlassHealth == shooterView.AssaultGlassHealth) break;
                await Task.Delay(100, timeout.Token);
            }
            Check(ownerView != null && shooterView != null &&
                  ownerView.AssaultGlassHealth == shooterView.AssaultGlassHealth &&
                  ownerView.AssaultGlassHealth < initialGlass &&
                  ownerView.AssaultGlassMaxHealth == shooterView.AssaultGlassMaxHealth,
                "both signed clients receive the same authoritative glass damage");
        }
        finally
        {
            await worker.StopAsync(CancellationToken.None);
            File.Delete(manifestFile);
        }
        return checks;
    }
}
