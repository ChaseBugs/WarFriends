using System.Text.Json;
using System.Text.Json.Nodes;
using War.BattleServer;
using War.Shared;

namespace War.Backend;

/// <summary>Binds presentation-ordered unit identities and upgrade lanes to the recovered army catalog.</summary>
internal static class BattleArmyManifestProjection
{
    private static readonly string[] LaneFields =
    ["EquippedArmyUnitIds", "ArmyNormalUpgradeIndexes", "ArmySpecialUpgradeIndexes", "ArmyEliteUpgradeIndexes"];

    internal static JsonObject Build(ArmyDeploymentCatalog catalog, IReadOnlyList<BattleUnitPresentation> units)
    {
        var identities = new List<string>();
        foreach (BattleUnitPresentation unit in units)
        {
            ArmyDeploymentFamily? family = catalog.Families.SingleOrDefault(row => row.SheetRow == unit.SourceId);
            if (family == null)
            {
                throw new InvalidDataException("The equipped unit has no recovered army deployment identity.");
            }

            ValidateCombatStages(catalog, family.UnitId, unit);
            identities.Add(family.UnitId);
        }

        if (units.Count == 0)
        {
            return new JsonObject();
        }

        // GameControllerOnline echoes local.Units in presentation order, not the full LevelManager list.
        return new JsonObject
        {
            ["EquippedArmyUnitIds"] = JsonSerializer.SerializeToNode(identities),
            ["ArmyNormalUpgradeIndexes"] = JsonSerializer.SerializeToNode(units.Select(unit => unit.UpgradeIndex)),
            ["ArmySpecialUpgradeIndexes"] = JsonSerializer.SerializeToNode(units.Select(unit => unit.SpecialIndex)),
            ["ArmyEliteUpgradeIndexes"] = JsonSerializer.SerializeToNode(units.Select(unit => unit.EliteIndex))
        };
    }

    internal static void RequireRefreshableAuthority(JsonObject participant)
    {
        bool hasUnprojectedModifiers = participant.Any(field => field.Value != null &&
            ((field.Key.StartsWith("Army", StringComparison.Ordinal) && !LaneFields.Contains(field.Key)) ||
                field.Key == "NewArmyUnitIds"));
        if (hasUnprojectedModifiers)
        {
            throw new InvalidDataException("Army modifiers and new-unit flags need a durable projection builder.");
        }
    }

    internal static void Apply(JsonObject participant, JsonObject fields)
    {
        foreach (string field in LaneFields)
        {
            participant.Remove(field);
        }
        foreach (var field in fields)
        {
            participant[field.Key] = field.Value?.DeepClone();
        }
    }

    private static void ValidateCombatStages(ArmyDeploymentCatalog catalog, string unitId, BattleUnitPresentation unit)
    {
        try
        {
            catalog.ComposeStats(unitId, unit.UpgradeIndex,
                unit.SpecialIndex >= 0 ? unit.SpecialIndex : null,
                unit.EliteIndex >= 0 ? unit.EliteIndex : null);
        }
        catch (ArgumentOutOfRangeException exception)
        {
            throw new InvalidDataException("The equipped unit stages do not match recovered combat rows.", exception);
        }
    }
}
