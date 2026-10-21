using System.Text.Json;

namespace War.BattleServer;

public sealed partial class ArmyDeploymentCatalog
{
    private const string MortarUnitId = "ID_UNIT-MORTAR";
    private const float MortarDirectDamageRatio = 0.1f;
    private const float MortarMissileSpeed = 20f;
    private const float MaximumMortarBuildTime = 180f;
    private const int MortarSourceStageCount = 33;
    private IReadOnlyList<float>? _mortarBuildTimes;

    /// <summary>Loads construction time from the same admitted lanes as health and damage.</summary>
    public float ComposeMortarBuildTime(ArmyMortarSelection selection)
    {
        ArgumentNullException.ThrowIfNull(selection);
        _ = ComposeStats(MortarUnitId, selection.NormalIndex, selection.SpecialIndex, selection.EliteIndex);
        IReadOnlyList<float> times = _mortarBuildTimes ??
            throw new InvalidDataException("Mortar construction rows are unavailable.");
        float seconds = times[selection.NormalIndex];
        if (selection.SpecialIndex.HasValue)
        {
            seconds += times[selection.SpecialIndex.Value];
        }
        if (selection.EliteIndex.HasValue)
        {
            seconds += times[selection.EliteIndex.Value];
        }
        if (!float.IsFinite(seconds) || seconds < 0f || seconds > MaximumMortarBuildTime)
        {
            throw new InvalidDataException("Composed Mortar construction time is outside source bounds.");
        }

        return seconds;
    }

    private static IReadOnlyList<float> ReadMortarBuildTimes(JsonElement sheet)
    {
        float[] times = sheet.GetProperty("rows").EnumerateArray()
            .Select(row => row.GetProperty("MORTARBUILDTIME").GetSingle()).ToArray();
        if (times.Length != MortarSourceStageCount || times.Any(seconds => !float.IsFinite(seconds) ||
            seconds < 0f || seconds > MaximumMortarBuildTime))
        {
            throw new InvalidDataException("Mortar construction rows are incomplete or malformed.");
        }

        return Array.AsReadOnly(times);
    }

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
