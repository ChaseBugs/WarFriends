using System.Text.Json;
using System.Text.Json.Nodes;
using War.BattleServer;

namespace War.Battle.Tests.Catalogs;

internal static class CoopTriangulationIntegrityTests
{
    internal static void Run(string root, MissionCatalog missions, CoopNavMeshSourceCatalog navigation)
    {
        string temporary = Path.Combine(Path.GetTempPath(), $"war-coop-evidence-{Guid.NewGuid():N}");
        string meshes = Path.Combine(temporary, "coop-navmesh-triangulation");
        Directory.CreateDirectory(meshes);
        string manifest = Path.Combine(temporary, "recovered-coop-navmesh-triangulation.json");
        string source = Path.Combine(temporary, "recovered-coop-navmesh-sources.json");
        string mesh = Path.Combine(meshes, "NavMesh_7.json");
        try
        {
            File.Copy(Path.Combine(root, Path.GetFileName(source)), source);
            byte[] original = File.ReadAllBytes(Path.Combine(root, Path.GetFileName(manifest)));
            JsonNode changed = JsonNode.Parse(original)!;
            changed["maps"]![0]!["triangles"] = 1;
            File.WriteAllBytes(manifest, JsonSerializer.SerializeToUtf8Bytes(changed));
            Reject(() => CoopNavMeshTriangulationCatalog.Load(manifest, missions, navigation));

            changed = JsonNode.Parse(original)!;
            changed["navigationSourceSha256"] = new string('0', 64);
            File.WriteAllBytes(manifest, JsonSerializer.SerializeToUtf8Bytes(changed));
            Reject(() => CoopNavMeshTriangulationCatalog.Load(manifest, missions, navigation));

            File.WriteAllBytes(manifest, original);
            byte[] geometry = File.ReadAllBytes(Path.Combine(root, "coop-navmesh-triangulation", "NavMesh_7.json"));
            geometry[^1] ^= 1;
            File.WriteAllBytes(mesh, geometry);
            Reject(() => CoopNavMeshTriangulationCatalog.Load(manifest, missions, navigation));
        }
        finally
        {
            File.Delete(mesh);
            File.Delete(source);
            File.Delete(manifest);
            Directory.Delete(meshes);
            Directory.Delete(temporary);
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

        throw new InvalidOperationException("Co-op triangulation accepted altered evidence.");
    }
}
