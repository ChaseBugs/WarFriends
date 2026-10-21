using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

/// <summary>Copies current host warning presentation without exposing its mutable lifecycle clock.</summary>
internal sealed record MortarIndicatorObservation
{
    internal required ulong EntityKey { get; init; }
    internal required string OwnerPlayerId { get; init; }
    internal required int OwnerFraction { get; init; }
    internal required ulong ProjectileId { get; init; }
    internal required ulong LaunchTick { get; init; }
    internal required ulong ObservedTick { get; init; }
    internal required Vector3 Position { get; init; }
    internal required float StopSeconds { get; init; }
    internal required bool IsFake { get; init; }
    internal required float RotationFactor { get; init; }
    internal required float Scale { get; init; }
    internal required float Alpha { get; init; }
    internal required BattleMortarWarningClockState Clock { get; init; }
}
