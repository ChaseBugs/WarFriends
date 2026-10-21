using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

public sealed record MapHit(float Distance, Vector3 Position, string SourcePath, string? DynamicOwner, int Layer, int ColliderIndex, Vector3 Normal);
