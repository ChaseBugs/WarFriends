namespace War.BattleServer;

/// <summary>Captures admitted upgrade lanes and mode/perk scales for an ordinary Mortar.</summary>
public sealed record ArmyMortarSelection(
    int NormalIndex,
    int? SpecialIndex,
    int? EliteIndex,
    float DamageScale,
    float ShotSpeedCoefficient);
