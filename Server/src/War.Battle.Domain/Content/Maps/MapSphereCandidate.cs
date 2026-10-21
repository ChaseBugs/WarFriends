using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

public sealed record MapSphereCandidate(MapDynamicCollider Collider,float BoundsDistance);
