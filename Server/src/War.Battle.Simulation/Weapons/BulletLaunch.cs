using System.Numerics;

namespace War.BattleServer;

/// <summary>One host-authored shot. Value semantics avoid adding a per-shot context allocation.</summary>
internal readonly record struct BulletLaunch
{
    internal required ulong ProjectileId { get; init; }
    internal required string OwnerId { get; init; }
    internal required Vector3 MuzzlePosition { get; init; }
    internal required Vector3 TargetPosition { get; init; }
    internal required ulong SimulationTick { get; init; }
    internal required float CriticalRoll { get; init; }
    internal required Func<Vector3, Vector3, float, ShotCollision?> TraceCollision { get; init; }
}
