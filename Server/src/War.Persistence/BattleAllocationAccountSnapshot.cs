using War.Shared;

namespace War.Persistence;

/// <summary>Pairs account state and battle authority read from the same database snapshot.</summary>
public sealed record BattleAllocationAccountSnapshot(
    LegacyPlayerDocument Account, BattleAllocationProjection Allocation);
