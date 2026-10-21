using War.Protocol;

namespace War.BattleServer;

/// <summary>Source MatchStats scorestreak count derived from host-spawned boxes.</summary>
public sealed record BattleScorestreakMatchStats(string PlayerId, int ScorestreaksGained);
