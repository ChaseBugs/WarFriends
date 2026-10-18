using System.Numerics;
using System.Text.Json;

using War.BattleServer;
using War.Protocol;

/// <summary>Exercises a real movement command during source Grenadier acquisition.</summary>
internal static class GrenadierMovingAimTests
{
    private const int RandomScale = 1_000_000;
    private const int PrimaryChoice = 400_000;
    private const int BodyChoice = 999_999;
    private const ulong MaximumWaitTick = 1200;
    private const ulong MaximumFlightTicks = 20 * MatchManifest.TickRate;
    private const float PositionTolerance = 0.0001f;
    private static readonly string OwnerId = new('a', 32);
    private static readonly string OpponentId = new('b', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        int projectionChecks = CheckProjection(content, directory);
        RecoveredBattleMap map = content.Maps.Single(candidate =>
            candidate.Source.EndsWith("/Aztec_Multiplayer.unity", StringComparison.Ordinal));
        int checks = TryMovingAcquisition(content, map, 1);
        Require(checks > 0, "The fixed Aztec movement did not reach source moving-body acquisition.");
        return projectionChecks + checks;
    }

    private static int TryMovingAcquisition(BattleCombatContent content, RecoveredBattleMap map, int direction)
    {
        MatchEngine? host = null;
        ulong entityKey = ((ulong)1 << 32) | (uint)CardUnitEntityRegistry.FirstLocalEntityId;
        int readyDraws = 0;
        int Draw(int maximum)
        {
            if (maximum != RandomScale || host?.CardGrenadierAttack(entityKey)?.Phase != ArmyRusherAttackPhase.Ready)
            {
                readyDraws = 0;
                return 0;
            }

            int drawIndex = readyDraws++;
            if (drawIndex == 0)
            {
                return PrimaryChoice;
            }

            return drawIndex == 1 ? BodyChoice : 0;
        }

        host = GrenadierPrimaryDamageTests.CreateRealShotHost(content, map, Draw);
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, UseUnitCard = new() { RequestId = new string('d', 32), SourceCardId = "GREATGRENADIER" }
        }).Code == "unit-card-activated", "The moving-target fixture failed its unit-card activation.");
        if (!WaitForPreparation(host, entityKey))
        {
            return 0;
        }

        if (host.Command(OpponentId, new MatchCommand
        {
            CommandId = 3, MoveCover = new() { Direction = direction }
        }).Code != "moving")
        {
            return 0;
        }

        host.Advance(host.Snapshot().ServerTick + 1);
        host.Advance(host.Snapshot().ServerTick + 1);
        return CheckAcquisition(host, content, map, entityKey);
    }

    private static bool WaitForPreparation(MatchEngine host, ulong entityKey)
    {
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumWaitTick)
        {
            if (host.CardGrenadierAttack(entityKey) is
                { Phase: ArmyRusherAttackPhase.Cooldown, CooldownTicksRemaining: 1 })
            {
                return true;
            }

            host.Advance(host.Snapshot().ServerTick + 1);
        }

        return false;
    }

    private static int CheckAcquisition(MatchEngine host, BattleCombatContent content,
        RecoveredBattleMap map, ulong entityKey)
    {
        MatchEngine.CardGrenadierAim? aim = host.CardGrenadierLatchedAim(entityKey);
        int movingId = content.PlayerShotTargets.Gameplay.Single(target => target.Type == 16).TransformFileId;
        if (aim == null || aim.ThrowGrenade || aim.Target.TargetFileId != movingId)
        {
            Console.WriteLine($"Moving primary fixture skipped: {map.Source}, no exposable moving-body latch.");
            return 0;
        }

        MatchEngine.CardGrenadierMovingAim captured = aim.Moving ??
            throw new InvalidOperationException("A moving latch lost its acquisition inputs.");
        Vector3 velocity = captured.Velocity;
        Vector3 moving = captured.TargetPosition;
        Vector3 muzzle = host.CardGrenadierAcquisitionMuzzle(entityKey);
        const float SourcePaddingSeconds = 0.1f;
        float flightSeconds = Vector3.Distance(muzzle, moving) / GrenadierPrimaryWeapon.Instance.Speed +
            SourcePaddingSeconds + SourcePaddingSeconds;
        Vector3 expected = moving + flightSeconds * velocity;
        int checks = Require(velocity.LengthSquared() > 0,
            "The acquired target had no real host movement velocity.");
        checks += Require(captured.Muzzle is Vector3 actual && Vector3.Distance(actual, muzzle) < PositionTolerance,
            "Acquisition did not sample the current published pistol base pose.");
        checks += Require(MathF.Abs(captured.FlightSeconds - flightSeconds) < PositionTolerance,
            "The acquired flight interval lost one of its source timing components.");
        checks += Require(Vector3.Distance(aim.Target.Position, expected) < PositionTolerance,
            "Moving-body lead did not use the acquisition-time muzzle and recovered two padding intervals.");
        checks += Require(host.InfantryPose(entityKey)?.Clip == "pistol_idle",
            "Grenadier acquisition still sampled the rifle base pose.");
        checks += Require(!host.Terminal, "Moving primary acquisition aborted its match.");
        checks += CheckScheduledShot(host, entityKey, aim);
        Console.WriteLine($"PASS: moving Grenadier primary latch on {map.Source}, tick={host.Snapshot().ServerTick}.");
        checks += RejectProjection(new CoopMuzzlePose(Vector3.Zero, default), content);
        checks += RejectProjection(new CoopMuzzlePose(new Vector3(float.NaN), Quaternion.Identity), content);
        return checks;
    }

    private static int RejectProjection(CoopMuzzlePose pose, BattleCombatContent content)
    {
        try
        {
            GrenadierAcquisitionMuzzle.Place(pose, content.CoopAssaulterWeapon, GrenadierPrimaryWeapon.Instance);
        }
        catch (InvalidDataException)
        {
            return 1;
        }

        throw new InvalidOperationException("Invalid sampled muzzle authority was accepted.");
    }

    private static int CheckScheduledShot(MatchEngine host, ulong entityKey, MatchEngine.CardGrenadierAim acquired)
    {
        ulong deadline = host.Snapshot().ServerTick + GrenadierCornerMuzzleCatalog.FirstShotDelayTicks + 2;
        MatchEngine.CardGrenadierShotIntent? fired = null;
        while (!host.Terminal && host.Snapshot().ServerTick <= deadline && fired == null)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            fired = host.CardGrenadierShotIntents().FirstOrDefault(intent => intent.EntityKey == entityKey);
        }

        int checks = Require(fired is { IsReal: true, Aim.ThrowGrenade: false },
            "The actual host scheduler did not fire the moving primary latch.");
        checks += Require(fired!.Aim.Target.Position == acquired.Target.Position &&
            fired.Aim.Moving == acquired.Moving,
            "Subsequent player animation/movement rewrote the acquired prediction.");
        checks += Require(host.Snapshot().Projectiles.Any(projectile =>
            projectile.ArmySourceCardId == "GREATGRENADIER" && projectile.Kind == "army-bullet" &&
            host.ArmyProjectileSpeed(projectile.ProjectileId) == GrenadierPrimaryWeapon.Instance.Speed),
            "Moving primary fire did not launch an authoritative pistol projectile.");
        checks += CheckFlightResolution(host);
        return checks;
    }

    private static int CheckFlightResolution(MatchEngine host)
    {
        ulong projectileId = host.Snapshot().Projectiles.Single(projectile =>
            projectile.ArmySourceCardId == "GREATGRENADIER" && projectile.Kind == "army-bullet").ProjectileId;
        float opponentHealth = host.Snapshot().Players.Single(player => player.PlayerId == OpponentId).Health;
        ulong cursor = host.EventBatch(OwnerId, 0).LatestEventId;
        var impacts = new List<MatchEvent>();
        ulong deadline = host.Snapshot().ServerTick + MaximumFlightTicks;
        while (!host.Terminal && host.Snapshot().ServerTick < deadline &&
            host.Snapshot().Projectiles.Any(projectile => projectile.ProjectileId == projectileId))
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            MatchEventBatch batch = host.EventBatch(OwnerId, cursor);
            impacts.AddRange(batch.Events.Where(item =>
                item.ProjectileId == projectileId && item.Kind == MatchEventKind.Impact));
            cursor = batch.LatestEventId;
        }

        int checks = Require(!host.Terminal && !host.Snapshot().Projectiles.Any(projectile =>
            projectile.ProjectileId == projectileId), "The moving primary flight did not finish normally.");
        // This source prediction overshoots after the short cover movement ends.
        // A latched target is an aim point, never permission to award a hit.
        checks += Require(impacts.Count == 0, "A missed moving prediction acquired a synthetic impact.");
        checks += Require(host.Snapshot().Players.Single(player => player.PlayerId == OpponentId).Health ==
            opponentHealth, "The missed moving prediction changed the opponent's health.");
        checks += Require(host.ArmyProjectileLaunch(projectileId) == null,
            "The completed moving shot retained its damage authority.");
        Console.WriteLine($"PASS: moving prediction misses without damage; flight ends at " +
            $"tick {host.Snapshot().ServerTick}.");
        return checks;
    }

    private static int CheckProjection(BattleCombatContent content, string directory)
    {
        using JsonDocument native = JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(directory, "grenadier-corner-muzzle-unity-reference.json")));
        int checks = 0;
        foreach (JsonElement scenario in native.RootElement.GetProperty("scenarios").EnumerateArray())
        {
            string clip = scenario.GetProperty("fireClip").GetString()!;
            float end = content.EnemyPoses.Clip(clip).Length;
            CoopMuzzlePose reference = content.CoopEnemyMuzzles.Place(clip, Vector3.Zero, Quaternion.Identity, end);
            Vector3 projected = GrenadierAcquisitionMuzzle.Place(reference, content.CoopAssaulterWeapon,
                GrenadierPrimaryWeapon.Instance);
            foreach (JsonElement round in scenario.GetProperty("rounds").EnumerateArray())
            {
                JsonElement position = round.GetProperty("pose").GetProperty("position");
                var actual = new Vector3(position[0].GetSingle(), position[1].GetSingle(), position[2].GetSingle());
                checks += Require(Vector3.Distance(actual, projected) < PositionTolerance,
                    "Reference-rifle replacement did not match an actual native pistol muzzle.");
            }
        }

        return checks;
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
