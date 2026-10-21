using System.Text.Json;
using System.Text.Json.Nodes;
using War.BattleServer;

namespace War.Battle.Tests.Catalogs;

internal static class PvpScoreStreakEvidenceTests
{
    internal static void Run(string directory)
    {
        using var manifest = JsonDocument.Parse(
            File.ReadAllBytes(Path.Combine(directory, "combat-content-manifest.json")));
        string scene = manifest.RootElement.GetProperty("SceneRevision").GetString()!;
        string content = manifest.RootElement.GetProperty("StatsRevision").GetString()!;
        string path = Path.Combine(directory, "recovered-pvp-score-streak-policy.json");
        PvpScoreStreakPolicy policy = PvpScoreStreakPolicy.Load(path, scene, content);
        if (policy.RatioForMatch(false) != 0 || policy.RatioForMatch(true) != 0.75f ||
            policy.DropsCratesForOnlineView(4, 4) || !policy.DropsCratesForOnlineView(4, 5))
        {
            throw new InvalidOperationException("Score-streak source boundaries changed.");
        }

        Reject(() => PvpScoreStreakPolicy.Load(path, new string('0', 64), content));
        Reject(() => PvpScoreStreakPolicy.Load(path, scene, new string('0', 64)));
        VerifyMutations(File.ReadAllBytes(path), scene, content);
    }

    private static void VerifyMutations(byte[] accepted, string scene, string content)
    {
        string path = Path.Combine(Path.GetTempPath(), $"war-streak-evidence-{Guid.NewGuid():N}.json");
        try
        {
            using (new FileStream(path, FileMode.CreateNew, FileAccess.Write))
            {
            }

            foreach (string field in new[] { "scoreManagerSha256", "gameControllerOnlineSha256", "bonusThreshold" })
            {
                JsonNode document = JsonNode.Parse(accepted)!;
                document[field] = field == "bonusThreshold" ? JsonValue.Create(99) : JsonValue.Create(new string('0', 64));
                File.WriteAllBytes(path, JsonSerializer.SerializeToUtf8Bytes(document));
                Reject(() => PvpScoreStreakPolicy.Load(path, scene, content));
            }

            JsonNode mixed = JsonNode.Parse(accepted)!;
            const string legacy = "b8b3e9a7e07ed310044c536c1f041c2efef6c0390dfa82dcd2424d1d56b11cb6";
            const string current = "52555acfdb42d53978c0640bb430de7d3eef0165f498533cf9dbddce4cc85a26";
            mixed["scoreManagerSha256"] = mixed["scoreManagerSha256"]!.GetValue<string>() == legacy ? current : legacy;
            File.WriteAllBytes(path, JsonSerializer.SerializeToUtf8Bytes(mixed));
            Reject(() => PvpScoreStreakPolicy.Load(path, scene, content));
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

        throw new InvalidOperationException("Score-streak evidence accepted invalid authority.");
    }
}
