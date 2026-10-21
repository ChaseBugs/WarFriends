namespace War.BattleServer;

/// <summary>Separates current contact damage from explosion and flight authority.</summary>
public sealed record ArmyMortarRuntime(
    float DirectDamage,
    float ExplosionDamage,
    float Speed,
    float StopTime,
    float PlayerBehindShieldRatio);
