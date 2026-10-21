using War.Protocol;

namespace War.BattleServer;

/// <summary>Player army totals from one validated terminal result.</summary>
public sealed record BattlePlayerArmyStats(
    string PlayerId,
    IReadOnlyList<BattleArmyUnitStats> Units,
    int UnitsDeployed,
    int UnitsSpawned);
