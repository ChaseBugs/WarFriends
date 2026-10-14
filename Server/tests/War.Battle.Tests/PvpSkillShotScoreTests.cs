using System.Text.Json;
using System.Security.Cryptography;
using War.BattleServer;

internal static class PvpSkillShotScoreTests
{
    internal static int Run(string directory)
    {
        int checks = 0;
        void Check(bool condition, string description)
        {
            if (!condition) throw new Exception(description);
            checks++;
        }
        string contentPath = Path.Combine(directory, "recovered-battle-content.json");
        using var content = JsonDocument.Parse(File.ReadAllBytes(contentPath));
        string scene = content.RootElement.GetProperty("mainSceneSha256").GetString()!;
        string contentDigest = Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(contentPath)));
        string path = Path.Combine(directory, "recovered-pvp-skillshot-scores.json");
        var scores = PvpSkillShotScoreCatalog.Load(path, scene, contentDigest);
        int[] expectedPoints = [10, 2, 4, 2, 6, 10, 20, 50, 2, 20, 10, 20, 6, 4, 4, 4, 10, 60, 10];
        Check(scores.Rows.Count == 19 && scores.ComboWindowSeconds == 0.9f,
            "PvP scoring retains every active source row and serialized combo window");
        for (int index = 0; index < expectedPoints.Length; index++)
            Check(scores.PointsForConfirmedFlags(scores.Rows[index].Flag) == expectedPoints[index],
                "source multiplayer score for " + scores.Rows[index].Name);
        Check(scores.PointsForConfirmedFlags(0x1210) == 46 &&
              scores.PointsForConfirmedFlags(0x5210) == 106,
            "source Sabotage base flags compose 46 points or 106 for a Tank");
        Check(scores.PointsForConfirmedFlags(0) == 0,
            "an empty source skill-shot flag set scores zero");
        foreach (int invalid in new[] { -1, 1024, int.MaxValue })
        {
            try { scores.PointsForConfirmedFlags(invalid); throw new Exception("Unknown score flags accepted."); }
            catch (ArgumentOutOfRangeException) { checks++; }
        }
        try { PvpSkillShotScoreCatalog.Load(path, new string('0', 64), contentDigest);
            throw new Exception("Different scene accepted for PvP scores."); }
        catch (InvalidDataException) { checks++; }
        try { PvpSkillShotScoreCatalog.Load(path, scene, new string('0', 64));
            throw new Exception("Different battle source accepted for PvP scores."); }
        catch (InvalidDataException) { checks++; }
        var list = (IList<PvpSkillShotScore>)scores.Rows;
        try { list[0] = scores.Rows[0] with { MultiplayerPoints = 999 };
            throw new Exception("Validated score rows remained mutable."); }
        catch (NotSupportedException) { checks++; }
        Check(scores.PointsForConfirmedFlags(1) == 10 &&
              BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json"))
                  .PvpScores.PointsForConfirmedFlags(0x1210) == 46,
            "immutable scores are bound before live combat content is published");
        string damagedPath = Path.Combine(Path.GetTempPath(), "war-pvp-scores-" + Guid.NewGuid().ToString("N"));
        try
        {
            byte[] bytes = File.ReadAllBytes(path);
            bytes[^2] ^= 1;
            File.WriteAllBytes(damagedPath, bytes);
            try { PvpSkillShotScoreCatalog.Load(damagedPath, scene, contentDigest);
                throw new Exception("Damaged PvP score authority accepted."); }
            catch (InvalidDataException) { checks++; }
        }
        finally { File.Delete(damagedPath); }
        return checks;
    }
}
