using System.Numerics;

namespace War.BattleServer;

public sealed record CoopNativeRayHit(
    int ComponentFileId, string ComponentType, int Layer,
    float Distance, Vector3 Position);
