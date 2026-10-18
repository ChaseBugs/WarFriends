using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    /// <summary>Reads the current grenade setup, separate from immutable card provenance.</summary>
    internal ArmyGrenadeDamageStats? CardGrenadierDamage(ulong entityKey)
    {
        return _cardGrenadierDamage.GetValueOrDefault(entityKey);
    }

    /// <summary>Reads frozen launch damage so later weapon changes cannot rewrite an airborne grenade.</summary>
    internal ArmyGrenadeDamageStats? CardGrenadierLaunchDamage(ulong projectileId)
    {
        return grenadierLaunches.GetValueOrDefault(projectileId)?.Damage;
    }

    /// <summary>Applies the ordinary Grenadier's pistol/minimum grenade modifier and current-health refill.</summary>
    internal bool ApplySicknessToOrdinaryGrenadier(ulong entityKey, SicknessSpawnWindow window)
    {
        ArgumentNullException.ThrowIfNull(window);
        if (phase != BattlePhase.Running || !activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.UnitId != "ID_UNIT-GRENADIER" || entity.SourceCardId.Length != 0)
        {
            return false;
        }

        var target = new SicknessSpawnTarget(entity.OwnerFraction, true, true);
        if (!window.ShouldAffect(target))
        {
            return false;
        }

        if (!_cardGrenadierDamage.TryGetValue(entityKey, out ArmyGrenadeDamageStats? grenade) ||
            grenade.Minimum > MaximumSicknessWeaponDamage || grenade.Explosion > MaximumSicknessWeaponDamage)
        {
            throw new InvalidDataException("Ordinary Grenadier lost its bounded current grenade authority.");
        }

        // ImproveAllWeapons changes AmmoSetup.damageAmount, not GrenadeAmmoSetup.explodeDamageAmount or its fuse.
        // Compute grenade changes before the shared primary/vitality proof publishes either mutation.
        ArmyGrenadeDamageStats changedGrenade = window.ApplyGrenadeDamage(target, grenade);
        ApplyPrimaryWeaponSicknessAuthority(entityKey, window, target);
        _cardGrenadierDamage[entityKey] = changedGrenade;
        return true;
    }

    /// <summary>Applies both weapon damage fields and current health; automatic card activation remains separate.</summary>
    internal bool ApplySicknessToCardGrenadier(ulong entityKey, SicknessSpawnWindow window)
    {
        ArgumentNullException.ThrowIfNull(window);
        if (phase != BattlePhase.Running || cardUnitCombat == null ||
            stateRevision == ulong.MaxValue || armyEntityRevision == ulong.MaxValue ||
            !activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.SourceCardId != "GREATGRENADIER" ||
            !_cardGrenadierDamage.TryGetValue(entityKey, out var damage) ||
            !armyDamage.TryGetValue(entityKey, out float primaryDamage))
        {
            return false;
        }

        // This source unit is an EnemyController. Its spawn Walk/Parachute and
        // subsequent Corner states all pass canBeFreezed; mechanical types do not enter here.
        var target = new SicknessSpawnTarget(entity.OwnerFraction, true, true);
        if (!window.ShouldAffect(target))
        {
            return false;
        }

        ArmyGrenadeDamageStats changedDamage = window.ApplyGrenadeDamage(target, damage);
        var currentWeapons = new SicknessCombatState(entity.MaxHealth, entity.Health, new[] { primaryDamage });
        float changedPrimary = window.Apply(target, currentWeapons).WeaponDamage[0];
        RefillSicknessCardUnit(entity, window, target);
        _cardGrenadierDamage[entityKey] = changedDamage;
        armyDamage[entityKey] = changedPrimary;
        armyEntityRevision++;
        stateRevision++;
        return true;
    }
}
