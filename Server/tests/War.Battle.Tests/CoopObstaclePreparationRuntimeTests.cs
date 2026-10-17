using System.Reflection;
using War.BattleServer;
using War.Protocol;

/// <summary>Exercises capture-before-reset on real runtimes without exposing timing overrides to clients.</summary>
internal static class CoopObstaclePreparationRuntimeTests
{
    private const ulong MaximumFixtureTick = 1600;
    private const ulong SettledTurnSteps = 6;
    private const int ObservationCount = 13;
    private const int CompletedReturnPhase = 16;

    internal static void Run(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        Verify(sources, null);
        Verify(sources, 3);
        Verify(sources, CompletedReturnPhase);
        Console.WriteLine("PASS: obstacle prior fire, partial return and completed return " +
            "survive new-volley clock reset");
    }

    private static void Verify(CoopObstacleVolleyRuntimeTests.Sources sources, int? returnSteps)
    {
        (CoopMatchRuntime runtime, ulong enemyId) = Prepare(sources);
        CoopInfantryShotWindup completed = runtime.InfantryShotWindup(enemyId)!;
        if (returnSteps.HasValue)
        {
            while (runtime.ObstacleCrawlReturnTick(enemyId) == null &&
                runtime.Snapshot().ServerTick < MaximumFixtureTick)
            {
                runtime.Advance(runtime.Snapshot().ServerTick + 1);
            }
        }
        ulong? previousReturn = runtime.ObstacleCrawlReturnTick(enemyId);
        ulong captureTick = returnSteps.HasValue
            ? previousReturn!.Value + (ulong)returnSteps.Value : completed.CompletedTick!.Value + 1;
        Require(runtime.ObstacleVolleyState(enemyId)!.NextPositionTick > captureTick + SettledTurnSteps,
            "The fixture must remain stationary through preparation verification.");
        ForceEarlyReadiness(runtime, enemyId, captureTick);
        runtime.Advance(captureTick);
        CoopObstaclePreparationStart origin = runtime.InfantryShotWindup(enemyId)!.ObstaclePreparation!;
        Require(origin.HasPreviousAttempt && origin.CapturedTick == captureTick &&
            origin.PreviousReturnTick == previousReturn && origin.PreviousRoundTick == completed.CompletedTick &&
            origin.PriorReturnTicks == returnSteps &&
            runtime.ObstacleCrawlReturnTick(enemyId) == null,
            "The new volley must retain prior return before its new clock clears that event.");
        int? expectedId = returnSteps.HasValue ? 1 + returnSteps.Value * ObservationCount : null;
        Require(runtime.ObstaclePreparationSampleId(enemyId) == expectedId,
            "Only a known prior crawl may select a verified content sample.");
        runtime.Advance(captureTick + SettledTurnSteps);
        bool isUnsupported = !returnSteps.HasValue || returnSteps.Value < CompletedReturnPhase;
        Require(origin.HasUnverifiedTransition == isUnsupported,
            "Unresolved fire or partial crawl must not be classified as completed fresh preparation.");
        Require((runtime.PlaceObstacleVolleyHitboxes(enemyId).Count == 0) == isUnsupported &&
            (runtime.Snapshot().Coop.EnemySpawns.Single(enemy => enemy.EntityId == enemyId).InfantryAnimation == null)
                == isUnsupported,
            "Unconnected transitions must stay out of fresh-clock collision diagnostics and presentation.");
        runtime.Advance(captureTick + SettledTurnSteps);
        Require(ReferenceEquals(origin, runtime.InfantryShotWindup(enemyId)!.ObstaclePreparation) &&
            runtime.CurrentEnemyCollisionFrame().UnplacedEnemyIds.Contains(enemyId),
            "Replayed observation must preserve the immutable origin without opening hit authority.");
        if (returnSteps == CompletedReturnPhase)
        {
            CoopObservedPosePublicationTests.Run(runtime, enemyId);
        }
        ulong firstNewRound = runtime.InfantryShotWindup(enemyId)!.CallbackTick + 1;
        runtime.Advance(firstNewRound);
        Require(runtime.InfantryRoundIntents(enemyId).Count > 0 &&
            runtime.ObstaclePreparationSampleId(enemyId) == null && origin.PreviousRoundTick == completed.CompletedTick,
            "A confirmed new round must end preparation selection without overwriting the captured old round.");
        if (returnSteps == CompletedReturnPhase)
        {
            Require(runtime.Snapshot().Coop.EnemySpawns.Single(enemy => enemy.EntityId == enemyId)
                .InfantryAnimation?.ObservedPose == null,
                "An emitted round must not retain the preparation reference.");
            Require(runtime.AbortForHostShutdown() && runtime.TerminalEvidenceSnapshot().Coop.EnemySpawns
                .All(enemy => enemy.InfantryAnimation?.ObservedPose == null),
                "Terminal evidence must not retain an active preparation reference.");
        }
    }

    private static (CoopMatchRuntime Runtime, ulong EnemyId) Prepare(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        CoopMatchRuntime runtime = CoopObstacleVolleyRuntimeTests.CreateRuntime(sources, () => 0f, () => 0.999f);
        runtime.Advance(8);
        ulong enemyId = runtime.Snapshot().Coop.EnemySpawns.First().EntityId;
        while (runtime.InfantryShotWindup(enemyId)?.CompletedTick == null &&
            runtime.Snapshot().ServerTick < MaximumFixtureTick && !runtime.Terminal)
        {
            runtime.Advance(runtime.Snapshot().ServerTick + 1);
        }
        Require(runtime.InfantryShotWindup(enemyId)?.CompletedTick != null,
            "The source fixture must complete its first obstacle volley.");
        return (runtime, enemyId);
    }

    internal static void ForceEarlyReadiness(CoopMatchRuntime runtime, ulong enemyId, ulong nextTick)
    {
        // Trusted test-only timing exercises source branches that ordinary cooldowns usually skip.
        // There is no Client command or request field that can set these readiness timestamps.
        Dictionary<ulong, CoopInfantryShotWindup> windups = ReadPrivate<Dictionary<ulong, CoopInfantryShotWindup>>(
            runtime, "infantryShotWindups");
        windups[enemyId] = windups[enemyId] with { NextEligibleTick = nextTick };
        Dictionary<ulong, CoopObstacleVolleyClock> clocks = ReadPrivate<Dictionary<ulong, CoopObstacleVolleyClock>>(
            runtime, "_obstacleVolleyClocks");
        PropertyInfo property = typeof(CoopObstacleVolleyClock).GetProperty(
            nameof(CoopObstacleVolleyClock.NextShotTick), BindingFlags.Instance | BindingFlags.NonPublic)!;
        property.SetValue(clocks[enemyId], nextTick);
    }

    private static T ReadPrivate<T>(CoopMatchRuntime runtime, string name)
    {
        FieldInfo field = typeof(CoopMatchRuntime).GetField(name, BindingFlags.Instance | BindingFlags.NonPublic)
            ?? throw new Exception("The trusted runtime fixture field is absent: " + name);
        return (T)field.GetValue(runtime)!;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
