namespace War.BattleServer;

internal sealed record PlayerDamageResult(bool Applied, float Health, float Damage,
    float OriginalDamage, CombatDamageType Type, bool OneHit, bool Dead);
