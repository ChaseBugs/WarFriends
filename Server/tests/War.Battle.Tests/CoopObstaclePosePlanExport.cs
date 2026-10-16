using System.Text.Json;
using War.BattleServer;

/// <summary>Exports one actual host volley schedule for an isolated Unity pose comparison.</summary>
internal static class CoopObstaclePosePlanExport
{
    private const ulong PostVolleyObservationTicks = 60;

    internal static void WriteIfRequested(BattleCombatContent content, CoopInfantryShotWindup windup,
        IReadOnlyList<CoopInfantryRoundIntent> rounds)
    {
        string? output = Environment.GetEnvironmentVariable("WAR_COOP_OBSTACLE_POSE_PLAN");
        if (string.IsNullOrEmpty(output))
        {
            return;
        }
        if (rounds.Count == 0 || rounds.Any(round => round.Tick < windup.StartTick))
        {
            throw new Exception("An observed volley must precede its pose-plan export.");
        }
        ulong[] ticks = rounds.Select(round => round.Tick - windup.StartTick).ToArray();
        var plan = new
        {
            version = 1,
            enemySha256 = content.EnemyPoses.SourceSha256,
            weaponPrefabGuid = content.CoopAssaulterWeapon.WeaponPrefabGuid,
            startClip = windup.AnimationClip,
            fireClip = windup.QueuedFireClip,
            captureRate = MatchManifest.TickRate,
            roundTicks = ticks,
            captureFrames = checked(ticks[^1] + PostVolleyObservationTicks)
        };
        File.WriteAllText(output, JsonSerializer.Serialize(plan, new JsonSerializerOptions { WriteIndented = true }));
        Console.WriteLine("PASS: exported actual co-op obstacle volley pose schedule");
    }
}
