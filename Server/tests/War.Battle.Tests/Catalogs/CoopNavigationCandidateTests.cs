using War.BattleServer;

namespace War.Battle.Tests.Catalogs;

internal static class CoopNavigationCandidateTests
{
    internal static void Run(string directory)
    {
        string root = Path.GetFullPath(directory);
        MissionCatalog missions = MissionCatalog.Load(Path.Combine(root, "recovered-mission-catalog.json"));
        CoopSpawnPointCatalog spawns = CoopSpawnPointCatalog.Load(
            Path.Combine(root, "recovered-coop-spawn-points.json"), missions);
        CoopNavMeshSourceCatalog navigation = CoopNavMeshSourceCatalog.Load(
            Path.Combine(root, "recovered-coop-navmesh-sources.json"), missions);
        CoopNavMeshPathCatalog paths = CoopNavMeshPathCatalog.Load(
            Path.Combine(root, "recovered-coop-navmesh-paths.json"), missions, spawns, navigation);
        CoopNavMeshTriangulationCatalog triangles = CoopNavMeshTriangulationCatalog.Load(
            Path.Combine(root, "recovered-coop-navmesh-triangulation.json"), missions, navigation);
        if (paths.Maps.Count != 5 || paths.Maps.Sum(map => map.Routes.Count) != 60 ||
            triangles.Maps.Count != 5 || triangles.Maps.Sum(map => map.Indices.Count / 3) != 9682)
        {
            throw new InvalidDataException("Co-op navigation candidate lost reviewed routes or triangles.");
        }

        CoopNavMeshConnectivity.Build(triangles);
        CoopTriangulationIntegrityTests.Run(root, missions, navigation);
        MissionCandidateIntegrityTests.Run(Path.Combine(root, "recovered-mission-catalog.json"));
    }
}
