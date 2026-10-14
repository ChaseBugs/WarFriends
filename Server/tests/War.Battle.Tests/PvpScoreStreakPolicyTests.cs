using System.Text.Json;
using War.BattleServer;

internal static class PvpScoreStreakPolicyTests
{
    internal static int Run(string directory)
    {
        int checks = 0;
        void Check(bool condition, string description)
        {
            if (!condition) throw new Exception(description);
            checks++;
        }
        string path = Path.Combine(directory, "recovered-pvp-score-streak-policy.json");
        using var manifest = JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory, "combat-content-manifest.json")));
        string scene = manifest.RootElement.GetProperty("SceneRevision").GetString()!;
        string content = manifest.RootElement.GetProperty("StatsRevision").GetString()!;
        var policy = BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json")).PvpScoreStreak;
        Check(policy.MultiplayerRatio == 0.75f && policy.RatioForMatch(true) == 0.75f,
            "runtime multiplayer progress uses the source Constants row rather than serialized 0.075");
        Check(policy.RatioForMatch(false) == 0,
            "the source no-crate branch disables progress gain");
        Check(policy.ProgressLossPerSecond == 1.1f,
            "decay uses the MainScene override rather than the C# default of one");
        Check(policy.BonusThreshold == 100 && policy.MaximumBonusesPerUpdate == 1,
            "strict threshold and one bonus per source Update are preserved as parameters");
        Check(policy.MatchmakingEasyBotTillLevel == 4 &&
              !policy.DropsCratesForOnlineView(3, 42) &&
              !policy.DropsCratesForOnlineView(4, 4) &&
              policy.DropsCratesForOnlineView(4, 5),
            "local display rank five and opponent raw index above four use different source comparisons");
        Check(!policy.DropsCratesForOnlineView(42, null) &&
              policy.DropsCratesForOnlineView(42, 42) &&
              !policy.DropsCratesForOnlineView(5, 4),
            "missing opponent disables crates and the online gate is source-view specific");
        foreach (Action invalid in new Action[] {
            () => policy.DropsCratesForOnlineView(-1, 6),
            () => policy.DropsCratesForOnlineView(43, 6),
            () => policy.DropsCratesForOnlineView(6, -1),
            () => policy.DropsCratesForOnlineView(6, 43) })
        {
            try { invalid(); throw new Exception("Out-of-catalog source rank accepted."); }
            catch (ArgumentOutOfRangeException) { checks++; }
        }
        foreach (var binding in new[] { (new string('0', 64), content), (scene, new string('0', 64)) })
        {
            try { PvpScoreStreakPolicy.Load(path, binding.Item1, binding.Item2); throw new Exception("Foreign policy binding accepted."); }
            catch (InvalidDataException) { checks++; }
        }
        string damaged = Path.Combine(Path.GetTempPath(), "war-pvp-streak-" + Guid.NewGuid().ToString("N") + ".json");
        try
        {
            File.WriteAllText(damaged, File.ReadAllText(path).Replace("0.75", "0.075", StringComparison.Ordinal));
            try { PvpScoreStreakPolicy.Load(damaged, scene, content); throw new Exception("Changed policy accepted."); }
            catch (InvalidDataException) { checks++; }
        }
        finally { File.Delete(damaged); }
        return checks;
    }
}
