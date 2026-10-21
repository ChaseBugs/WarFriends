using System.Text.Json;
using System.Text.Json.Nodes;
using War.BattleServer;

namespace War.Battle.Tests.Catalogs;

internal static class PvpBonusEvidenceTests
{
    internal static void Run(string directory)
    {
        using var manifest = JsonDocument.Parse(
            File.ReadAllBytes(Path.Combine(directory, "combat-content-manifest.json")));
        string scene = manifest.RootElement.GetProperty("SceneRevision").GetString()!;
        string content = manifest.RootElement.GetProperty("StatsRevision").GetString()!;
        string path = Path.Combine(directory, "recovered-pvp-bonus-catalog.json");
        byte[] accepted = PvpBonusEvidence.Read(path, scene, content);
        Reject(() => PvpBonusEvidence.Read(path, new string('0', 64), content));
        Reject(() => PvpBonusEvidence.Read(path, scene, new string('0', 64)));
        VerifyMutation(accepted, scene, content);
    }

    private static void VerifyMutation(byte[] accepted, string scene, string content)
    {
        JsonNode document = JsonNode.Parse(accepted)!;
        string path = Path.Combine(Path.GetTempPath(), $"war-bonus-evidence-{Guid.NewGuid():N}.json");
        try
        {
            using (var stream = new FileStream(path, FileMode.CreateNew, FileAccess.Write))
            {
                document["rules"]!["warbucksScalingBase"] = 1.034f;
                stream.Write(JsonSerializer.SerializeToUtf8Bytes(document));
            }

            Reject(() => PvpBonusEvidence.Read(path, scene, content));
            document = JsonNode.Parse(accepted)!;
            document["rows"]![0]!["probability"] = 999;
            File.WriteAllBytes(path, JsonSerializer.SerializeToUtf8Bytes(document));
            Reject(() => PvpBonusEvidence.Read(path, scene, content));
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

        throw new InvalidOperationException("PvP bonus evidence accepted invalid authority.");
    }
}
