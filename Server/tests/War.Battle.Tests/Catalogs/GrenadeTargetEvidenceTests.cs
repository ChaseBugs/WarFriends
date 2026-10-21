using System.Text.Json;
using System.Text.Json.Nodes;
using System.Security.Cryptography;
using War.BattleServer;

namespace War.Battle.Tests.Catalogs;

internal static class GrenadeTargetEvidenceTests
{
    internal static void Run(string directory)
    {
        using var manifest = JsonDocument.Parse(
            File.ReadAllBytes(Path.Combine(directory, "combat-content-manifest.json")));
        string scene = manifest.RootElement.GetProperty("SceneRevision").GetString()!;
        string path = Path.Combine(directory, "recovered-grenade-shot-targets.json");
        byte[] accepted = GrenadeShotTargetEvidence.Read(path, scene);
        string targetRevision = manifest.RootElement.GetProperty("PlayerShotTargetsRevision").GetString()!;
        PlayerShotTargetCatalog targets = PlayerShotTargetCatalog.Load(
            Path.Combine(directory, "recovered-player-shot-targets.json"), targetRevision, scene);
        GrenadeCatalog grenades = GrenadeCatalog.Load(Path.Combine(directory, "grenade-content-manifest.json"));
        GrenadeShotTargetCatalog catalog = GrenadeShotTargetCatalog.Load(path, scene, targets, grenades.Poses);
        if (catalog.Revision != Convert.ToHexStringLower(SHA256.HashData(accepted)))
        {
            throw new InvalidOperationException("Grenade targets lost their admitted revision.");
        }

        Reject(() => GrenadeShotTargetEvidence.Read(path, new string('0', 64)));

        JsonNode document = JsonNode.Parse(accepted)!;
        document["clips"]![0]!["frames"]![0]!["positions"]![0]![0] = 999;
        string temporaryPath = Path.Combine(Path.GetTempPath(), $"war-grenade-target-{Guid.NewGuid():N}.json");
        try
        {
            using (var temporary = new FileStream(temporaryPath, FileMode.CreateNew, FileAccess.Write))
            {
                temporary.Write(JsonSerializer.SerializeToUtf8Bytes(document));
            }

            Reject(() => GrenadeShotTargetEvidence.Read(temporaryPath, scene));
        }
        finally
        {
            File.Delete(temporaryPath);
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

        throw new InvalidOperationException("Grenade target evidence accepted invalid authority.");
    }
}
