using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    /// <summary>Reads the immutable missile setup captured when a host projectile launched.</summary>
    internal ArmyCardRocketRuntime? CardRocketLaunchMissile(ulong projectileId)
    {
        return rocketLaunches.GetValueOrDefault(projectileId)?.Missile;
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
        RefillSicknessRocket(entity, window, target);
        cardRocketMissiles[entityKey] = changedMissile;
        armyEntityRevision++;
        stateRevision++;
        return true;
    }

    private void RefillSicknessRocket(BattleArmyEntityState entity, SicknessSpawnWindow window,
        SicknessSpawnTarget target)
    {
        BattleArmyEntityState current = cardUnitCombat!.Find(entity.EntityKey) ??
            throw new InvalidDataException("Sickness Rocket lost its current vitality authority.");
        if (current.Health != entity.Health || current.MaxHealth != entity.MaxHealth)
        {
            throw new InvalidDataException("Sickness Rocket vitality mirrors disagree.");
        }

        var vitality = new SicknessCombatState(current.MaxHealth, current.Health, Array.Empty<float>());
        SicknessCombatState changedVitality = window.Apply(target, vitality);
        BattleArmyEntityState changed = cardUnitCombat.RefillHealth(entity.EntityKey, changedVitality.Health) ??
            throw new InvalidDataException("Sickness Rocket disappeared before its vitality update.");
        entity.Health = changed.Health;
    }
}
