using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private const float MaximumSicknessWeaponDamage = 10_000_000f;

    /// <summary>Changes the current weapon and vitality authority of a normal Assaulter.</summary>
    internal bool ApplySicknessToArmyAssaulter(ulong entityKey, SicknessSpawnWindow window)
    {
        ArgumentNullException.ThrowIfNull(window);
        return activeArmyEntities.TryGetValue(entityKey, out var entity) && entity.UnitId == "ID_UNIT-ASSAULT" &&
            ApplySicknessToArmyPrimaryWeapon(entityKey, window);
    }

    /// <summary>Applies source damage-field and vitality rules for reviewed ordinary weapon layouts.</summary>
    internal bool ApplySicknessToArmyPrimaryWeapon(ulong entityKey, SicknessSpawnWindow window)
    {
        ArgumentNullException.ThrowIfNull(window);
        if (activeArmyEntities.TryGetValue(entityKey, out var candidate) && candidate.UnitId == "ID_UNIT-GRENADIER")
        {
            return ApplySicknessToOrdinaryGrenadier(entityKey, window);
        }

        if (phase != BattlePhase.Running ||
            !activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.UnitId is not ("ID_UNIT-ASSAULT" or "ID_UNIT-SNIPER" or "ID_UNIT-MINIGUNNER" or
                "ID_UNIT-PARATROOPER" or "ID_UNIT-SWAT" or "ID_UNIT-GUNSLINGER" or "ID_UNIT-COMMANDO" or
                "ID_UNIT-SHOTGUNNER" or "ID_UNIT-WARPER") ||
            entity.SourceCardId.Length != 0)
        {
            return false;
        }

        // Walk, Corner and Minigunner pass EnemyController.canBeFreezed. Their primary
        // launch paths read armyDamage; critical probability and shot cadence stay unchanged.
        // Commando initializes both guns from the same source damage; its alternating
        // muzzle launches share this ledger. Poison ratio and Paratrooper kevlar are separate fields.
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
            !float.IsFinite(damage) || damage < 0f || damage > MaximumSicknessWeaponDamage ||
            entity.Health != vitality.Current || entity.MaxHealth != vitality.Maximum)
        {
            throw new InvalidDataException("Sickness primary weapon lost its current combat authority.");
        }

        // For these two families armyDamage represents ShotGunBulletSetup.maxDamage.
        // ImproveAllWeapons changes damageAmount, but BulletShotGun overwrites it from
        // unchanged minDamage/maxDamage before creating the real damaging bullet.
        bool preservesShotgunRange = entity.UnitId is "ID_UNIT-SHOTGUNNER" or "ID_UNIT-WARPER";
        float[] currentWeaponFields = preservesShotgunRange ? [] : [damage];
        var current = new SicknessCombatState(vitality.Maximum, vitality.Current, currentWeaponFields);
        SicknessCombatState changed = window.Apply(target, current);
        vitality.Current = changed.Health;
        entity.Health = changed.Health;
        if (!preservesShotgunRange)
        {
            armyDamage[entityKey] = changed.WeaponDamage[0];
        }
        armyEntityRevision++;
        stateRevision++;
    }
}
