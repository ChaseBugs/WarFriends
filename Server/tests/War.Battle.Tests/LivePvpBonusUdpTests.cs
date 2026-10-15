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
    internal static async Task<int> Run(string directory)
    {
        int checks = 0;
        void Check(bool condition, string description)
        {
            if (!condition) throw new Exception(description);
            checks++;
        }

        var content = BattleCombatContent.Load(
            Path.Combine(directory, "combat-content-manifest.json"));
        var template = MatchManifest.Read(
            Path.Combine(directory, "local-rifle-match-template.json"));
        string firstId = template.Players[0].PlayerId;
        string secondId = template.Players[1].PlayerId;
        var manifest = template with
        {
            MatchId = Guid.NewGuid().ToString("N"),
            SceneMasterPlayerId = firstId,
            PvpBonusMode = MatchManifest.OrdinaryPvpBonusMode,
            PvpGoldBonusesAtAdmission = 0,
            Players = template.Players.Select(player => player with
            {
                PlayerLevel = 8,
                Combat = player.Combat! with { MaxHealth = 10_000 }
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
            string clip = right ? "player_fire_right3" : "player_fire_left3";
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
                ["Battle:ResultOutboxPath"] = outboxPath
            }).Build();
        using var worker = new NetworkWorker(config,
            NullLogger<NetworkWorker>.Instance);
        try
        {
            await worker.StartAsync(CancellationToken.None);
            using var timeout = new CancellationTokenSource(
                TimeSpan.FromSeconds(35));
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
                   attempts++ < 50)
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
            var secondView = await second.PollAsync(timeout.Token);
            Check(secondView.Snapshot.PvpBonusBoxes.Select(item => item.BoxId)
                      .SequenceEqual(firstView.Snapshot.PvpBonusBoxes.Select(item => item.BoxId)),
                "both UDP peers receive the same bonus box identities");

            for (int attempt = 0; attempt < 35; attempt++)
            {
                firstView = await first.PollAsync(timeout.Token);
                var activeBox = firstView.Snapshot.PvpBonusBoxes.FirstOrDefault(
                    item => item.BoxId == box.BoxId);
                if (activeBox == null) break;
                box = activeBox;
                await first.FireAsync(box.X, box.Y, box.Z, timeout.Token);
                await second.FireAsync(box.X, box.Y, box.Z, timeout.Token);
                await Task.Delay(250, timeout.Token);
            }
            firstView = await first.PollAsync(timeout.Token);
            secondView = await second.PollAsync(timeout.Token);
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
}
