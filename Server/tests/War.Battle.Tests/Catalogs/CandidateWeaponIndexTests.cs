using System.Security.Cryptography;
using System.Text.Json;
using War.Backend;

namespace War.Battle.Tests.Catalogs;

internal static class CandidateWeaponIndexTests
{
    internal static void Run(string directory)
    {
        byte[] bindings = File.ReadAllBytes(Path.Combine(directory, "recovered-all-weapon-bindings.json"));
        using var document = JsonDocument.Parse(
            File.ReadAllBytes(Path.Combine(directory, "recovered-player-weapon-indexes.json")));
        JsonElement source = document.RootElement;
        if (source.GetProperty("combatBindingsSha256").GetString() != Convert.ToHexStringLower(SHA256.HashData(bindings)))
        {
            throw new InvalidDataException("Weapon indexes do not bind their candidate combat graph.");
        }

        JsonElement mappings = source.GetProperty("mappings");
        if (mappings.GetArrayLength() != 66)
        {
            throw new InvalidDataException("Candidate weapon mapping is incomplete.");
        }

        var identities = new HashSet<string>(StringComparer.Ordinal);
        int expectedOrder = 0;
        foreach (JsonElement mapping in mappings.EnumerateArray())
        {
            string sourceId = mapping.GetProperty("sourceId").GetString()!;
            int levelIndex = mapping.GetProperty("levelManagerIndex").GetInt32();
            int inventoryIndex = mapping.GetProperty("inventoryIndex").GetInt32();
            if (!identities.Add(sourceId) || levelIndex != expectedOrder++ ||
                BattleClientWeaponIndices.ResolveInventoryIndex(sourceId, levelIndex) != inventoryIndex ||
                BattleClientWeaponIndices.ResolveLevelManagerIndex(sourceId, inventoryIndex) != levelIndex)
            {
                throw new InvalidDataException("Candidate weapon mapping differs from Backend projection authority.");
            }
        }
    }
}
