using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

public sealed record MapDynamicCollider(int ColliderIndex, string SourcePath, string DynamicOwner, int Layer,
    Vector3 TransformPosition,Vector3 BoundsMin,Vector3 BoundsMax);
