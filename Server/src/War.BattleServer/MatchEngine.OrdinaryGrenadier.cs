using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    /// <summary>Binds ordinary spawn weapons to admitted owner upgrades, never to card interpolation.</summary>
    private void InitializeOrdinaryGrenadier(ulong entityKey)
    {
        if (armyCatalog == null || !activeArmyEntities.TryGetValue(entityKey, out BattleArmyEntityState? entity) ||
            entity.UnitId != "ID_UNIT-GRENADIER" || entity.SourceCardId.Length != 0)
        {
            throw new InvalidDataException("Ordinary Grenadier lost its spawn identity.");
        }

        ParticipantManifest owner = Find(entity.OwnerPlayerId)?.Definition ??
            throw new InvalidDataException("Ordinary Grenadier owner left the match.");
        int equipmentIndex = Array.IndexOf(owner.EquippedArmyUnitIds!, entity.UnitId);
        if (equipmentIndex < 0 || owner.ArmyNormalUpgradeIndexes == null || owner.ArmyDamageScales == null ||
            !armyDamage.ContainsKey(entityKey) || !armyShots.ContainsKey(entityKey))
        {
            throw new InvalidDataException("Ordinary Grenadier lacks admitted weapon authority.");
        }

        int specialIndex = owner.ArmySpecialUpgradeIndexes?[equipmentIndex] ?? -1;
        int eliteIndex = owner.ArmyEliteUpgradeIndexes?[equipmentIndex] ?? -1;
        var composed = armyCatalog.ComposeOrdinaryGrenadier(owner.ArmyNormalUpgradeIndexes[equipmentIndex],
            specialIndex >= 0 ? specialIndex : null, eliteIndex >= 0 ? eliteIndex : null,
            owner.ArmyDamageScales[equipmentIndex]);
        ArmyCardGrenadierRuntime recoveredWeapon = armyCatalog.ComposeGrenadierRuntime(composed.FuseSeconds);

        // Both source variants use GrenadeEnemy. Only the ordinary special lane changes its fuse here.
        // Navigation and attack admission remain separate until their card-only source guards are migrated.
        cardGrenadierThrows.Add(entityKey, recoveredWeapon);
        _cardGrenadierDamage.Add(entityKey, composed.Damage);
    }
}
