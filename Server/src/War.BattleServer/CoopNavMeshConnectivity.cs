using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Host path queries over the pinned co-op Unity triangles. The shared graph
/// supplies conservative corridors; Unity agent steering, avoidance, and
/// corner timing still need comparison before this drives live combat.
/// </summary>
public sealed class CoopNavMeshConnectivity
{
    private readonly IReadOnlyList<ArmyNavMeshConnectivity.Graph> graphs;
    private readonly CoopNavMeshTriangulationCatalog geometry;
    private readonly CoopInfantryPathFixtureCatalog? sourcePaths;

    private CoopNavMeshConnectivity(
        CoopNavMeshTriangulationCatalog geometry,
        ArmyNavMeshConnectivity.Graph[] graphs,
        CoopInfantryPathFixtureCatalog? sourcePaths)
    {
        this.geometry = geometry;
        this.graphs = Array.AsReadOnly(graphs);
        this.sourcePaths = sourcePaths;
    }

    public static CoopNavMeshConnectivity Build(
        CoopNavMeshTriangulationCatalog geometry,
        CoopInfantryPathFixtureCatalog? sourcePaths = null)
    {
        ArgumentNullException.ThrowIfNull(geometry);
        if (geometry.Maps.Count != 5)
            throw new InvalidDataException("Co-op navigation needs five maps.");
        var graphs = new ArmyNavMeshConnectivity.Graph[5];
        for (int index = 0; index < graphs.Length; index++)
        {
            CoopNavMeshTriangulation map = geometry.Maps[index];
            if (map.Stage != index + 1 || map.Indices.Count % 3 != 0)
                throw new InvalidDataException(
                    "Co-op navigation map order changed.");
            graphs[index] = new ArmyNavMeshConnectivity.Graph(
                map.Vertices, map.Indices,
                visibleOffsetLimit: 2.5f,
                visibleNodeLimit: 128);
        }
        if (sourcePaths != null)
        {
            foreach (CoopInfantryPathFixture path in sourcePaths.Cases)
            {
                if (path.Stage is < 1 or > 5)
                    throw new InvalidDataException(
                        "Co-op source path stage is outside the mesh set.");
                ArmyNavMeshPolylineAudit audit = graphs[path.Stage - 1]
                    .InspectPolyline(path.Corners);
                if (!audit.PlanarCovered ||
                    audit.MaxVerticalDeviation > 0.25f)
                    throw new InvalidDataException(
                        "Unity source path is not covered by the host mesh.");
            }
        }
        return new CoopNavMeshConnectivity(geometry, graphs, sourcePaths);
    }

    public int ComponentCount(MissionCatalog missions, int missionIndex)
    {
        int index = MapIndex(missions, missionIndex);
        return graphs[index].ComponentCount;
    }

    public ArmyNavMeshConnection Classify(MissionCatalog missions,
        int missionIndex, Vector3 start, Vector3 end)
    {
        int index = MapIndex(missions, missionIndex);
        return graphs[index].Classify(start, end);
    }

    public Vector3? SampleNearest(MissionCatalog missions,
        int missionIndex, Vector3 position, float radius)
    {
        int index = MapIndex(missions, missionIndex);
        return graphs[index].SampleNearest(position, radius);
    }

    public ArmyNavMeshCorridor? PlanCorridor(MissionCatalog missions,
        int missionIndex, Vector3 start, Vector3 end)
    {
        int index = MapIndex(missions, missionIndex);
        return graphs[index].PlanCorridor(start, end);
    }

    /// <summary>
    /// Uses Unity corners only for the exact recovered spawn and destination
    /// position that produced the fixture. A randomized obstacle position or
    /// later retarget falls back to the general planner.
    /// </summary>
    public ArmyNavMeshCorridor? PlanSourceSpawnCorridor(
        MissionCatalog missions, int missionIndex,
        int spawnComponentFileId, int pointComponentFileId,
        Vector3 requestedStart, Vector3 requestedEnd)
    {
        int mapIndex = MapIndex(missions, missionIndex);
        CoopInfantryPathFixture? fixture = sourcePaths?.ForExactSpawn(
            mapIndex + 1, spawnComponentFileId, pointComponentFileId,
            requestedStart, requestedEnd);
        if (fixture == null)
            return null;
        ArmyNavMeshPolylineAudit audit = graphs[mapIndex]
            .InspectPolyline(fixture.Corners);
        if (!audit.PlanarCovered || audit.MaxVerticalDeviation > 0.25f)
            throw new InvalidDataException(
                "Pinned Unity co-op source path changed after startup.");
        return new ArmyNavMeshCorridor(fixture.Corners, fixture.Length,
            fixture.Corners, fixture.Length, true,
            audit.MaxVerticalDeviation);
    }

    public ArmyNavMeshPolylineAudit InspectPolyline(MissionCatalog missions,
        int missionIndex, IReadOnlyList<Vector3> points)
    {
        int index = MapIndex(missions, missionIndex);
        return graphs[index].InspectPolyline(points);
    }

    private int MapIndex(MissionCatalog missions, int missionIndex)
    {
        ArgumentNullException.ThrowIfNull(missions);
        CoopNavMeshTriangulation map = geometry.MapForMission(
            missions, missionIndex);
        return map.Stage - 1;
    }
}
