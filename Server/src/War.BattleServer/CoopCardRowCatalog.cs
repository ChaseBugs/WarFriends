using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopCardRows(
    string UnitId, string SheetRow, int MinimumIndex,
    int MaximumIndex, bool HasCardRows);

/// <summary>
/// The scene's rowNames supply indexes absent from the numeric sheet export.
/// Its pinned artifact also records the Client's row-zero fallback for sheets
/// without CARDS_MIN/MAX labels.
/// </summary>
public sealed class CoopCardRowCatalog
{
    public const string Revision =
        "4ff393135eac2d8b94be50b9400c02924317bed25e8752cffc7afb96cc6af249";

    private static readonly HashSet<string> ExpectedUnits = new(StringComparer.Ordinal)
    {
        "ID_UNIT-ASSAULT", "ID_UNIT-SNIPER", "ID_UNIT-ROCKETSOLDIER",
        "ID_UNIT-DRONE", "ID_UNIT-GRENADIER", "ID_UNIT-PARATROOPER",
        "ID_UNIT-SWAT", "ID_UNIT-MINIGUNNER"
    };

    private readonly ArmyDeploymentCatalog army;
    private readonly IReadOnlyDictionary<string, CoopCardRows> rows;

    private CoopCardRowCatalog(
        ArmyDeploymentCatalog army, IReadOnlyDictionary<string, CoopCardRows> rows)
    {
        this.army = army;
        this.rows = rows;
    }

    public ArmyBaseCombatStats Stats(string unitId, float progress, bool heroic = false)
    {
        if (!rows.TryGetValue(unitId, out CoopCardRows? cardRows))
            throw new InvalidDataException("Unit has no recovered co-op card row rule.");
        return army.CoopCardStats(unitId, cardRows.MinimumIndex,
            cardRows.MaximumIndex, progress, heroic);
    }

    public ArmyBaseShotStats Shot(string unitId, float progress)
    {
        if (!rows.TryGetValue(unitId, out CoopCardRows? cardRows))
            throw new InvalidDataException("Unit has no recovered co-op card row rule.");
        return army.ComposeCardShot(unitId, cardRows.MinimumIndex,
            cardRows.MaximumIndex, progress);
    }

    public static CoopCardRowCatalog Load(string path, MissionCatalog missions,
        ArmyDeploymentCatalog army, string contentRevision)
    {
        byte[] bytes = File.ReadAllBytes(path);
        if (bytes.Length is < 100 or > 4096 ||
            Convert.ToHexStringLower(SHA256.HashData(bytes)) != Revision)
            throw new InvalidDataException("Unreviewed co-op card row artifact.");
        using var document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "sceneSha256", "armySha256",
            "contentSha256", "rows");
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("sceneSha256").GetString() != missions.SourceSha256 ||
            root.GetProperty("armySha256").GetString() != army.Revision ||
            root.GetProperty("contentSha256").GetString() != contentRevision)
            throw new InvalidDataException("Co-op card rows differ from source authority.");

        JsonElement entries = root.GetProperty("rows");
        if (entries.ValueKind != JsonValueKind.Array ||
            entries.GetArrayLength() != ExpectedUnits.Count)
            throw new InvalidDataException("Co-op card row set is incomplete.");
        var mapped = new Dictionary<string, CoopCardRows>(StringComparer.Ordinal);
        var families = army.Families.ToDictionary(
            family => family.UnitId, StringComparer.Ordinal);
        foreach (JsonElement entry in entries.EnumerateArray())
        {
            RequireFields(entry, "unitId", "sheetRow", "minimumIndex",
                "maximumIndex", "hasCardRows");
            string unitId = entry.GetProperty("unitId").GetString() ?? "";
            string sheetRow = entry.GetProperty("sheetRow").GetString() ?? "";
            int minimum = entry.GetProperty("minimumIndex").GetInt32();
            int maximum = entry.GetProperty("maximumIndex").GetInt32();
            bool hasNamedRows = entry.GetProperty("hasCardRows").GetBoolean();
            if (!ExpectedUnits.Contains(unitId) || mapped.ContainsKey(unitId) ||
                !families.TryGetValue(unitId, out ArmyDeploymentFamily? family) ||
                family.SheetRow != sheetRow ||
                (hasNamedRows ? minimum <= 0 || maximum != minimum + 1 :
                    minimum != 0 || maximum != 0))
                throw new InvalidDataException("Invalid co-op card row identity.");
            _ = army.CoopCardStats(unitId, minimum, maximum, 0, false);
            _ = army.CoopCardStats(unitId, minimum, maximum, 1, true);
            if (family.IsSoldier)
            {
                _ = army.ComposeCardShot(unitId, minimum, maximum, 0);
                _ = army.ComposeCardShot(unitId, minimum, maximum, 1);
            }
            mapped.Add(unitId, new CoopCardRows(
                unitId, sheetRow, minimum, maximum, hasNamedRows));
        }
        return new CoopCardRowCatalog(army, mapped);
    }

    private static void RequireFields(JsonElement entry, params string[] fields)
    {
        if (entry.ValueKind != JsonValueKind.Object)
            throw new InvalidDataException("Co-op card row record must be an object.");
        var required = new HashSet<string>(fields, StringComparer.Ordinal);
        foreach (JsonProperty property in entry.EnumerateObject())
        {
            if (!required.Remove(property.Name))
                throw new InvalidDataException("Co-op card row has an extra or repeated field.");
        }
        if (required.Count != 0)
            throw new InvalidDataException("Co-op card row is missing a field.");
    }
}
