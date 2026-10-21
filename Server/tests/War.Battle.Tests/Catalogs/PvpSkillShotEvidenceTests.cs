using System.Text.Json;
using System.Text.Json.Nodes;
using War.BattleServer;

namespace War.Battle.Tests.Catalogs;

internal static class PvpSkillShotEvidenceTests
{
    internal static void Run(string directory)
    {
        using var manifest = JsonDocument.Parse(
            File.ReadAllBytes(Path.Combine(directory, "combat-content-manifest.json")));
        string scene = manifest.RootElement.GetProperty("SceneRevision").GetString()!;
        string content = manifest.RootElement.GetProperty("StatsRevision").GetString()!;
        string path = Path.Combine(directory, "recovered-pvp-skillshot-scores.json");
        PvpSkillShotScoreCatalog catalog = PvpSkillShotScoreCatalog.Load(path, scene, content);
        if (catalog.Rows.Count != 19 || catalog.PointsForConfirmedFlags(0) != 0)
        {
            throw new InvalidOperationException("Skill-shot score identity changed.");
        }

        Reject(() => PvpSkillShotScoreCatalog.Load(path, new string('0', 64), content));
        Reject(() => PvpSkillShotScoreCatalog.Load(path, scene, new string('0', 64)));
        VerifyMutations(File.ReadAllBytes(path), scene, content);
    }

    private static void VerifyMutations(byte[] accepted, string scene, string content)
    {
        string path = Path.Combine(Path.GetTempPath(), $"war-skillshot-evidence-{Guid.NewGuid():N}.json");
        try
        {
            using (new FileStream(path, FileMode.CreateNew, FileAccess.Write))
            {
            }

            JsonNode document = JsonNode.Parse(accepted)!;
            document["rows"]![0]!["multiplayerPoints"] = 999;
            File.WriteAllBytes(path, JsonSerializer.SerializeToUtf8Bytes(document));
            Reject(() => PvpSkillShotScoreCatalog.Load(path, scene, content));
            document = JsonNode.Parse(accepted)!;
            document["skillCodeSha256"] = new string('0', 64);
            File.WriteAllBytes(path, JsonSerializer.SerializeToUtf8Bytes(document));
            Reject(() => PvpSkillShotScoreCatalog.Load(path, scene, content));
        }
        finally
        {
            File.Delete(path);
        }
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidOperationException("Skill-shot evidence accepted invalid authority.");
    }
}
