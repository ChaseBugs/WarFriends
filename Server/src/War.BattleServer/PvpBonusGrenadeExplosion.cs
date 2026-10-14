using System.Numerics;

namespace War.BattleServer;

// GrenadeAmmo.CreateExplosionInfo reads mSetup when the projectile explodes.
// A fallback shot may have changed that same setup after this shot launched.
internal sealed record PvpBonusGrenadeExplosionQuote(
    ulong ProjectileId, string OwnerId, Vector3 Position,
    ulong CollisionTick, ulong ExplosionTick,
    float DirectDamage, float ExplosionDamage, float DeadRadius,
    float HurtRadius, float PlayerBehindShieldRatio);

internal static class PvpBonusGrenadeExplosionPolicy
{
    internal static PvpBonusGrenadeExplosionQuote AfterCollision(
        GrenadeFlightImpact impact, PvpBonusGrenadeSharedDamage currentSetup,
        PvpBonusCatalog catalog, ulong explosionTick)
    {
        ArgumentNullException.ThrowIfNull(impact);
        ArgumentNullException.ThrowIfNull(currentSetup);
        ArgumentNullException.ThrowIfNull(catalog);
        if (impact.Tick == ulong.MaxValue || explosionTick != impact.Tick + 1 ||
            !PlayerHitbox.Finite(impact.Position) ||
            !float.IsFinite(currentSetup.Direct) ||
            currentSetup.Direct is < 0f or > 10_000_000f ||
            !float.IsFinite(currentSetup.Explosion) || currentSetup.Explosion < 0f ||
            currentSetup.Explosion > 10_000_000f ||
            !catalog.HasGrenadeSharedDamage(currentSetup))
            throw new InvalidDataException("Invalid shared bonus grenade damage at impact.");
        return new PvpBonusGrenadeExplosionQuote(impact.ProjectileId,
            impact.OwnerId, impact.Position, impact.Tick, explosionTick,
            currentSetup.Direct, currentSetup.Explosion,
            catalog.GrenadeDeadRadius, catalog.GrenadeHurtRadius,
            catalog.GrenadePlayerBehindShieldRatio);
    }
}
