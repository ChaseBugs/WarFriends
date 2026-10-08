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

/// <summary>
/// A player hit reported by the host's diagnostic ray. The hitbox weight is
/// evidence for a later damage resolver, not a health mutation.
/// </summary>
internal sealed record CoopAssaulterPlayerImpactPlan(
    ulong ProjectileId, ulong EnemyEntityId, ulong Tick,
    string PlayerId, string PartPath, float PartWeight,
    float SourceDamage);

internal static class CoopAssaulterPlayerDamagePolicy
{
    internal static ResolvedPlayerDamage FromImpact(
        CoopAssaulterPlayerImpactPlan impact)
    {
        ArgumentNullException.ThrowIfNull(impact);
        if (impact.ProjectileId == 0 || impact.EnemyEntityId == 0 ||
            !Guid.TryParseExact(impact.PlayerId, "N", out _) ||
            impact.PlayerId != impact.PlayerId.ToLowerInvariant() ||
            string.IsNullOrWhiteSpace(impact.PartPath) ||
            !float.IsFinite(impact.PartWeight) ||
            impact.PartWeight is <= 0 or > 1000 ||
            !float.IsFinite(impact.SourceDamage) ||
            impact.SourceDamage <= 0)
            throw new InvalidDataException("Invalid co-op Assaulter player impact.");

        // Ammo.DoDamage calls DestroyableObject.Shoot with the unit's weapon.
        // Shoot applies the hit part's shot coefficient before OnDamage.
        // PlayerDamage applies that coefficient through PartWeight and then
        // applies the player's no-damage chance from its signed definition.
        return new ResolvedPlayerDamage(impact.SourceDamage,
            CombatDamageType.Shot, PartWeight: impact.PartWeight);
    }
}

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

internal static class CoopAssaulterPlayerImpactPlanner
{
    internal static CoopAssaulterPlayerImpactPlan? FromDiagnostic(
        CoopDiagnosticFlightResult result,
        BattleCoopEnemySpawn enemy,
        CoopEnemyCombatCatalog combat)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(enemy);
        ArgumentNullException.ThrowIfNull(combat);

        BulletImpact? impact = result.Impact;
        if (result.Outcome != "impact" || impact == null ||
            result.ProjectileId == 0 ||
            impact.ProjectileId != result.ProjectileId ||
            impact.EnemyEntityId != result.EnemyEntityId ||
            enemy.EntityId != result.EnemyEntityId ||
            enemy.Behaviour != "Assaulter" ||
            impact.Tick != result.Tick ||
            impact.Hit.ColliderLayer != 22 ||
            impact.Hit.ColliderIndex != null ||
            impact.Hit.PlayerId is not string playerId ||
            !Guid.TryParseExact(playerId, "N", out _) ||
            playerId != playerId.ToLowerInvariant() ||
            string.IsNullOrWhiteSpace(impact.Hit.SourcePath) ||
            !float.IsFinite(impact.Hit.PartWeight) ||
            impact.Hit.PartWeight is <= 0 or > 1000)
            return null;

        float sourceDamage = enemy.CardUnit
            ? combat.CardStats(enemy.Behaviour, enemy.CardProgress).Damage
            : combat.OrdinaryStats(enemy.Behaviour, enemy.Level).Damage;
        if (!float.IsFinite(sourceDamage) || sourceDamage <= 0)
            throw new InvalidDataException(
                "Co-op player impact has invalid source damage.");

        return new CoopAssaulterPlayerImpactPlan(result.ProjectileId,
            result.EnemyEntityId, result.Tick, playerId,
            impact.Hit.SourcePath, impact.Hit.PartWeight, sourceDamage);
    }
}
