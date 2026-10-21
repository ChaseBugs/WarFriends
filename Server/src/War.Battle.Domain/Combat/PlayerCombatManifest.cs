namespace War.BattleServer;

public sealed record PlayerCombatManifest(float MaxHealth, float ShotCoefficient = 1,
    float NoDamageChance = 0, bool Immortal = false, bool TutorialProtection = false);
