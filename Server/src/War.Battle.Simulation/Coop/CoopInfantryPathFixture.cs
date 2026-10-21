using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>
/// One exact Unity CalculatePath result for a recovered normal Assaulter
/// spawn and its initially selected enemy point. Obstacle segments are pinned
/// only at their start, midpoint, and end; arbitrary positions need planning.
/// </summary>
public sealed record CoopInfantryPathFixture(
    int Stage, int MissionIndex, int SpawnComponentFileId,
    int PointComponentFileId, float PointFraction,
    Vector3 RequestedStart, Vector3 RequestedEnd,
    Vector3 SampledStart, Vector3 SampledEnd,
    IReadOnlyList<Vector3> Corners, float Length);
