using War.Protocol;

namespace War.BattleServer;

/// <summary>Validated deployment and spawn counts for one source unit.</summary>
public sealed record BattleArmyUnitStats(
    string UnitId,
    int AcceptedDeployments,
    int PlannedSpawns,
    int ConfirmedSpawns);
