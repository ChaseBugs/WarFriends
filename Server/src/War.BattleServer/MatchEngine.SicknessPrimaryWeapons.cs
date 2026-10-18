using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    /// <summary>Changes the current weapon and vitality authority of a normal Assaulter.</summary>
    internal bool ApplySicknessToArmyAssaulter(ulong entityKey, SicknessSpawnWindow window)
    {
        ArgumentNullException.ThrowIfNull(window);
        return activeArmyEntities.TryGetValue(entityKey, out var entity) && entity.UnitId == "ID_UNIT-ASSAULT" &&
            ApplySicknessToArmyPrimaryWeapon(entityKey, window);
    }

    /// <summary>Changes the current gun damage and vitality of source-reviewed ordinary weapon layouts.</summary>
    internal bool ApplySicknessToArmyPrimaryWeapon(ulong entityKey, SicknessSpawnWindow window)
    {
        ArgumentNullException.ThrowIfNull(window);
        if (phase != BattlePhase.Running ||
            !activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.UnitId is not ("ID_UNIT-ASSAULT" or "ID_UNIT-SNIPER" or "ID_UNIT-MINIGUNNER") ||
            entity.SourceCardId.Length != 0)
        {
            return false;
        }

        // Walk, Corner and Minigunner pass EnemyController.canBeFreezed. Their primary
        // launch paths read armyDamage; critical probability and shot cadence stay unchanged.
        var target = new SicknessSpawnTarget(entity.OwnerFraction, true, true);
        if (!window.ShouldAffect(target))
        {
            return false;
        }

        ApplyPrimaryWeaponSicknessAuthority(entityKey, window, target);
        return true;
    }

    private void ApplyPrimaryWeaponSicknessAuthority(ulong entityKey, SicknessSpawnWindow window,
        SicknessSpawnTarget target)
    {
        var entity = activeArmyEntities[entityKey];
        if (stateRevision == ulong.MaxValue || armyEntityRevision == ulong.MaxValue ||
            !armyVitality.TryGetValue(entityKey, out ArmyVitality? vitality) ||
            !armyDamage.TryGetValue(entityKey, out float damage) ||
            entity.Health != vitality.Current || entity.MaxHealth != vitality.Maximum)
        {
            throw new InvalidDataException("Sickness primary weapon lost its current combat authority.");
        }

        var current = new SicknessCombatState(vitality.Maximum, vitality.Current, new[] { damage });
        SicknessCombatState changed = window.Apply(target, current);
        vitality.Current = changed.Health;
        entity.Health = changed.Health;
        armyDamage[entityKey] = changed.WeaponDamage[0];
        armyEntityRevision++;
        stateRevision++;
    }
}
