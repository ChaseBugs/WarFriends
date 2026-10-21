using War.Protocol;

namespace War.BattleServer;

/// <summary>Host crate counts; only stolen maps to a recovered MatchStats field.</summary>
public sealed record BattleCrateMatchStats(
    string PlayerId,
    int CratesCollected,
    int CratesStolen);
