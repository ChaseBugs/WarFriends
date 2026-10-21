using War.BattleServer;

namespace War.Battle.Tests.Catalogs;

internal static class PlayerReferenceCandidateTests
{
    internal static int Run(string directory)
    {
        string root = Path.GetFullPath(directory);
        int checks = RigBlendTests.Run(Path.Combine(root, "recovered-rig-blend-reference.json"));
        string? previousFixture = Environment.GetEnvironmentVariable("WAR_WALKING_SHOT_RENDER_FIXTURE");
        try
        {
            Environment.SetEnvironmentVariable("WAR_WALKING_SHOT_RENDER_FIXTURE", null);
            checks += WalkingShotTests.Run(Path.Combine(root, "recovered-walking-shot-reference.json"));
        }
        finally
        {
            Environment.SetEnvironmentVariable("WAR_WALKING_SHOT_RENDER_FIXTURE", previousFixture);
        }

        IReadOnlyList<RecoveredBattleMap> maps = RecoveredBattleMap.Load(
            Path.Combine(root, "recovered-battle-content.json"));
        RecoveredBattleMap aztec = maps.Single(map =>
            map.Source.EndsWith("Aztec_Multiplayer.unity", StringComparison.Ordinal));
        checks += PlayerCollisionTests.Run(Path.Combine(root, "recovered-player-collision.json"), aztec);
        return checks;
    }
}
