namespace War.BattleServer;

/// <summary>A value-only flight observation; consumers cannot advance or mutate the stored flight.</summary>
internal readonly record struct PvpBulletStep(
    ulong ProjectileId,
    ResolvedPlayerDamage Damage,
    string WeaponSourceId,
    BulletImpact? Impact)
{
    internal bool HasInvalidAuthority { get; init; }
}
