using System.Numerics;

namespace War.BattleServer;

/// <summary>Captures one host-authorized overhead launch, independent of subsequent soldier state.</summary>
internal sealed record MortarMissileLaunch
{
    internal required ulong ProjectileId { get; init; }
    internal required ulong SoldierEntityKey { get; init; }
    internal required ArmyMortarRuntime Weapon { get; init; }
    internal required Vector3 TargetPosition { get; init; }
    internal required ulong LaunchTick { get; init; }
    internal required bool IsFake { get; init; }
}
