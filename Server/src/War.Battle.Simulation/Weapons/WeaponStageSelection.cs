namespace War.BattleServer;

/// <summary>Keeps a recovered source identity paired with its admitted zero-based upgrade index.</summary>
internal readonly record struct WeaponStageSelection(string SourceId, int UpgradeIndex);
