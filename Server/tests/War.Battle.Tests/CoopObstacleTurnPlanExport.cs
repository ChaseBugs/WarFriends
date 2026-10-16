using System.Numerics;
using System.Text.Json;
using War.BattleServer;

/// <summary>Exports a real moving-shot state for native navigation and source tween comparison.</summary>
internal static class CoopObstacleTurnPlanExport
{
    internal static void WriteIfRequested(CoopObstacleVolleyRuntimeTests.Sources sources,
        CoopMatchRuntime runtime, ulong enemyId)
    {
        string? output = Environment.GetEnvironmentVariable("WAR_COOP_OBSTACLE_TURN_PLAN");
        if (string.IsNullOrEmpty(output))
        {
            return;
        }

        var enemy = runtime.Snapshot().Coop.EnemySpawns.Single(row => row.EntityId == enemyId);
        CoopInfantryShotWindup windup = runtime.InfantryShotWindup(enemyId)!;
        Vector3 destination = runtime.EnemyDestination(enemyId)!.Position;
        var plan = new
        {
            version = 1,
            asset = "Assets/NavMeshData/NavMesh_7.asset",
            sourceTick = windup.StartTick,
            enemySha256 = sources.Content.EnemyPoses.SourceSha256,
            start = new[] { enemy.CurrentX, enemy.CurrentY, enemy.CurrentZ },
            end = new[] { destination.X, destination.Y, destination.Z },
            startRotation = Values(windup.StartRootRotation),
            targetRotation = Values(windup.FinalRootRotation),
            speed = sources.Combat.MovementSpeed(enemy.Behaviour)
        };
        File.WriteAllText(output, JsonSerializer.Serialize(plan, new JsonSerializerOptions { WriteIndented = true }));
    }

    private static float[] Values(Quaternion rotation)
    {
        return [rotation.X, rotation.Y, rotation.Z, rotation.W];
    }
}
