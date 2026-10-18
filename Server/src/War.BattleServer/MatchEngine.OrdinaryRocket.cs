using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    /// <summary>Initializes ordinary missiles before source spawn observers can modify their damage.</summary>
    private void InitializeOrdinaryRocket(ulong entityKey)
    {
        if (armyCatalog == null || !activeArmyEntities.TryGetValue(entityKey, out BattleArmyEntityState? entity) ||
            !IsRocketSoldier(entity) || entity.SourceCardId.Length != 0)
        {
            throw new InvalidDataException("Ordinary Rocket Soldier lost its spawn identity.");
        }

        ParticipantManifest owner = Find(entity.OwnerPlayerId)?.Definition ??
            throw new InvalidDataException("Ordinary Rocket Soldier lost its admitted owner.");
        int equipmentIndex = Array.IndexOf(owner.EquippedArmyUnitIds!, entity.UnitId);
        if (equipmentIndex < 0 || owner.ArmyNormalUpgradeIndexes == null || owner.ArmyDamageScales == null ||
            !armyShots.ContainsKey(entityKey) || !armyDamage.ContainsKey(entityKey))
        {
            throw new InvalidDataException("Ordinary Rocket Soldier lacks admitted upgrade authority.");
        }

        int specialIndex = owner.ArmySpecialUpgradeIndexes?[equipmentIndex] ?? -1;
        int eliteIndex = owner.ArmyEliteUpgradeIndexes?[equipmentIndex] ?? -1;
        ArmyCardRocketRuntime missile = armyCatalog.ComposeOrdinaryRocket(
            owner.ArmyNormalUpgradeIndexes[equipmentIndex], specialIndex >= 0 ? specialIndex : null,
            eliteIndex >= 0 ? eliteIndex : null, owner.ArmyDamageScales[equipmentIndex]);
        cardRocketMissiles.Add(entityKey, missile);
        TryAssignCardRocketPoint(entity);
    }

    private ArmyBaseShotStats ReadRocketShotStats(BattleArmyEntityState entity)
    {
        if (entity.SourceCardId.Length == 0)
        {
            return armyShots.GetValueOrDefault(entity.EntityKey) ??
                throw new InvalidDataException("Ordinary Rocket Soldier lost its composed shot authority.");
        }

        CardUnitEntity source = cardUnitEntities.Find(entity.LocalEntityId) ??
            throw new InvalidDataException("Card Rocket Soldier lost its card shot row.");
        if (source.EntityKey != entity.EntityKey || source.SourceCardId != "BIGROCKET")
        {
            throw new InvalidDataException("Card Rocket Soldier shot provenance disagrees.");
        }

        return source.BaseStats.Shot;
    }

    private void RemoveOrdinaryRocket(ulong entityKey)
    {
        cardRocketMissiles.Remove(entityKey);
        rocketPointRetryTicks.Remove(entityKey);
        rocketWalks.Remove(entityKey);
        rocketAttacks.Remove(entityKey);
        rocketShotTargets.Remove(entityKey);
        rocketShotIntents.RemoveAll(intent => intent.EntityKey == entityKey);
        cardEnemyPoints?.Release(entityKey);
        // Launched missiles retain their frozen authority and finish independently of the dead soldier.
    }

    private static bool IsRocketSoldier(BattleArmyEntityState entity)
    {
        return entity.UnitId == "ID_UNIT-ROCKETSOLDIER" && entity.SourceCardId is "" or "BIGROCKET";
    }
}
