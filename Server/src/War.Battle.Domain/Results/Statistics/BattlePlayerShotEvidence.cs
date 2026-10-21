using War.Protocol;

namespace War.BattleServer;

/// <summary>Per-owner accepted fire events; source MatchStats parity remains a separate gate.</summary>
public sealed record BattlePlayerShotEvidence(string PlayerId,int AcceptedShots);
