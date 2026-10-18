using System.Numerics;

using War.BattleServer;
using War.Protocol;

/// <summary>Exercises ordinary arrival, real callbacks, single-shot launches and airborne lifetime.</summary>
internal static class GunslingerShootingTests
{
    private const string UnitId = "ID_UNIT-GUNSLINGER";
    private const int ShieldTargetType = 2;
    private const int RandomScale = 1_000_000;
    private const ulong MaximumTick = 1800;
    private const float Tolerance = 0.0001f;
    private static readonly string OwnerId = new('b', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        return CheckHost(content, ShotMode.Real) + CheckHost(content, ShotMode.Cosmetic) +
            CheckHost(content, ShotMode.Cancelled) + CheckHost(content, ShotMode.MovingShield) + CheckFullBurst(content);
    }

    private static int CheckHost(BattleCombatContent content, ShotMode mode)
    {
        int Choose(int maximum) => maximum == RandomScale && mode == ShotMode.Cosmetic ? RandomScale - 1 : 0;
        MatchEngine host = OrdinaryArmyTestHost.Create(content, UnitId, armyChoice: Choose);
        int option = host.ArmyBatch(OwnerId).OptionIndexes.First(index => content.Army.Option(index).Count == 1);
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = option }
        }).Code == "army-deploying", "The Gunslinger firing fixture failed ordinary deployment.");
        host.Advance(61);
        ulong actor = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().EntityKey;
        while (!host.Terminal && host.GunslingerAttempt(actor) == null && host.Snapshot().ServerTick < MaximumTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }

        GunslingerShotAttempt attempt = host.GunslingerAttempt(actor) ??
            throw new InvalidOperationException("Ordinary Gunslinger did not prepare: " + host.Snapshot().TerminalReason);
        if (mode == ShotMode.Cancelled)
        {
            return CheckCancelledShot(host, actor, attempt);
        }

        if (mode == ShotMode.MovingShield)
        {
            Require(host.Command(attempt.Aim.Target.OwnerPlayerId, new MatchCommand
            {
                CommandId = 3, MoveCover = new() { Direction = 1 }
            }).Code == "moving", "The source Shield fixture failed its real cover move.");
        }

        ulong cursor = host.EventBatch(OwnerId, 0).LatestEventId;
        var events = new List<MatchEvent>();
        AdvanceTo(host, attempt.CallbackTick, events, ref cursor);
        if (mode == ShotMode.MovingShield)
        {
            return CheckMovingShieldCallback(host, actor, attempt);
        }
        int checks = CheckCallback(host, actor, attempt, content);
        checks += Require(events.All(row => row.Kind != MatchEventKind.Shot),
            "Gunslinger fired inside its coroutine callback instead of the next gameplay poll.");
        checks += CheckLaunch(new ShotFixture(host, actor, attempt, mode), events, ref cursor, content);
        return checks;
    }

    private static int CheckMovingShieldCallback(MatchEngine host, ulong actor, GunslingerShotAttempt attempt)
    {
        GunslingerAimPrediction prediction = attempt.Prediction ??
            throw new InvalidOperationException("The moving-player Gunslinger callback did not execute.");
        int checks = Require(prediction.Inputs.Velocity.LengthSquared() > 0f &&
            prediction.Inputs.Position == attempt.Aim.Target.TransformPosition &&
            attempt.Aim.Target.CapturedShieldCoverIndex.HasValue,
            "A moving player's callback lost current velocity or rebound its captured Shield transform.");
        float flight = Vector3.Distance(prediction.Inputs.Muzzle, prediction.Inputs.Position) /
            prediction.Inputs.BulletSpeed + 0.1f;
        Vector3 expected = prediction.Inputs.Position + flight * prediction.Inputs.Velocity;
        checks += Require(Vector3.Distance(prediction.TargetPosition, expected) < Tolerance &&
            prediction.TargetPosition != attempt.Aim.Target.TransformPosition,
            "The real moving-player callback failed source zero-extra-time prediction.");
        checks += Require(host.ConfirmArmyDeath(actor, false),
            "The moving callback fixture could not cancel its not-yet-fired soldier.");
        return checks;
    }

    private static int CheckCancelledShot(MatchEngine host, ulong actor, GunslingerShotAttempt attempt)
    {
        ulong cursor = host.EventBatch(OwnerId, 0).LatestEventId;
        var events = new List<MatchEvent>();
        int checks = Require(host.ConfirmArmyDeath(actor, false) && host.GunslingerAttempt(actor) == null,
            "A Gunslinger killed during windup retained its pending callback.");
        AdvanceTo(host, attempt.PollTick + 1, events, ref cursor);
        checks += Require(!host.Terminal && attempt.Prediction == null &&
            events.All(row => row.Kind != MatchEventKind.Shot),
            "A removed Gunslinger executed its cancelled coroutine or launched a new bullet.");
        return checks;
    }

    private static int CheckCallback(MatchEngine host, ulong actor, GunslingerShotAttempt attempt,
        BattleCombatContent content)
    {
        GunslingerAimPrediction prediction = attempt.Prediction ??
            throw new InvalidOperationException("Gunslinger callback did not execute: " + host.Snapshot().TerminalReason);
        int checks = Require(host.Snapshot().ServerTick == attempt.CallbackTick &&
            prediction.Inputs.BulletSpeed == content.Army.EffectiveInfantryBulletSpeed(UnitId, 1f) * 0.5f,
            "The normal callback missed its tick or source half-speed player multiplier.");
        checks += Require(prediction.Inputs.Position == attempt.LastTargetPosition &&
            prediction.Inputs.Velocity == Vector3.Zero && prediction.TargetPosition == prediction.Inputs.Position,
            "Stationary Gunslinger callback invented motion or used a compounded prepared prediction.");
        if (attempt.Aim.Target.ShotTargetType == ShieldTargetType)
        {
            checks += Require(attempt.Aim.Target.CapturedShieldCoverIndex.HasValue &&
                prediction.Inputs.Position == attempt.Aim.Target.TransformPosition,
                "The callback substituted the serialized player child for its captured cover Shield transform.");
        }

        BattleArmyEntityState entity = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single(row => row.EntityKey == actor);
        Vector3 toward = attempt.Aim.TargetPosition - new Vector3(entity.X, entity.Y, entity.Z);
        Quaternion rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, MathF.Atan2(toward.X, toward.Z));
        float seconds = GunslingerFiringClock.FireLoopSeconds(attempt.LoopEntry,
            attempt.CallbackTick - attempt.Aim.AcquisitionTick,
            content.EnemyPoses.Clip("colt_shooting_start").Length) ?? throw new InvalidOperationException("No fire phase.");
        Vector3 expected = content.CoopEnemyMuzzles.Place("colt_shooting_loop",
            new Vector3(entity.X, entity.Y, entity.Z), rotation, seconds).Position;
        checks += Require(Vector3.Distance(prediction.Inputs.Muzzle, expected) < Tolerance,
            "Gunslinger callback lost the native Colt muzzle phase or positive target-facing root turn.");
        return checks;
    }

    private static int CheckLaunch(ShotFixture fixture, List<MatchEvent> events, ref ulong cursor,
        BattleCombatContent content)
    {
        var (host, actor, attempt, mode) = fixture;
        MatchSnapshot before = host.Snapshot();
        AdvanceTo(host, attempt.PollTick, events, ref cursor);
        MatchEvent[] rounds = events.Where(row => row.Kind == MatchEventKind.Shot).ToArray();
        int checks = Require(!host.Terminal && attempt.CompletedTick == attempt.PollTick &&
            rounds.Length == 1 && rounds[0].Tick == attempt.PollTick,
            "A normal Gunslinger did not launch exactly one round on its first post-callback gameplay poll.");
        ulong projectile = rounds[0].ProjectileId;
        var authority = host.ArmyProjectileLaunch(projectile) ??
            throw new InvalidOperationException("The Gunslinger projectile lost launch authority.");
        checks += Require(authority.OwnerPlayerId == OwnerId && authority.Damage > 0f,
            "The real ordinary Gunslinger launch lost server-owned identity or damage.");
        checks += Require(host.ConfirmArmyDeath(actor, false) && host.GunslingerAttempt(actor) == null &&
            host.ArmyProjectileLaunch(projectile) == authority,
            "Gunslinger death removed an airborne shot or retained its pending attack.");
        while (!host.Terminal && host.ArmyProjectileLaunch(projectile).HasValue &&
            host.Snapshot().ServerTick < MaximumTick)
        {
            AdvanceTo(host, host.Snapshot().ServerTick + 1, events, ref cursor);
        }

        checks += Require(!host.Terminal && !host.ArmyProjectileLaunch(projectile).HasValue,
            "The launched Gunslinger round did not finish through the real host flight path.");
        if (mode == ShotMode.Cosmetic)
        {
            checks += Require(events.All(row => row.Kind != MatchEventKind.Impact) &&
                before.Players.Select(row => row.Health).SequenceEqual(host.Snapshot().Players.Select(row => row.Health)) &&
                before.Shields.Select(row => row.Health).SequenceEqual(host.Snapshot().Shields.Select(row => row.Health)),
                "A cosmetic Gunslinger round produced a collision or changed player/shield health.");
        }
        else
        {
            checks += Require(events.Count(row => row.Kind == MatchEventKind.Impact && row.ProjectileId == projectile) == 1,
                "The real Gunslinger round did not produce exactly one physical impact.");
            float playerDamage = before.Players.Sum(row => row.Health) - host.Snapshot().Players.Sum(row => row.Health);
            float shieldDamage = before.Shields.Sum(row => row.Health) - host.Snapshot().Shields.Sum(row => row.Health);
            float initialShield = before.Shields.Single(row =>
                row.CoverIndex == attempt.Aim.Target.CapturedShieldCoverIndex).Health;
            float expectedDamage = MathF.Min(initialShield, authority.Damage *
                content.Shields.UnitToShieldCoefficient);
            checks += Require(shieldDamage > 0f && playerDamage == 0f &&
                MathF.Abs(shieldDamage - expectedDamage) < Tolerance,
                "The source Shield-bound Gunslinger round lost actual damage or its UnitToShield coefficient.");
            Console.WriteLine($"Gunslinger actual player damage {playerDamage}, shield damage {shieldDamage}.");
        }

        Console.WriteLine($"PASS: ordinary Gunslinger {mode}, callback {attempt.CallbackTick}, shot {attempt.PollTick}.");
        return checks;
    }

    private static int CheckFullBurst(BattleCombatContent content)
    {
        MatchEngine host = OrdinaryArmyTestHost.Create(content, UnitId);
        int option = host.ArmyBatch(OwnerId).OptionIndexes.First(index => content.Army.Option(index).Count == 1);
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = option }
        }).Code == "army-deploying", "The repeated Colt fixture failed normal deployment.");
        host.Advance(61);
        ulong actor = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().EntityKey;
        int expectedCount = content.Army.ComposeShot(UnitId, 0, null, null, 1f).FireBatchSizeMax;
        var attempts = new List<GunslingerShotAttempt>();
        var events = new List<MatchEvent>();
        ulong cursor = host.EventBatch(OwnerId, 0).LatestEventId;
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick &&
            (attempts.Count < expectedCount || !attempts[^1].CompletedTick.HasValue))
        {
            AdvanceTo(host, host.Snapshot().ServerTick + 1, events, ref cursor);
            GunslingerShotAttempt? current = host.GunslingerAttempt(actor);
            if (current != null && (attempts.Count == 0 || !ReferenceEquals(attempts[^1], current)))
            {
                attempts.Add(current);
            }
        }

        int checks = Require(!host.Terminal && attempts.Count == expectedCount &&
            attempts.All(attempt => attempt.Batch.Count == 1 && attempt.CompletedTick == attempt.PollTick),
            "Ordinary Gunslinger did not complete its full source attempt allowance.");
        for (int index = 1; index < attempts.Count; index++)
        {
            checks += Require(attempts[index].Aim.AcquisitionTick ==
                GunslingerFiringClock.NextPreparationTick(attempts[index - 1].PollTick) &&
                attempts[index].CallbackTick == attempts[index].Aim.AcquisitionTick + 1,
                "A warm Gunslinger attempt lost its strict cadence or zero-delay coroutine boundary.");
        }

        checks += Require(events.Count(row => row.Kind == MatchEventKind.Shot) == expectedCount &&
            host.GunslingerState(actor)?.ShotsRemaining == 0,
            "The one-shot override created extra rounds or failed to consume source attempt counters.");
        Console.WriteLine($"PASS: ordinary Gunslinger completes {expectedCount} automatic single-shot attempts.");
        return checks;
    }

    private static void AdvanceTo(MatchEngine host, ulong targetTick, List<MatchEvent> events, ref ulong cursor)
    {
        while (!host.Terminal && host.Snapshot().ServerTick < targetTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            MatchEventBatch page = host.EventBatch(OwnerId, cursor);
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

    private sealed record ShotFixture(MatchEngine Host, ulong Actor, GunslingerShotAttempt Attempt, ShotMode Mode);

    private enum ShotMode
    {
        Real,
        Cosmetic,
        Cancelled,
        MovingShield
    }
}
