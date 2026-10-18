using System.Numerics;

using War.BattleServer;
using War.Protocol;

/// <summary>Exercises automatic source callbacks, full real/cosmetic volleys and host projectile lifetimes.</summary>
internal static class AssaulterVolleyTests
{
    private const int RandomScale = 1_000_000;
    private const ulong MaximumWaitTick = 1800;
    private const float Tolerance = 0.0001f;
    private static readonly string OpponentId = new('b', 32);
    private static readonly string VictimId = new('a', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        int checks = 0;
        foreach (VolleyMode mode in Enum.GetValues<VolleyMode>())
        {
            checks += CheckHost(content, mode);
        }

        checks += AssaulterRepeatedVolleyTests.Run(content);
        checks += AssaulterPointChangeTests.Run(content);

        return checks;
    }

    private static int CheckHost(BattleCombatContent content, VolleyMode mode)
    {
        RecoveredBattleMap map = content.Maps.Single(candidate =>
            candidate.Source.EndsWith("/Park_Multiplayer.unity", StringComparison.Ordinal));
        int Draw(int maximum) => maximum == RandomScale && mode == VolleyMode.Cosmetic ? RandomScale - 1 : 0;
        MatchEngine host = mode == VolleyMode.Overtime
            ? GrenadierPrimaryDamageTests.CreateOvertimeShotHost(content, map, Draw)
            : GrenadierPrimaryDamageTests.CreateRealShotHost(content, map, Draw);
        if (mode == VolleyMode.Sickness)
        {
            var window = new SicknessSpawnWindow(1, content.Army);
            window.Arm();
            host.ArmyDeploymentStarted += window.DeploymentStarted;
            host.ArmyDeploymentFinished += window.DeploymentFinished;
            host.SubscribeArmySpawn("assaulter-volley-sickness", key => host.ApplySicknessToArmyAssaulter(key, window));
        }
        int option = host.ArmyBatch(OpponentId).OptionIndexes.First();
        Require(host.Command(OpponentId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = option }
        }).Code == "army-deploying", "The automatic volley fixture failed its normal deployment.");
        host.Advance(host.Snapshot().ServerTick + 1);
        ulong actor = host.ArmyEntityBatch(OpponentId, 0, 0).Entities.Single().EntityKey;
        while (!host.Terminal && host.AssaulterAttempt(actor)?.CallbackTick == null &&
            host.Snapshot().ServerTick < MaximumWaitTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }

        AssaulterCornerAttempt attempt = host.AssaulterAttempt(actor) ??
            throw new InvalidOperationException("The fixed normal actor did not prepare a source volley.");
        ulong callbackTick = attempt.CallbackTick ??
            throw new InvalidOperationException("The source side did not expose.");
        var events = new List<MatchEvent>();
        ulong cursor = host.EventBatch(OpponentId, 0).LatestEventId;
        AdvanceTo(host, callbackTick, events, ref cursor);
        int checks = CheckCallback(host, actor, attempt, content);
        checks += Require(events.All(item => item.Kind != MatchEventKind.Shot),
            "A normal round fired before the next gameplay Update after the source callback.");
        checks += CheckRounds(new VolleyFixture(host, actor, attempt, mode), content, events, ref cursor);
        return checks;
    }

    private static int CheckCallback(MatchEngine host, ulong actor, AssaulterCornerAttempt attempt,
        BattleCombatContent content)
    {
        AssaulterShotCallback callback = host.AssaulterCallback(actor) ??
            throw new InvalidOperationException("The actual host callback did not execute: " +
                $"{host.Snapshot().TerminalReason}.");
        int checks = Require(callback.Tick == attempt.CallbackTick && callback.Prediction.Inputs.BulletSpeed == 5f,
            "The callback missed its source tick or player speed reset.");
        checks += Require(callback.Prediction.TargetPosition == attempt.Aim.TargetPosition &&
            callback.Prediction.Inputs.Velocity == Vector3.Zero,
            "A stationary source player acquired synthetic motion or a fresh replacement aim.");
        BattleArmyEntityState entity = host.ArmyEntityBatch(OpponentId, 0, 0).Entities.Single(row =>
            row.EntityKey == actor);
        CardUnitInitialPoint point = host.AssaulterPoint(actor) ??
            throw new InvalidOperationException("Lost source Corner.");
        bool isRightSide = point.CornerRightSide ?? throw new InvalidOperationException("Lost source side.");
        string look = isRightSide ? "player_look_right3" : "player_look_left3";
        string fire = isRightSide ? "player_fire_right3" : "player_fire_left3";
        CoopQueuedMuzzleSample native = content.CoopAssaulterQueue.Sample(look, fire,
            callback.Tick - attempt.Aim.AcquisitionTick - 1) ??
            throw new InvalidOperationException("The source callback has no pinned native queued muzzle.");
        Vector3 position = new(entity.X, entity.Y, entity.Z);
        Vector3 away = position - attempt.Aim.TargetPosition;
        away.Y = 0f;
        away = Vector3.Normalize(away);
        Quaternion rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, MathF.Atan2(away.X, away.Z));
        Vector3 expected = position + Vector3.Transform(native.LocalPosition, rotation);
        checks += Require(Vector3.Distance(callback.Prediction.Inputs.Muzzle, expected) < Tolerance,
            "Callback prediction did not use the native queued muzzle at the source final Corner rotation.");
        return checks;
    }

    private static int CheckRounds(VolleyFixture fixture, BattleCombatContent content, List<MatchEvent> events,
        ref ulong cursor)
    {
        var (host, actor, attempt, mode) = fixture;
        MatchSnapshot beforeVolley = host.Snapshot();
        float expectedDamage = content.Army.EffectiveDamage("ID_UNIT-ASSAULT", 0, null, null, 1f) *
            (mode == VolleyMode.Sickness ? 0.5f : 1f);
        int checks = 0;
        var launches = new Dictionary<ulong, float>();
        while (!host.Terminal && host.AssaulterAttempt(actor)?.CompletedTick == null &&
            host.Snapshot().ServerTick < MaximumWaitTick)
        {
            int before = events.Count;
            AdvanceTo(host, host.Snapshot().ServerTick + 1, events, ref cursor);
            foreach (MatchEvent shot in events.Skip(before).Where(item => item.Kind == MatchEventKind.Shot))
            {
                var launch = host.ArmyProjectileLaunch(shot.ProjectileId) ??
                    throw new InvalidOperationException("An actual normal shot lost its frozen launch authority.");
                launches.Add(shot.ProjectileId, launch.Damage);
                BattleProjectileState projectile = host.Snapshot().Projectiles.Single(row =>
                    row.ProjectileId == shot.ProjectileId);
                string expectedKind = mode == VolleyMode.Cosmetic ? "army-fake-bullet" : "army-bullet";
                checks += Require(projectile.Kind == expectedKind && projectile.ArmyUnitId == "ID_UNIT-ASSAULT" &&
                    host.ArmyProjectileSpeed(shot.ProjectileId) == (mode == VolleyMode.Cosmetic ? 7.5f : 5f) &&
                    MathF.Abs(launch.Damage - expectedDamage) < Tolerance,
                    "A real/cosmetic source round lost its type, identity or speed.");
            }
        }

        MatchEvent[] rounds = events.Where(item => item.Kind == MatchEventKind.Shot).ToArray();
        checks += Require(!host.Terminal && rounds.Length == attempt.Batch.Count,
            "The automatic host volley did not fire its entire source batch.");
        ulong firstTick = CoopShotCallbackClock.FirstGameplayPollTick(attempt.CallbackTick ??
            throw new InvalidOperationException("The firing volley lost its source callback."));
        checks += Require(rounds.Select(item => item.Tick).SequenceEqual(
            Enumerable.Range(0, rounds.Length).Select(index => firstTick + (ulong)index * 11)),
            "Source rounds lost the next-Update start or strict 0.35-second cadence.");
        ulong lastId = rounds[^1].ProjectileId;
        var frozen = host.ArmyProjectileLaunch(lastId);
        checks += Require(host.ConfirmArmyDeath(actor, false) && host.AssaulterCallback(actor) == null &&
            host.ArmyProjectileLaunch(lastId) == frozen,
            "Actor death removed a launched round or retained its callback.");
        checks += CheckResolution(fixture, launches.Keys.ToHashSet(), events, ref cursor);
        if (mode == VolleyMode.Cosmetic)
        {
            checks += Require(beforeVolley.Players.Select(player => player.Health).SequenceEqual(
                host.Snapshot().Players.Select(player => player.Health)) &&
                beforeVolley.Shields.Select(shield => shield.Health).SequenceEqual(
                    host.Snapshot().Shields.Select(shield => shield.Health)),
                "Cosmetic source rounds changed player or shield health.");
        }
        else if (mode == VolleyMode.Overtime)
        {
            checks += CheckOvertimeDamage(content, (beforeVolley, host.Snapshot()), events, launches);
        }
        else
        {
            checks += CheckShieldDamage(content, beforeVolley, events, launches);
        }
        Console.WriteLine($"PASS: normal Assaulter {mode} volley, first={firstTick}, rounds={rounds.Length}.");
        return checks;
    }

    private static int CheckShieldDamage(BattleCombatContent content, MatchSnapshot before,
        IEnumerable<MatchEvent> events, IReadOnlyDictionary<ulong, float> launches)
    {
        MatchEvent[] hits = events.Where(item => launches.ContainsKey(item.ProjectileId) &&
            item.Kind == MatchEventKind.ShieldDamaged).ToArray();
        int checks = Require(hits.Length == launches.Count,
            "The fixed real/Sickness volley did not resolve every first-batch round against its opposing shield.");
        MatchEvent first = hits[0];
        float initial = before.Shields.Single(row => row.CoverIndex == first.ShieldCoverIndex).Health;
        float actual = initial - first.Health;
        float expected = launches[first.ProjectileId] * content.Shields.UnitToShieldCoefficient;
        checks += Require(MathF.Abs(actual - expected) < Tolerance,
            "An actual Assaulter shield collision lost its source weapon damage or UnitToShield coefficient.");
        Console.WriteLine($"PASS: actual Assaulter shield damage {actual}, raw {launches[first.ProjectileId]}.");
        return checks;
    }

    private static int CheckResolution(VolleyFixture fixture, HashSet<ulong> projectileIds, List<MatchEvent> events,
        ref ulong cursor)
    {
        MatchEngine host = fixture.Host;
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumWaitTick &&
            host.Snapshot().Projectiles.Any(projectile => projectileIds.Contains(projectile.ProjectileId)))
        {
            AdvanceTo(host, host.Snapshot().ServerTick + 1, events, ref cursor);
        }

        int checks = Require(!host.Terminal && projectileIds.All(id => host.ArmyProjectileLaunch(id) == null),
            $"Normal source bullets did not resolve and release their launch authority: " +
                $"tick={host.Snapshot().ServerTick}, terminal={host.Snapshot().TerminalReason}.");
        MatchEvent[] impacts = events.Where(item => item.Kind == MatchEventKind.Impact &&
            projectileIds.Contains(item.ProjectileId)).ToArray();
        checks += Require(fixture.Mode == VolleyMode.Cosmetic ? impacts.Length == 0 : impacts.Length > 0,
            "A real volley had no physical resolution or a cosmetic volley acquired damaging collision.");
        return checks;
    }

    private static int CheckOvertimeDamage(BattleCombatContent content,
        (MatchSnapshot Before, MatchSnapshot After) snapshots, IEnumerable<MatchEvent> events,
        IReadOnlyDictionary<ulong, float> launches)
    {
        int checks = Require(snapshots.Before.EndTick == 0 && snapshots.Before.Shields.All(shield => shield.Destroyed),
            "The Assaulter player-damage fixture did not enter actual overtime and destroy its shields.");
        MatchEvent[] hits = events.Where(item => item.Kind == MatchEventKind.Impact &&
            item.TargetId == VictimId && launches.ContainsKey(item.ProjectileId)).ToArray();
        checks += Require(hits.Length == launches.Count,
            "The fixed overtime volley did not hit its physical weight-one player victim with both real rounds.");
        float coefficient = content.Army.PlayerDamagePolicy("ID_UNIT-ASSAULT").OvertimePlayerDamageRatio;
        float expected = hits.Sum(hit => launches[hit.ProjectileId]) * coefficient;
        float actual = snapshots.Before.Players.Single(player => player.PlayerId == VictimId).Health -
            snapshots.After.Players.Single(player => player.PlayerId == VictimId).Health;
        checks += Require(MathF.Abs(actual - expected) < 0.001f,
            "Actual Assaulter overtime player damage lost its frozen raw damage or recovered coefficient.");
        Console.WriteLine($"PASS: actual Assaulter overtime player damage {actual}, expected {expected}.");
        return checks;
    }

    private static void AdvanceTo(MatchEngine host, ulong tick, List<MatchEvent> events, ref ulong cursor)
    {
        while (!host.Terminal && host.Snapshot().ServerTick < tick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            MatchEventBatch page = host.EventBatch(OpponentId, cursor);
            events.AddRange(page.Events);
            cursor = page.LatestEventId;
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

    private sealed record VolleyFixture(MatchEngine Host, ulong Actor, AssaulterCornerAttempt Attempt, VolleyMode Mode);

    private enum VolleyMode
    {
        Real,
        Cosmetic,
        Sickness,
        Overtime
    }
}
