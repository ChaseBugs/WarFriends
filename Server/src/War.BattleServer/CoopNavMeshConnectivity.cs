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

    private CoopNavMeshConnectivity(
        CoopNavMeshTriangulationCatalog geometry,
        ArmyNavMeshConnectivity.Graph[] graphs)
    {
        this.geometry = geometry;
        this.graphs = Array.AsReadOnly(graphs);
    }

    public static CoopNavMeshConnectivity Build(
        CoopNavMeshTriangulationCatalog geometry)
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
                map.Vertices, map.Indices);
        }
        return new CoopNavMeshConnectivity(geometry, graphs);
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

    private int MapIndex(MissionCatalog missions, int missionIndex)
    {
        ArgumentNullException.ThrowIfNull(missions);
        CoopNavMeshTriangulation map = geometry.MapForMission(
            missions, missionIndex);
        return map.Stage - 1;
    }
}
