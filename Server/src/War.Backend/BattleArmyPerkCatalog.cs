using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

using War.BattleServer;
using War.Shared;

namespace War.Backend;

/// <summary>Calculates source-ordered army perks from validated equipped unit stages on both sides.</summary>
public sealed class BattleArmyPerkCatalog
{
    private const string ExpectedRevision = "b9597a7c47a00e1ff07a0dc2006f3c885f20b8733dc14636490cf9b15924ce35";
    private const int ExpectedFamilies = 24;
    private const int MaximumSourceBytes = 131072;
    private const float MaximumCoefficient = 100f;
    private readonly Row[] orderedRows;
    private readonly IReadOnlyDictionary<string, Row> rowsBySheet;
    private readonly string deploymentRevision;
    private readonly string sourceTableRevision;

    /// <summary>Gets the immutable source snapshot embedded in this Backend build.</summary>
    public static BattleArmyPerkCatalog Recovered { get; } = LoadRecovered();

    private BattleArmyPerkCatalog(Row[] rows, string revision, string tableRevision)
    {
        orderedRows = rows;
        rowsBySheet = new ReadOnlyDictionary<string, Row>(rows.ToDictionary(row => row.Sheet, StringComparer.Ordinal));
        deploymentRevision = revision;
        sourceTableRevision = tableRevision;
    }

    /// <summary>Rejects changed source bytes before parsing or exposing a recipe.</summary>
    public static BattleArmyPerkCatalog Parse(byte[] bytes)
    {
        if (bytes == null || bytes.Length is < 1 or > MaximumSourceBytes)
        {
            throw new InvalidDataException("Recovered army perk size is invalid.");
        }
        byte[] snapshot = bytes.ToArray();
        if (Convert.ToHexStringLower(SHA256.HashData(snapshot)) != ExpectedRevision)
        {
            throw new InvalidDataException("Recovered army perk revision mismatch.");
        }
        using JsonDocument document = JsonDocument.Parse(snapshot);
        JsonElement root = document.RootElement;
        Row[] rows = root.GetProperty("families").EnumerateArray().Select(ReadRow).ToArray();
        if (rows.Length != ExpectedFamilies || rows.Select(row => row.UnitId).Distinct().Count() != ExpectedFamilies ||
            !rows.Select(row => row.Order).SequenceEqual(Enumerable.Range(0, ExpectedFamilies)))
        {
            throw new InvalidDataException("Recovered army perk ordering is incomplete.");
        }
        string revision = root.GetProperty("sources").EnumerateArray().Single(source =>
            source.GetProperty("path").GetString() == "Server/content/recovered-army-deployment.json")
            .GetProperty("sha256").GetString()!;
        string tableRevision = root.GetProperty("sources").EnumerateArray().Single(source =>
            source.GetProperty("path").GetString() == "Server/content/recovered-battle-content.json")
            .GetProperty("sha256").GetString()!;
        return new BattleArmyPerkCatalog(rows, revision, tableRevision);
    }

    /// <summary>
    /// Applies equipped ally buffs followed by equipped opponent debuffs without changing either input.
    /// </summary>
    public IReadOnlyDictionary<string, Factors> Calculate(ArmyDeploymentCatalog army,
        BattlePlayerPresentation owner, BattlePlayerPresentation opponent)
    {
        owner = BattlePlayerPresentation.Validate(owner);
        opponent = BattlePlayerPresentation.Validate(opponent);
        if (owner.PlayerId == opponent.PlayerId)
        {
            throw new InvalidDataException("Army perk participants must be distinct.");
        }
        ValidateSource(army);
        Dictionary<string, BattleUnitPresentation> ownUnits = ValidateUnits(army, owner.Units);
        Dictionary<string, BattleUnitPresentation> opposingUnits = ValidateUnits(army, opponent.Units);
        var result = new Dictionary<string, Factors>(StringComparer.Ordinal);
        foreach (BattleUnitPresentation target in owner.Units)
        {
            Row row = rowsBySheet[target.SourceId];
            Factors factors = ApplySide(row.UnitId, ownUnits, PerkSide.Ally, Factors.Identity);
            factors = ApplySide(row.UnitId, opposingUnits, PerkSide.Opponent, factors);
            RequireValidFactors(factors);
            result.Add(row.UnitId, factors);
        }
        return new ReadOnlyDictionary<string, Factors>(result);
    }

    /// <summary>
    /// Rejects unvalidated or different deployment/source tables before matchmaking can publish factors.
    /// </summary>
    public void ValidateSource(ArmyDeploymentCatalog army)
    {
        ArgumentNullException.ThrowIfNull(army);
        if (army.Revision != deploymentRevision || army.SourceSheetRevision != sourceTableRevision)
        {
            throw new InvalidDataException("Army perk recipes differ from the validated combat source package.");
        }
        ValidateFamilies(army);
    }

    private void ValidateFamilies(ArmyDeploymentCatalog army)
    {
        if (army.Families.Count != ExpectedFamilies || orderedRows.Any(row =>
            !army.Families.Any(family => family.UnitId == row.UnitId && family.SheetRow == row.Sheet)))
        {
            throw new InvalidDataException("Army perk identities differ from deployment authority.");
        }
    }

    private Dictionary<string, BattleUnitPresentation> ValidateUnits(ArmyDeploymentCatalog army,
        IReadOnlyList<BattleUnitPresentation> units)
    {
        var result = new Dictionary<string, BattleUnitPresentation>(StringComparer.Ordinal);
        foreach (BattleUnitPresentation unit in units)
        {
            if (!rowsBySheet.TryGetValue(unit.SourceId, out Row? row))
            {
                throw new InvalidDataException("Equipped perk unit has no recovered identity.");
            }
            // An ELITE column is not proof that this unit has an available elite upgrade lane.
            _ = army.ComposeStats(row.UnitId, unit.UpgradeIndex,
                unit.SpecialIndex >= 0 ? unit.SpecialIndex : null, unit.EliteIndex >= 0 ? unit.EliteIndex : null);
            if (unit.EliteIndex >= 0 && row.Coefficient != "none" && unit.EliteIndex >= row.EliteValues.Length)
            {
                throw new InvalidDataException("Equipped perk stage is outside its source column.");
            }
            result.Add(unit.SourceId, unit);
        }
        return result;
    }

    private Factors ApplySide(string targetId, IReadOnlyDictionary<string, BattleUnitPresentation> units,
        PerkSide side, Factors current)
    {
        foreach (Row row in orderedRows)
        {
            if (row.IsAlly != (side == PerkSide.Ally) || row.Coefficient == "none" || !row.Targets.Contains(targetId) ||
                !units.TryGetValue(row.Sheet, out BattleUnitPresentation? unit) || unit.EliteIndex < 0)
            {
                continue;
            }
            float value = row.EliteValues[unit.EliteIndex];
            float multiplier = row.IsAddition ? 1f + value : 1f - value;
            // PerkImplementation returns its new multiplier * currentPerk, with binary32 stores at each step.
            current = Multiply(current, row.Coefficient, multiplier) with
            {
                BuffCount = checked(current.BuffCount + (row.CountKind == "buffCount" ? 1 : 0)),
                DebuffCount = checked(current.DebuffCount + (row.CountKind == "debuffCount" ? 1 : 0))
            };
        }
        return current;
    }

    private static Factors Multiply(Factors current, string coefficient, float multiplier)
    {
        return coefficient switch
        {
            "hpCoef" => current with { Health = multiplier * current.Health },
            "accuracyCoef" => current with { Accuracy = multiplier * current.Accuracy },
            "shotSpeedCoef" => current with { ShotSpeed = multiplier * current.ShotSpeed },
            "speedCoef" => current with { Speed = multiplier * current.Speed },
            _ => throw new InvalidDataException("Recovered perk coefficient is unsupported.")
        };
    }

    private static void RequireValidFactors(Factors factors)
    {
        foreach (float coefficient in new[] { factors.Health, factors.Accuracy, factors.ShotSpeed, factors.Speed })
        {
            if (!float.IsFinite(coefficient) || coefficient <= 0f || coefficient > MaximumCoefficient)
            {
                throw new InvalidDataException("Combined army perk coefficient exceeds combat bounds.");
            }
        }
    }

    private static Row ReadRow(JsonElement row)
    {
        JsonElement recipe = row.GetProperty("recipe");
        return new Row(row.GetProperty("unitId").GetString()!, row.GetProperty("sheet").GetString()!,
            row.GetProperty("levelManagerIndex").GetInt32(), recipe.GetProperty("coefficient").GetString()!,
            recipe.GetProperty("operation").GetString() == "+", row.GetProperty("faction").GetString() == "ally",
            recipe.GetProperty("countKind").GetString()!,
            row.GetProperty("affectedUnitIds").EnumerateArray().Select(value => value.GetString()!)
                .ToHashSet(StringComparer.Ordinal),
            row.GetProperty("eliteColumn").EnumerateArray().Select(value => value.GetSingle()).ToArray());
    }

    private static BattleArmyPerkCatalog LoadRecovered()
    {
        using Stream stream = typeof(BattleArmyPerkCatalog).Assembly
            .GetManifestResourceStream("War.Backend.RecoveredArmyPerks")
            ?? throw new InvalidDataException("Recovered army perk resource is missing.");
        using var buffer = new MemoryStream();
        stream.CopyTo(buffer);
        return Parse(buffer.ToArray());
    }

    /// <summary>Contains source coefficients and presentation counts; it does not confer unit ownership.</summary>
    public readonly record struct Factors(float Health, float Accuracy, float ShotSpeed, float Speed,
        int BuffCount, int DebuffCount)
    {
        internal static Factors Identity => new(1f, 1f, 1f, 1f, 0, 0);
    }

    private sealed record Row(string UnitId, string Sheet, int Order, string Coefficient, bool IsAddition,
        bool IsAlly, string CountKind, HashSet<string> Targets, float[] EliteValues);

    private enum PerkSide
    {
        Ally,
        Opponent
    }
}
