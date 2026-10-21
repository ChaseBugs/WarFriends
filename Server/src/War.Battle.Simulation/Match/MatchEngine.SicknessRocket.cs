using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    /// <summary>Reads the immutable missile setup captured when a host projectile launched.</summary>
    internal ArmyCardRocketRuntime? CardRocketLaunchMissile(ulong projectileId)
    {
        return _armyMissiles.FindLaunch(projectileId)?.Missile;
    }

    /// <summary>
    /// Changes ordinary missile contact damage and current health without rewriting its explosion or speed.
    /// </summary>
    internal bool ApplySicknessToOrdinaryRocket(ulong entityKey, SicknessSpawnWindow window)
    {
        ArgumentNullException.ThrowIfNull(window);
        if (phase != BattlePhase.Running || !activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            !IsRocketSoldier(entity) || entity.SourceCardId.Length != 0)
        {
            return false;
        }

        // Ordinary Bazooka spawns enter Walk; its later Corner state also passes canBeFreezed.
        var target = new SicknessSpawnTarget(entity.OwnerFraction, true, true);
        if (!window.ShouldAffect(target))
        {
            return false;
        }

        if (!cardRocketMissiles.TryGetValue(entityKey, out ArmyCardRocketRuntime? missile) ||
            missile.DirectDamage > MaximumSicknessWeaponDamage ||
            missile.ExplosionDamage > MaximumSicknessWeaponDamage ||
            missile.Speed > CardRocketMissileFlight.MaximumSpeed ||
            !armyDamage.TryGetValue(entityKey, out float explosionDamage) || explosionDamage != missile.ExplosionDamage)
        {
            throw new InvalidDataException("Ordinary Rocket Soldier lost its bounded current missile authority.");
        }

        // Compute and validate every missile field before the shared vitality proof publishes a mutation.
        ArmyCardRocketRuntime changed = window.ApplyRocketDamage(target, missile);
        ApplyPrimaryWeaponSicknessAuthority(entityKey, window, target);
        cardRocketMissiles[entityKey] = changed;
        return true;
    }

    /// <summary>Applies source weapon and current-health changes; automatic card activation remains separate.</summary>
    internal bool ApplySicknessToCardRocket(ulong entityKey, SicknessSpawnWindow window)
    {
        ArgumentNullException.ThrowIfNull(window);
        if (phase != BattlePhase.Running || cardUnitCombat == null ||
            stateRevision == ulong.MaxValue || armyEntityRevision == ulong.MaxValue ||
            !activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.SourceCardId != "BIGROCKET" ||
            !cardRocketMissiles.TryGetValue(entityKey, out var missile))
        {
            return false;
        }

        // SoldierBehaviourBazooka uses EnemyController Walk at spawn and Corner
        // after navigation. Both states pass the recovered canBeFreezed check.
        var target = new SicknessSpawnTarget(entity.OwnerFraction, true, true);
        if (!window.ShouldAffect(target))
        {
            return false;
        }

        ArmyCardRocketRuntime changedMissile = window.ApplyRocketDamage(target, missile);
        RefillSicknessCardUnit(entity, window, target);
        cardRocketMissiles[entityKey] = changedMissile;
        armyEntityRevision++;
        stateRevision++;
        return true;
    }

}
