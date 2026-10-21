namespace War.BattleServer;

public sealed partial class ArmyDeploymentCatalog
{
    private const string GrenadierUnitId = "ID_UNIT-GRENADIER";
    private const float OrdinaryGrenadierFuseSeconds = 3f;
    private const float MaximumGrenadierDamage = 10_000_000f;

    /// <summary>Composes ordinary grenade fields from bought lanes, then applies trusted mode damage scaling.</summary>
    public (ArmyGrenadeDamageStats Damage, float FuseSeconds) ComposeOrdinaryGrenadier(
        int normalIndex, int? specialIndex, int? eliteIndex, float damageScale)
    {
        // Reuse the normal/special/Elite lane proof before indexing grenade-only columns.
        _ = EffectiveDamage(GrenadierUnitId, normalIndex, specialIndex, eliteIndex, damageScale);
        IReadOnlyList<ArmyGrenadeDamageStats> stages = grenadierDamageStages ??
            throw new InvalidDataException("Ordinary Grenadier damage rows are unavailable.");
        float minimum = stages[normalIndex].Minimum;
        float explosion = stages[normalIndex].Explosion;
        if (specialIndex.HasValue)
        {
            minimum += stages[specialIndex.Value].Minimum;
            explosion += stages[specialIndex.Value].Explosion;
        }

        if (eliteIndex.HasValue)
        {
            minimum += stages[eliteIndex.Value].Minimum;
            explosion += stages[eliteIndex.Value].Explosion;
        }

        // Only card interpolation truncates these fields. Ordinary LoadDefinitionFromXLS adds floats.
        minimum *= damageScale;
        explosion *= damageScale;
        if (!float.IsFinite(minimum) || minimum < 0 || minimum > MaximumGrenadierDamage ||
            !float.IsFinite(explosion) || explosion < 0 || explosion > MaximumGrenadierDamage)
        {
            throw new InvalidDataException("Ordinary Grenadier damage exceeds the host combat domain.");
        }

        float fuseSeconds = OrdinaryGrenadierFuseSeconds;
        if (specialIndex.HasValue)
        {
            float special = ComposeSpecial(GrenadierUnitId, normalIndex, specialIndex, eliteIndex);
            fuseSeconds -= OrdinaryGrenadierFuseSeconds * special;
        }

        if (!float.IsFinite(fuseSeconds) || fuseSeconds < 0 || fuseSeconds > OrdinaryGrenadierFuseSeconds)
        {
            throw new InvalidDataException("Ordinary Grenadier special fuse is invalid.");
        }

        return (new ArmyGrenadeDamageStats(minimum, explosion), fuseSeconds);
    }
}
