namespace War.BattleServer;

/// <summary>One captured army flight's observation without a mutable flight reference.</summary>
internal readonly record struct PvpArmyBulletStep(PvpArmyBulletPayload Payload, ArmyProjectileImpact? Impact)
{
    internal bool HasInvalidAuthority { get; init; }
}
