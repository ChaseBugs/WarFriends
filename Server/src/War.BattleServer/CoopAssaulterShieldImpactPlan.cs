using War.Protocol;

namespace War.BattleServer;

/// <summary>
/// Read-only evidence for a possible enemy unit hit on an allied shield.
/// Diagnostic scene collision is not complete enough to apply this damage.
/// </summary>
internal sealed record CoopAssaulterShieldImpactPlan(
    ulong ProjectileId, ulong EnemyEntityId, ulong Tick,
    int ColliderComponentId, int CoverIndex,
    float SourceDamage, float ShieldDamage);

internal static class CoopAssaulterShieldImpactPlanner
{
    internal static CoopAssaulterShieldImpactPlan? FromDiagnostic(
        CoopDiagnosticFlightResult result,
        BattleCoopEnemySpawn enemy,
        CoopPlayerShotCollisionWorld world,
        CoopEnemyCombatCatalog combat,
        ShieldSourceCatalog shieldPolicy)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(enemy);
        ArgumentNullException.ThrowIfNull(world);
        ArgumentNullException.ThrowIfNull(combat);
        ArgumentNullException.ThrowIfNull(shieldPolicy);

        BulletImpact? impact = result.Impact;
        if (result.Outcome != "impact" || impact == null ||
            result.ProjectileId == 0 ||
            impact.ProjectileId != result.ProjectileId ||
            impact.EnemyEntityId != result.EnemyEntityId ||
            enemy.EntityId != result.EnemyEntityId ||
            enemy.Behaviour != "Assaulter" ||
            impact.Tick != result.Tick ||
            impact.Hit.PlayerId != null ||
            impact.Hit.ColliderLayer != 24 ||
            impact.Hit.ColliderIndex is not int colliderId)
            return null;

        int? coverIndex = world.CoverForShieldCollider(colliderId);
        if (coverIndex == null)
            return null;

        // SoldierBehaviour.ApplyWeaponsSetup replaces the prefab damage with
        // this level/card value. Shield.DoDamage then uses UnitToShieldCoef.
        float sourceDamage = enemy.CardUnit
            ? combat.CardStats(enemy.Behaviour, enemy.CardProgress).Damage
            : combat.OrdinaryStats(enemy.Behaviour, enemy.Level).Damage;
        float shieldDamage = sourceDamage * shieldPolicy.UnitToShieldCoefficient;
        if (!float.IsFinite(sourceDamage) || sourceDamage <= 0 ||
            !float.IsFinite(shieldDamage) || shieldDamage < 0)
            throw new InvalidDataException("Co-op shield impact has invalid source damage.");

        return new CoopAssaulterShieldImpactPlan(result.ProjectileId,
            result.EnemyEntityId, result.Tick, colliderId,
            coverIndex.Value, sourceDamage, shieldDamage);
    }
}
