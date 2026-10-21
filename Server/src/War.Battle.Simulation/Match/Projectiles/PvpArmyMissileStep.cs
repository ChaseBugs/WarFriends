namespace War.BattleServer;

/// <summary>Observes one captured missile's launch authority and optional completed impact.</summary>
internal readonly record struct PvpArmyMissileStep(
    ulong ProjectileId, CardRocketLaunchAuthority Launch, CardRocketMissileImpact? Impact);
