namespace War.BattleServer;

public sealed partial class ArmyDeploymentCatalog
{
    private const string RocketSoldierUnitId = "ID_UNIT-ROCKETSOLDIER";
    private const float RocketDirectDamageRatio = 0.1f;
    private const float RocketBaseSpeed = 3f;

    /// <summary>Builds ordinary Bazooka setup from the admitted owner's upgrade lanes and mode scale.</summary>
    public ArmyCardRocketRuntime ComposeOrdinaryRocket(
        int normalIndex, int? specialIndex, int? eliteIndex, float damageScale)
    {
        float damage = EffectiveDamage(RocketSoldierUnitId, normalIndex, specialIndex, eliteIndex, damageScale);
        float speed = RocketBaseSpeed;
        if (specialIndex.HasValue)
        {
            float special = ComposeSpecial(RocketSoldierUnitId, normalIndex, specialIndex, eliteIndex);
            speed *= 1f + special;
        }

        // SoldierBehaviourBazooka configures contact and explosion fields separately.
        // Only a selected special lane enables its speed branch; card spawns never have that lane.
        if (!float.IsFinite(speed) || speed <= 0f || speed > CardRocketMissileFlight.MaximumSpeed)
        {
            throw new InvalidDataException("Ordinary Rocket Soldier speed is outside host bounds.");
        }

        return new ArmyCardRocketRuntime(damage * RocketDirectDamageRatio, damage, speed,
            PlayerDamagePolicy(RocketSoldierUnitId).BehindShieldRatio);
    }
}
