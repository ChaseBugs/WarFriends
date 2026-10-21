using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Nodes;
using War.BattleServer;

namespace War.Battle.Tests.Catalogs;

internal static class AirGeometryInventoryTests
{
    internal static void Run(string directory)
    {
        using var manifest = JsonDocument.Parse(
            File.ReadAllBytes(Path.Combine(directory, "combat-content-manifest.json")));
        string revision = manifest.RootElement.GetProperty("AirGeometryRevision").GetString()!;
        string deployment = manifest.RootElement.GetProperty("ArmyDeploymentRevision").GetString()!;
        string path = Path.Combine(directory, "recovered-air-unit-geometry.json");

        DroneColliderCatalog drone = DroneColliderCatalog.Load(path, revision, deployment);
        if (drone.Revision != revision)
        {
            throw new InvalidOperationException("Drone catalog lost its admitted revision.");
        }

        HelicopterBodyColliderCatalog.Load(path, revision, deployment);
        AssaultHelicopterBoxColliderCatalog.Load(path, revision, deployment);
        AssaultHelicopterWeaponCatalog.Load(path, revision, deployment);
        AirShotTargetCatalog.Load(path, revision, deployment);
        Reject(() => DroneColliderCatalog.Load(path, new string('0', 64), deployment));
        Reject(() => DroneColliderCatalog.Load(path, revision, new string('0', 64)));
        VerifyGeometryTampering(path, deployment);
    }

    private static void VerifyGeometryTampering(string path, string deployment)
    {
        JsonNode document = JsonNode.Parse(File.ReadAllBytes(path))!;
        document["units"]![0]!["colliders"]![0]!["restCenter"]![0] = 999f;
        byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(document);
        string revision = Convert.ToHexStringLower(SHA256.HashData(bytes));
        string temporaryPath = Path.Combine(Path.GetTempPath(), $"war-air-{Guid.NewGuid():N}.json");
        try
        {
            using (var temporary = new FileStream(temporaryPath, FileMode.CreateNew, FileAccess.Write))
            {
                temporary.Write(bytes);
            }

            // A matching file hash cannot promote an unreviewed collider change.
            Reject(() => DroneColliderCatalog.Load(temporaryPath, revision, deployment));
            Reject(() => HelicopterBodyColliderCatalog.Load(temporaryPath, revision, deployment));
            Reject(() => AssaultHelicopterBoxColliderCatalog.Load(temporaryPath, revision, deployment));
            Reject(() => AssaultHelicopterWeaponCatalog.Load(temporaryPath, revision, deployment));
            Reject(() => AirShotTargetCatalog.Load(temporaryPath, revision, deployment));
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

        throw new InvalidOperationException("Air inventory accepted invalid authority.");
    }
}
