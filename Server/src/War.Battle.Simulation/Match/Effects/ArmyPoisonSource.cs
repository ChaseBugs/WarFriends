namespace War.BattleServer;

/// <summary>Launch-bound player and soldier identity retained for one independent poison coroutine.</summary>
internal readonly record struct ArmyPoisonSource(
    ulong ProjectileId, ulong EntityKey, string AttackerPlayerId, string VictimPlayerId);
