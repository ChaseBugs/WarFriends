namespace War.BattleServer;

/// <summary>Detached identity for validating a due flame burst before its pulse is committed.</summary>
internal readonly record struct ArmyFlameSource(ulong ProjectileId, ulong EntityKey, string OwnerPlayerId);
