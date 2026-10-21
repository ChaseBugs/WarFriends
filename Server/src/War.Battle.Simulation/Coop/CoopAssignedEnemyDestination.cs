using System.Numerics;

namespace War.BattleServer;

public sealed record CoopAssignedEnemyDestination(
    int PointComponentFileId, Vector3 Position);
