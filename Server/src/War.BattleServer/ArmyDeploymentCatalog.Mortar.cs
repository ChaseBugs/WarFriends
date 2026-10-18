namespace War.BattleServer;

public sealed partial class ArmyDeploymentCatalog
{
    private const string MortarUnitId = "ID_UNIT-MORTAR";
    private const float MortarDirectDamageRatio = 0.1f;
    private const float MortarMissileSpeed = 20f;

    /// <summary>Reproduces Mortar contact, explosion and reciprocal perk-scaled stop time.</summary>
    public ArmyMortarRuntime ComposeOrdinaryMortar(ArmyMortarSelection selection)
    {
        ArgumentNullException.ThrowIfNull(selection);
        float damage = EffectiveDamage(MortarUnitId, selection.NormalIndex, selection.SpecialIndex,
            selection.EliteIndex, selection.DamageScale);
        // UpgradeSlotsGeneric.LoadData replaces the serialized shotSpeed with ArmyUpgrades.BULLETSPEED.
        // Soldier lane loading preserves it; ScaleByPerk applies the owner's coefficient exactly once.
        float shotSpeed = EffectiveInfantryBulletSpeed(MortarUnitId, selection.ShotSpeedCoefficient);
        float stopTime = 1f / shotSpeed;
        if (!float.IsFinite(stopTime) || stopTime <= 0f)
        {
            throw new InvalidDataException("Ordinary Mortar stop time is outside host bounds.");
        }

        return new ArmyMortarRuntime(damage * MortarDirectDamageRatio, damage, MortarMissileSpeed,
            stopTime, PlayerDamagePolicy(MortarUnitId).BehindShieldRatio);
    }
}
