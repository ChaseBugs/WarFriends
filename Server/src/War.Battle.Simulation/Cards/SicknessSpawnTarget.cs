namespace War.BattleServer;

/// <summary>Host-observed spawn facts; soldier-family membership alone does not establish eligibility.</summary>
public sealed record SicknessSpawnTarget(int Fraction, bool IsEnemyController, bool CanBeFrozen);
