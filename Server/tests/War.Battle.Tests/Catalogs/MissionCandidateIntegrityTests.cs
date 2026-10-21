using System.Text.Json;
using System.Text.Json.Nodes;
using War.BattleServer;

namespace War.Battle.Tests.Catalogs;

internal static class MissionCandidateIntegrityTests
{
    internal static void Run(string path)
    {
        byte[] bytes = File.ReadAllBytes(path);
        string temporary = Path.Combine(Path.GetTempPath(), $"war-mission-evidence-{Guid.NewGuid():N}.json");
        try
        {
            using (new FileStream(temporary, FileMode.CreateNew, FileAccess.Write))
            {
            }

            JsonNode source = JsonNode.Parse(bytes)!;
            source["sourceSha256"] = new string('0', 64);
            File.WriteAllBytes(temporary, JsonSerializer.SerializeToUtf8Bytes(source));
            Reject(temporary);

            source = JsonNode.Parse(bytes)!;
            source["sourceSha256"] = "5b159bba5105203cd2a771385a110e63820a840d232e6a027b52b577604495ff";
            source["missions"]![0]!["rewardGold"] = 999;
            File.WriteAllBytes(temporary, JsonSerializer.SerializeToUtf8Bytes(source));
            Reject(temporary);
        }
        finally
        {
            File.Delete(temporary);
        }
    }

    private static void Reject(string path)
    {
        try
        {
            MissionCatalog.Load(path);
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidOperationException("Mission candidate accepted unreviewed source or reward authority.");
    }
}
