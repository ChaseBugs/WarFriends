using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private readonly Dictionary<ulong, ArmyMortarRuntime> _ordinaryMortarWeapons = [];

    /// <summary>Reads current Mortar weapon authority without publishing a client-controlled launch.</summary>
    internal ArmyMortarRuntime? OrdinaryMortarWeapon(ulong entityKey)
    {
        return _ordinaryMortarWeapons.GetValueOrDefault(entityKey);
    }

    private void InitializeOrdinaryMortar(ulong entityKey)
    {
        if (armyCatalog == null || !activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.UnitId != "ID_UNIT-MORTAR" || entity.SourceCardId.Length != 0)
        {
            throw new InvalidDataException("Ordinary Mortar lost its spawn identity.");
        }

        ParticipantManifest owner = Find(entity.OwnerPlayerId)?.Definition ??
            throw new InvalidDataException("Ordinary Mortar lost its admitted owner.");
        int index = Array.IndexOf(owner.EquippedArmyUnitIds!, entity.UnitId);
        if (index < 0 || owner.ArmyNormalUpgradeIndexes == null || owner.ArmyDamageScales == null ||
            !armyDamage.ContainsKey(entityKey))
        {
            throw new InvalidDataException("Ordinary Mortar lacks admitted upgrade authority.");
        }

        int special = owner.ArmySpecialUpgradeIndexes?[index] ?? -1;
        int elite = owner.ArmyEliteUpgradeIndexes?[index] ?? -1;
        var selection = new ArmyMortarSelection(owner.ArmyNormalUpgradeIndexes[index],
            special >= 0 ? special : null, elite >= 0 ? elite : null, owner.ArmyDamageScales[index],
            owner.ArmyShotSpeedCoefficients?[index] ?? 1f);
        _ordinaryMortarWeapons.Add(entityKey, armyCatalog.ComposeOrdinaryMortar(selection));
    }

    /// <summary>Changes current contact damage and health while retaining explosion and timing fields.</summary>
    internal bool ApplySicknessToOrdinaryMortar(ulong entityKey, SicknessSpawnWindow window)
    {
        ArgumentNullException.ThrowIfNull(window);
        if (phase != BattlePhase.Running || !activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.UnitId != "ID_UNIT-MORTAR" || entity.SourceCardId.Length != 0)
        {
            return false;
        }

        // EnemyController sets Walk before AfterSpawned; Walk and its later Mortar state
        // both pass canBeFreezed. This binding is only called for the ordinary spawn event.
        var target = new SicknessSpawnTarget(entity.OwnerFraction, true, true);
        if (!window.ShouldAffect(target))
        {
            return false;
        }

        ArmyMortarRuntime weapon = _ordinaryMortarWeapons.GetValueOrDefault(entityKey) ??
            throw new InvalidDataException("Ordinary Mortar lost its current weapon authority.");
        if (weapon.DirectDamage > MaximumSicknessWeaponDamage ||
            weapon.ExplosionDamage > MaximumSicknessWeaponDamage ||
            !float.IsFinite(weapon.StopTime) || weapon.StopTime <= 0f ||
            !armyDamage.TryGetValue(entityKey, out float explosion) || explosion != weapon.ExplosionDamage)
        {
            throw new InvalidDataException("Ordinary Mortar weapon and explosion authority disagree.");
        }

        var missile = new ArmyCardRocketRuntime(weapon.DirectDamage, weapon.ExplosionDamage,
            weapon.Speed, weapon.PlayerBehindShieldRatio);
        ArmyCardRocketRuntime changed = window.ApplyRocketDamage(target, missile);
        ApplyPrimaryWeaponSicknessAuthority(entityKey, window, target);
        _ordinaryMortarWeapons[entityKey] = weapon with { DirectDamage = changed.DirectDamage };
        return true;
    }
}
