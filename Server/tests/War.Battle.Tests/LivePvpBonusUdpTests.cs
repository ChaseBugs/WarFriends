using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using War.BattleServer;
using War.Client;
using War.Protocol;

internal static class LivePvpBonusUdpTests
{
    internal static Task<int> Run(string directory) => RunScenario(directory, false);

    internal static Task<int> RunShotgun(string directory) =>
        RunScenario(directory, true);

    internal static Task<int> RunBazooka(string directory) =>
        RunScenario(directory, false, true);

    private static async Task<int> RunScenario(string directory, bool shotgun,
        bool bazooka = false)
    {
        int checks = 0;
        void Check(bool condition, string description)
        {
            if (!condition) throw new Exception(description);
            checks++;
        }

        string shotgunManifestPath = Path.Combine(directory,
            "shotgun-content-manifest.json");
        string ContentPath(string weapon) => Path.Combine(directory,
            weapon + "-content-manifest.json");
        var content = bazooka
            ? BattleCombatContent.Load(ContentPath("combat"), ContentPath("shotgun"),
                ContentPath("smg"), ContentPath("pistol"), ContentPath("lmg"),
                ContentPath("minigun"), ContentPath("sniper"),
                ContentPath("bazooka"))
            : BattleCombatContent.Load(ContentPath("combat"),
                shotgun ? shotgunManifestPath : null);
        var template = MatchManifest.Read(
            Path.Combine(directory, "local-rifle-match-template.json"));
        string firstId = template.Players[0].PlayerId;
        string secondId = template.Players[1].PlayerId;
        var shotgunWeapon = shotgun ? content.Shotguns!.CreateManifest(
            "Google2u.Shotgun_SPAS", 35) : null;
        var bazookaWeapon = bazooka ? content.Bazookas!.CreateManifest(
            "Google2u.Bazooka_RPG7", 0) : null;
        var manifest = template with
        {
            MatchId = Guid.NewGuid().ToString("N"),
            Mode = bazooka ? MatchManifest.MixedCombatMode :
                shotgun ? MatchManifest.ShotgunCombatMode : template.Mode,
            CatalogRevision = bazooka ? content.MixedRevision! :
                shotgun ? content.ShotgunRevision! :
                template.CatalogRevision,
            DurationSeconds = shotgun || bazooka ? 120 : template.DurationSeconds,
            SceneMasterPlayerId = firstId,
            PvpBonusMode = MatchManifest.OrdinaryPvpBonusMode,
            PvpGoldBonusesAtAdmission = 0,
            Players = template.Players.Select(player => player with
            {
                PlayerLevel = 8,
                Combat = player.Combat! with { MaxHealth = 100_000 },
                Weapon = shotgun ? shotgunWeapon! : player.Weapon,
                WeaponUpgrade = shotgun ? 35 : player.WeaponUpgrade,
                WeaponSlots = bazooka ?
                    [new WeaponSlotManifest(0, 11, player.Weapon, 0),
                     new WeaponSlotManifest(2, 3, bazookaWeapon!, 0)] : null
            }).ToArray()
        };
        var map = content.Maps.Single(item =>
            Path.GetFileNameWithoutExtension(item.Source) == manifest.MapId);
        var firstCover = map.Covers.Single(item =>
            item.SourceIndex == manifest.Players[0].StartCover);
        var secondCover = map.Covers.Single(item =>
            item.SourceIndex == manifest.Players[1].StartCover);
        Vector3 OpponentHead(CoverNode targetCover, CoverNode shooterCover)
        {
            var direction = shooterCover.Position - targetCover.Position;
            direction.Y = 0;
            var aim = new PlayerAimState();
            aim.LookAt(direction, targetCover.Rotation, 0);
            aim.Advance(.1, .1f, targetCover.Rotation);
            bool right = Vector3.Dot(Vector3.UnitY,
                Vector3.Cross(Vector3.Transform(Vector3.UnitZ,
                    targetCover.Rotation), direction)) > 0;
            string clip = shotgun ?
                (right ? "player_fire_right_shotgun" :
                    "player_fire_left_shotgun") :
                (right ? "player_fire_right3" : "player_fire_left3");
            return content.Poses.SampleAimed(clip, .15, false,
                aim.BodyRotation, null).Place(targetCover.Position,
                targetCover.Rotation).Collision.Parts[1].Center;
        }

        using var portProbe = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0));
        int port = ((IPEndPoint)portProbe.Client.LocalEndPoint!).Port;
        portProbe.Close();
        string key = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        var tokens = new MatchTokens(key);
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

        string manifestPath = Path.Combine(Path.GetTempPath(),
            "war-pvp-bonus-udp-" + manifest.MatchId + ".json");
        string outboxPath = Path.Combine(Path.GetTempPath(),
            "war-pvp-bonus-outbox-" + manifest.MatchId);
        File.WriteAllText(manifestPath, JsonSerializer.Serialize(manifest));
        var config = new ConfigurationBuilder().AddInMemoryCollection(
            new Dictionary<string, string?>
            {
                ["Battle:SigningKey"] = key,
                ["Battle:ServerId"] = manifest.ServerId,
                ["Battle:Port"] = port.ToString(),
                ["Battle:MatchManifestPath"] = manifestPath,
                ["Battle:CombatContentManifestPath"] = Path.Combine(
                    directory, "combat-content-manifest.json"),
                ["Battle:ResultOutboxPath"] = outboxPath,
                ["Battle:ShotgunContentManifestPath"] = shotgun || bazooka ?
                    shotgunManifestPath : null,
                ["Battle:SmgContentManifestPath"] = bazooka ? ContentPath("smg") : null,
                ["Battle:PistolContentManifestPath"] = bazooka ? ContentPath("pistol") : null,
                ["Battle:LmgContentManifestPath"] = bazooka ? ContentPath("lmg") : null,
                ["Battle:MinigunContentManifestPath"] = bazooka ? ContentPath("minigun") : null,
                ["Battle:SniperContentManifestPath"] = bazooka ? ContentPath("sniper") : null,
                ["Battle:BazookaContentManifestPath"] = bazooka ? ContentPath("bazooka") : null
            }).Build();
        using var worker = new NetworkWorker(config,
            NullLogger<NetworkWorker>.Instance);
        try
        {
            await worker.StartAsync(CancellationToken.None);
            using var timeout = new CancellationTokenSource(
                TimeSpan.FromSeconds(shotgun || bazooka ? 100 : 35));
            using var first = new MatchConnection(Grant(firstId, 87101));
            using var second = new MatchConnection(Grant(secondId, 87102));
            Check((await first.ConnectAsync(timeout.Token)).Code == "admitted",
                "first UDP bonus participant admitted");
            Check((await second.ConnectAsync(timeout.Token)).Code == "admitted",
                "second UDP bonus participant admitted");
            await first.ReadyAsync(timeout.Token);
            await second.ReadyAsync(timeout.Token);
            MatchReply firstView;
            do
            {
                await Task.Delay(100, timeout.Token);
                firstView = await first.PollAsync(timeout.Token);
            } while (firstView.Snapshot.Phase != BattlePhase.Running);

            Vector3 target = OpponentHead(secondCover, firstCover);
            Vector3 reverseTarget = OpponentHead(firstCover, secondCover);
            int attempts = 0;
            while (firstView.Snapshot.PvpBonusBoxes.Count == 0 &&
                   firstView.Snapshot.Phase == BattlePhase.Running &&
                   attempts++ < (shotgun ? 190 : 50))
            {
                await first.FireAsync(target.X, target.Y, target.Z,
                    timeout.Token);
                await second.FireAsync(reverseTarget.X, reverseTarget.Y,
                    reverseTarget.Z, timeout.Token);
                await Task.Delay(250, timeout.Token);
                firstView = await first.PollAsync(timeout.Token);
            }
            Check(firstView.Snapshot.PvpBonusBoxes.Count > 0,
                "host-confirmed UDP player hits issue bonus boxes: " +
                $"attempts={attempts}, boxes={firstView.Snapshot.PvpBonusBoxes.Count}, " +
                $"phase={firstView.Snapshot.Phase}, " +
                $"shots={firstView.Snapshot.Players[0].ShotsFired}, " +
                $"hits={firstView.Snapshot.Players[0].ConfirmedPlayerHits}, " +
                $"health={firstView.Snapshot.Players[1].Health}");
            var box = firstView.Snapshot.PvpBonusBoxes[0];
            ulong shotsBeforeBazooka = firstView.Snapshot.Players[0].ShotsFired;
            var secondView = await second.PollAsync(timeout.Token);
            Check(secondView.Snapshot.PvpBonusBoxes.Select(item => item.BoxId)
                      .SequenceEqual(firstView.Snapshot.PvpBonusBoxes.Select(item => item.BoxId)),
                "both UDP peers receive the same bonus box identities");

            if (bazooka)
            {
                var selected = await first.SwitchWeaponAsync(2, timeout.Token);
                Check(selected.Code == "weapon-selected",
                    "first UDP peer equips the source RPG slot");
            }
            for (int attempt = 0; attempt < (bazooka ? 7 : 35); attempt++)
            {
                firstView = await first.PollAsync(timeout.Token);
                var activeBox = firstView.Snapshot.PvpBonusBoxes.FirstOrDefault(
                    item => item.BoxId == box.BoxId);
                if (activeBox == null) break;
                box = activeBox;
                if (bazooka)
                {
                    await first.BazookaHoldAsync(true, box.X, box.Y, box.Z,
                        timeout.Token);
                    await Task.Delay(11_000, timeout.Token);
                }
                else
                {
                    await first.FireAsync(box.X, box.Y, box.Z, timeout.Token);
                    await second.FireAsync(box.X, box.Y, box.Z, timeout.Token);
                    await Task.Delay(250, timeout.Token);
                }
            }
            firstView = await first.PollAsync(timeout.Token);
            secondView = await second.PollAsync(timeout.Token);
            if (bazooka)
            {
                var firstEvents = await ReadEvents(first, timeout.Token);
                var secondEvents = await ReadEvents(second, timeout.Token);
                var bazookaImpacts = firstEvents.Where(item =>
                    item.Kind == MatchEventKind.Impact &&
                    item.Reason == "bazooka" &&
                    item.ActorId == firstId).ToArray();
                Check(firstView.Snapshot.Players[0].ShotsFired > shotsBeforeBazooka &&
                      bazookaImpacts.Length > 0 &&
                      secondEvents.Any(item => bazookaImpacts.Contains(item)),
                    "both UDP peers receive the host RPG flight and impact");
            }
            Check(firstView.Snapshot.PvpBonusBoxes.All(item => item.BoxId != box.BoxId) &&
                  secondView.Snapshot.PvpBonusBoxes.All(item => item.BoxId != box.BoxId),
                "both UDP peers observe host-confirmed box collection");
        }
        finally
        {
            await worker.StopAsync(CancellationToken.None);
            File.Delete(manifestPath);
        }
        return checks;
    }

    private static async Task<IReadOnlyList<MatchEvent>> ReadEvents(
        MatchConnection connection, CancellationToken cancellationToken)
    {
        var events = new List<MatchEvent>();
        ulong cursor = 0;
        while (true)
        {
            var page = await connection.PollEventsAsync(cursor, cancellationToken);
            if (page.Code != "events")
                throw new Exception("Bonus event cursor failed: " + page.Code);
            events.AddRange(page.Events);
            if (page.Events.Count == 0 ||
                page.Events[^1].EventId == page.LatestEventId)
                return events;
            cursor = page.Events[^1].EventId;
        }
    }
}
