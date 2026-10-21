using System.Numerics;

namespace War.BattleServer;

public sealed record ArmyNavMeshCorridor(IReadOnlyList<Vector3> Points,float Length,
    IReadOnlyList<Vector3> SmoothedPoints,float SmoothedLength,bool PlanarCovered,
    float MaxVerticalDeviation);
