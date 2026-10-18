using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    /// <summary>Changes the current weapon and vitality authority of a normal Assaulter.</summary>
    internal bool ApplySicknessToArmyAssaulter(ulong entityKey, SicknessSpawnWindow window)
    {
        ArgumentNullException.ThrowIfNull(window);
        if (phase != BattlePhase.Running ||
            !activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.UnitId != "ID_UNIT-ASSAULT" || entity.SourceCardId.Length != 0)
        {
            return false;
        }

        // This source SoldierBehaviour is an EnemyController in Walk/Corner states.
        // It has one ordinary gun; mechanical and other weapon layouts are separate bindings.
        var target = new SicknessSpawnTarget(entity.OwnerFraction, true, true);
        if (!window.ShouldAffect(target))
        {
            return false;
        }

        ApplyAssaulterSicknessAuthority(entityKey, window, target);
        return true;
    }

    private void ApplyAssaulterSicknessAuthority(ulong entityKey, SicknessSpawnWindow window,
        SicknessSpawnTarget target)
    {
        var entity = activeArmyEntities[entityKey];
        if (stateRevision == ulong.MaxValue || armyEntityRevision == ulong.MaxValue ||
            !armyVitality.TryGetValue(entityKey, out ArmyVitality? vitality) ||
            !armyDamage.TryGetValue(entityKey, out float damage) ||
            entity.Health != vitality.Current || entity.MaxHealth != vitality.Maximum)
        {
            throw new InvalidDataException("Sickness Assaulter lost its current combat authority.");
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
