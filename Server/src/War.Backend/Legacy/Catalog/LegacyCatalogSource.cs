using System.Text.Json;

namespace War.Backend.Legacy.Catalog;

/// <summary>Records export claims and exact bytes; current Unity scene agreement is a separate audit.</summary>
public sealed record LegacyCatalogSource(
    string Client, string UnityExportVersion, string MainSceneSha256, string ContentSha256)
{
    internal static LegacyCatalogSource? Read(JsonElement root, string contentSha256)
    {
        bool hasMetadata = root.TryGetProperty("client", out _) || root.TryGetProperty("unity", out _) ||
            root.TryGetProperty("mainSceneSha256", out _);
        if (!hasMetadata)
        {
            return null;
        }

        string client = ReadString(root, "client");
        string unity = ReadString(root, "unity");
        string sceneDigest = ReadString(root, "mainSceneSha256");
        if (client != "1.4.0" || unity.Length is < 1 or > 64 || unity.Any(char.IsControl) ||
            sceneDigest.Length != 64 || sceneDigest.Any(character => !char.IsAsciiHexDigitLower(character)))
        {
            throw new InvalidDataException("Invalid recovered catalog provenance identity.");
        }

        return new LegacyCatalogSource(client, unity, sceneDigest, contentSha256);
    }

    private static string ReadString(JsonElement root, string field)
    {
        if (!root.TryGetProperty(field, out JsonElement value) || value.ValueKind != JsonValueKind.String)
        {
            throw new InvalidDataException("Incomplete recovered catalog provenance.");
        }

        return value.GetString()!;
    }
}
