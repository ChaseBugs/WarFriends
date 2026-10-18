using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.Backend;

/// <summary>Separates recovered persisted LevelManager indexes from battle allWeapons indexes.</summary>
public static class BattleClientWeaponIndices
{
    private const int ExpectedWeaponCount = 66;
    private const int MaximumInventoryIndex = 66;
    private const int UnmappedInventoryIndex = 20;
    private const string ResourceName = "War.Backend.RecoveredPlayerWeaponIndexes";
    private const string ReviewedSha256 = "adcd85fe32936e52d85a7d45bce982b7c58a94ec4b353b749ad00d07eaf3fa34";
    private const string ObservationSha256 = "7e4d56b6dbbfdc832fe65c1a3320c15d4b9c7b80750d7e6ba36f4d45ccb923c5";
    private const string MainSceneSha256 = "5b159bba5105203cd2a771385a110e63820a840d232e6a027b52b577604495ff";
    private const string CombatBindingsSha256 = "2b8e0b531a6bf46bac199218bc74440938f8d535000565eb197a2384aae7daaa";
    private static readonly IReadOnlyDictionary<string, Mapping> Mappings = LoadReviewedMap();

    /// <summary>Checks the embedded identity map during startup, before handling account or battle requests.</summary>
    public static void Validate()
    {
        if (Mappings.Count != ExpectedWeaponCount)
        {
            throw new InvalidDataException("The recovered weapon index map is incomplete.");
        }
    }

    /// <summary>Checks membership without interpreting the source identity as ownership.</summary>
    public static bool IsKnownSource(string sourceId)
    {
        return !string.IsNullOrEmpty(sourceId) && Mappings.ContainsKey(sourceId);
    }

    /// <summary>Resolves a persisted source identity and LevelManager index into the battle inventory index.</summary>
    public static int ResolveInventoryIndex(string sourceId, int levelManagerIndex)
    {
        if (string.IsNullOrEmpty(sourceId) || !Mappings.TryGetValue(sourceId, out Mapping? row) ||
            row.LevelManagerIndex != levelManagerIndex)
        {
            throw new InvalidDataException("The persisted weapon index does not match its recovered source identity.");
        }
        return row.InventoryIndex;
    }

    /// <summary>Resolves a battle inventory identity into the corresponding persisted LevelManager index.</summary>
    public static int ResolveLevelManagerIndex(string sourceId, int inventoryIndex)
    {
        if (string.IsNullOrEmpty(sourceId) || !Mappings.TryGetValue(sourceId, out Mapping? row) ||
            row.InventoryIndex != inventoryIndex)
        {
            throw new InvalidDataException("The battle weapon index does not match its recovered source identity.");
        }
        return row.LevelManagerIndex;
    }

    private static IReadOnlyDictionary<string, Mapping> LoadReviewedMap()
    {
        using Stream input = typeof(BattleClientWeaponIndices).Assembly.GetManifestResourceStream(ResourceName)
            ?? throw new InvalidDataException("The recovered weapon index resource is missing.");
        using var buffer = new MemoryStream();
        input.CopyTo(buffer);
        byte[] bytes = buffer.ToArray();
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedSha256)
        {
            throw new InvalidDataException("The recovered weapon index resource digest differs from the reviewed map.");
        }
        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        ValidateProvenance(root);
        return ReadMappings(root.GetProperty("mappings"));
    }

    private static void ValidateProvenance(JsonElement root)
    {
        ExactFields(root, "schemaVersion", "clientVersion", "observationSha256", "mainSceneSha256",
            "combatBindingsSha256", "mappings");
        if (root.GetProperty("schemaVersion").GetInt32() != 1 ||
            root.GetProperty("clientVersion").GetString() != "1.4.0" ||
            root.GetProperty("observationSha256").GetString() != ObservationSha256 ||
            root.GetProperty("mainSceneSha256").GetString() != MainSceneSha256 ||
            root.GetProperty("combatBindingsSha256").GetString() != CombatBindingsSha256)
        {
            throw new InvalidDataException("The recovered weapon index map has unsupported provenance.");
        }
    }

    private static IReadOnlyDictionary<string, Mapping> ReadMappings(JsonElement entries)
    {
        if (entries.ValueKind != JsonValueKind.Array || entries.GetArrayLength() != ExpectedWeaponCount)
        {
            throw new InvalidDataException("The recovered weapon index map has an invalid row count.");
        }
        var result = new Dictionary<string, Mapping>(StringComparer.Ordinal);
        var inventoryIndexes = new HashSet<int>();
        int expectedLevelIndex = 0;
        foreach (JsonElement entry in entries.EnumerateArray())
        {
            ExactFields(entry, "sourceId", "levelManagerIndex", "inventoryIndex");
            string? sourceId = entry.GetProperty("sourceId").GetString();
            int levelIndex = entry.GetProperty("levelManagerIndex").GetInt32();
            int inventoryIndex = entry.GetProperty("inventoryIndex").GetInt32();
            if (string.IsNullOrEmpty(sourceId) || sourceId.Length > 64 || sourceId.Any(char.IsControl) ||
                !sourceId.StartsWith("Google2u.", StringComparison.Ordinal) ||
                levelIndex != expectedLevelIndex || inventoryIndex < 0 || inventoryIndex > MaximumInventoryIndex ||
                inventoryIndex == UnmappedInventoryIndex ||
                !inventoryIndexes.Add(inventoryIndex) ||
                !result.TryAdd(sourceId, new Mapping(levelIndex, inventoryIndex)))
            {
                throw new InvalidDataException("The recovered weapon index map has duplicate or invalid authority.");
            }
            expectedLevelIndex++;
        }
        return new ReadOnlyDictionary<string, Mapping>(result);
    }

    private static void ExactFields(JsonElement value, params string[] expected)
    {
        if (value.ValueKind != JsonValueKind.Object || !value.EnumerateObject().Select(field => field.Name)
            .OrderBy(name => name, StringComparer.Ordinal)
            .SequenceEqual(expected.OrderBy(name => name, StringComparer.Ordinal)))
        {
            throw new InvalidDataException("The recovered weapon index map has unknown or missing fields.");
        }
    }

    private sealed record Mapping(int LevelManagerIndex, int InventoryIndex);
}
