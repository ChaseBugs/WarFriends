using War.BattleServer;
using War.Protocol;

/// <summary>Checks reservation conservation while multiple real host enemies change points and walk.</summary>
internal static class CoopObstacleReservationRuntimeTests
{
    private const ulong MaximumFixtureTick = 3000;
    private const int RequiredChangedEnemies = 2;
    private const int PointChangeSeconds = 10;

    internal static void Run(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        CoopMatchRuntime runtime = CoopObstacleVolleyRuntimeTests.CreateRuntime(
            sources with { PointChangeSeconds = PointChangeSeconds }, () => 0.999f, () => 0.999f);
        var state = new Observations();
        while (runtime.Snapshot().ServerTick < MaximumFixtureTick && !runtime.Terminal)
        {
            runtime.Advance(runtime.Snapshot().ServerTick + 1);
            Observe(runtime, state);
            if (state.ChangedEnemies.Count >= RequiredChangedEnemies && state.HasReusedReleasedPoint)
            {
                break;
            }
        }

        Require(state.ChangedEnemies.Count >= RequiredChangedEnemies && state.HasReusedReleasedPoint,
            "Multiple actual host enemies must change points and make a released point available to another owner.");
        Console.WriteLine("PASS: concurrent co-op point changes retain unique reservations and reuse released points");
    }

    private static void Observe(CoopMatchRuntime runtime, Observations state)
    {
        var owners = new Dictionary<int, ulong>();
        foreach (BattleCoopEnemySpawn enemy in runtime.Snapshot().Coop.EnemySpawns)
        {
            if (enemy.DeathTick != 0)
            {
                continue;
            }

            CoopAssignedEnemyDestination? destination = runtime.EnemyDestination(enemy.EntityId);
            if (destination == null)
            {
                continue;
            }

            int pointId = destination.PointComponentFileId;
            Require(owners.TryAdd(pointId, enemy.EntityId),
                "Two live enemies cannot own the same point during walking, hiding or retargeting.");
            if (state.CurrentPoints.TryGetValue(enemy.EntityId, out int previous) && previous != pointId)
            {
                state.ReleasedPoints[previous] = enemy.EntityId;
                state.ChangedEnemies.Add(enemy.EntityId);
            }

            state.CurrentPoints[enemy.EntityId] = pointId;
        }

        foreach ((int pointId, ulong previousOwner) in state.ReleasedPoints)
        {
            if (owners.TryGetValue(pointId, out ulong currentOwner) && currentOwner != previousOwner)
            {
                state.HasReusedReleasedPoint = true;
            }
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private sealed class Observations
    {
        internal Dictionary<ulong, int> CurrentPoints { get; } = [];

        internal Dictionary<int, ulong> ReleasedPoints { get; } = [];

        internal HashSet<ulong> ChangedEnemies { get; } = [];

        internal bool HasReusedReleasedPoint { get; set; }
    }
}
