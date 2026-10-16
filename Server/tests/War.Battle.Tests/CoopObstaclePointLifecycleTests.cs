using System.Numerics;
using War.BattleServer;
using War.Protocol;

/// <summary>Follows a real point-change route through walking, arrival and source-ready shooting.</summary>
internal static class CoopObstaclePointLifecycleTests
{
    private const ulong MaximumFixtureTick = 3000;
    private const float PositionTolerance = 0.001f;

    internal static void Run(CoopMatchRuntime runtime, ulong enemyId,
        CoopObstacleVolleyRuntimeTests.Sources sources, ulong previousProjectileId)
    {
        CoopAssignedEnemyDestination destination = runtime.EnemyDestination(enemyId)!;
        ulong departedTick = runtime.Snapshot().ServerTick;
        float maximumStep = sources.Combat.MovementSpeed("Assaulter") / MatchManifest.TickRate + PositionTolerance;
        Vector3 previous = Position(runtime, enemyId);
        while (runtime.InfantryPointArrival(enemyId) == null &&
            runtime.Snapshot().ServerTick < MaximumFixtureTick && !runtime.Terminal)
        {
            runtime.Advance(runtime.Snapshot().ServerTick + 1);
            Vector3 current = Position(runtime, enemyId);
            Require(Vector2.Distance(new Vector2(previous.X, previous.Z), new Vector2(current.X, current.Z)) <=
                maximumStep, "Changing points must walk at source speed instead of warping to the new reservation.");
            previous = current;
        }

        CoopInfantryPointArrival arrival = runtime.InfantryPointArrival(enemyId) ??
            throw new Exception("The point-change route did not reach a new source point.");
        Require(arrival.Tick > departedTick && arrival.PointComponentFileId == destination.PointComponentFileId &&
            arrival.FirstShootEligibleTick > arrival.Tick,
            "The new reservation must own a fresh arrival and source shot deadline.");
        VerifyFreshShot(runtime, enemyId, arrival);
        if (runtime.InfantryShotWindup(enemyId) != null)
        {
            VerifyCompletedVolley(runtime, enemyId, previousProjectileId);
        }
        Console.WriteLine($"PASS: co-op point change walks, reaches {arrival.State} and starts a fresh shot lifecycle");
    }

    private static void VerifyFreshShot(CoopMatchRuntime runtime, ulong enemyId, CoopInfantryPointArrival arrival)
    {
        runtime.Advance(arrival.FirstShootEligibleTick - 1);
        Require(runtime.InfantryShotWindup(enemyId) == null,
            "A new point must not inherit the previous point's completed windup or immediate shot readiness.");
        runtime.Advance(arrival.FirstShootEligibleTick);
        if (arrival.State == CoopInfantryPointState.CornerHiding)
        {
            Require(runtime.CornerLatestShotAttempt(enemyId)?.Tick == arrival.FirstShootEligibleTick,
                "Corner arrival must run its source exposure check at the fresh shot deadline.");
        }
        else
        {
            Require(runtime.InfantryShotWindup(enemyId)?.StartTick == arrival.FirstShootEligibleTick &&
                runtime.ObstacleVolleyState(enemyId)?.HasPendingShot == true,
                "Obstacle arrival must prepare the next source volley at its fresh deadline.");
        }

        Require(runtime.CurrentEnemyCollisionFrame().UnplacedEnemyIds.Contains(enemyId),
            "Completing the AI point lifecycle does not establish moving or shot collision authority.");
    }

    private static Vector3 Position(CoopMatchRuntime runtime, ulong enemyId)
    {
        BattleCoopEnemySpawn enemy = runtime.Snapshot().Coop.EnemySpawns.Single(row => row.EntityId == enemyId);
        return new Vector3(enemy.CurrentX, enemy.CurrentY, enemy.CurrentZ);
    }

    private static void VerifyCompletedVolley(CoopMatchRuntime runtime, ulong enemyId, ulong previousProjectileId)
    {
        while (runtime.InfantryShotWindup(enemyId)?.CompletedTick == null &&
            runtime.Snapshot().ServerTick < MaximumFixtureTick && !runtime.Terminal)
        {
            runtime.Advance(runtime.Snapshot().ServerTick + 1);
        }

        CoopInfantryShotWindup? completed = runtime.InfantryShotWindup(enemyId);
        IReadOnlyList<CoopInfantryRoundIntent> rounds = runtime.InfantryRoundIntents(enemyId);
        Require(previousProjectileId > 0 && completed?.CompletedTick != null &&
            completed.NextEligibleTick > completed.CompletedTick && rounds.Count == completed.Batch.Count &&
            rounds.All(round => round.ProjectileId > previousProjectileId) &&
            rounds.Select(round => round.ProjectileId).Distinct().Count() == rounds.Count,
            "A new point must complete its source batch and cooldown " +
            "without recycling previous projectile identities.");
        int completedRoundCount = rounds.Count;
        runtime.Advance(runtime.Snapshot().ServerTick);
        Require(runtime.InfantryRoundIntents(enemyId).Count == completedRoundCount,
            "Replaying the completed new-point tick must not emit another round.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
