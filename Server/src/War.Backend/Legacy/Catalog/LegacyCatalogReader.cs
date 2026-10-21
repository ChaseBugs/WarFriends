using System.Security.Cryptography;
using System.Text.Json;

namespace War.Backend.Legacy.Catalog;

/// <summary>Builds a complete immutable catalog or rejects the input without publishing a partial table.</summary>
internal static class LegacyCatalogReader
{
    internal const int MaximumContentBytes = 32 * 1024 * 1024;
    private const int MaximumSheets = 512;
    private const int MaximumRowsPerSheet = 16_384;
    private const int MaximumTotalRows = 100_000;
    private const int MaximumObjectFields = 256;

    internal static LegacyCatalog Read(ReadOnlyMemory<byte> bytes)
    {
        if (bytes.Length > MaximumContentBytes)
        {
            throw new InvalidDataException("Catalog content exceeds the configured resource bound.");
        }

        bool hasUtf8Bom = bytes.Span.StartsWith(new byte[] { 0xef, 0xbb, 0xbf });
        ReadOnlyMemory<byte> documentBytes = hasUtf8Bom ? bytes[3..] : bytes;
        using JsonDocument document = JsonDocument.Parse(documentBytes);
        JsonElement root = document.RootElement;
        RequireUniqueObject(root);
        if (!root.TryGetProperty("sheets", out JsonElement sheets) || sheets.ValueKind != JsonValueKind.Array ||
            sheets.GetArrayLength() > MaximumSheets)
        {
            throw new InvalidDataException("Invalid catalog sheet envelope.");
        }

        var byType = new Dictionary<string, LegacyCatalogSheet>(StringComparer.Ordinal);
        int totalRows = 0;
        foreach (JsonElement sheet in sheets.EnumerateArray())
        {
            RequireUniqueObject(sheet);
            if (!sheet.TryGetProperty("type", out JsonElement typeValue) || typeValue.ValueKind != JsonValueKind.String)
            {
                throw new InvalidDataException("Catalog sheet has no typed identity.");
            }

            string type = typeValue.GetString()!;
            if (type.Length is < 1 or > 256 || type.Any(char.IsWhiteSpace) || type.Any(char.IsControl) ||
                byType.ContainsKey(type))
            {
                throw new InvalidDataException("Duplicate or damaged catalog sheet identity.");
            }

            List<LegacyCatalogRow> rows = ReadRows(sheet, type);
            totalRows = checked(totalRows + rows.Count);
            if (totalRows > MaximumTotalRows)
            {
                throw new InvalidDataException("Catalog row count exceeds its resource bound.");
            }

            byType.Add(type, new LegacyCatalogSheet(type, rows));
        }

        string digest = Convert.ToHexStringLower(SHA256.HashData(bytes.Span));
        return new LegacyCatalog(byType, LegacyCatalogSource.Read(root, digest));
    }

    private static List<LegacyCatalogRow> ReadRows(JsonElement sheet, string type)
    {
        if (!sheet.TryGetProperty("rows", out JsonElement values) || values.ValueKind != JsonValueKind.Array ||
            values.GetArrayLength() > MaximumRowsPerSheet)
        {
            throw new InvalidDataException("Invalid catalog row envelope.");
        }

        var rows = new List<LegacyCatalogRow>(values.GetArrayLength());
        foreach (JsonElement value in values.EnumerateArray())
        {
            RequireUniqueObject(value);
            var row = new LegacyCatalogRow(value);
            LegacyCatalogValidation.Validate(type, row);
            rows.Add(row);
        }

        return rows;
    }

    private static void RequireUniqueObject(JsonElement value)
    {
        if (value.ValueKind != JsonValueKind.Object)
        {
            throw new InvalidDataException("Catalog objects cannot be replaced with another JSON type.");
        }

        var fields = new HashSet<string>(StringComparer.Ordinal);
        foreach (JsonProperty field in value.EnumerateObject())
        {
            if (fields.Count >= MaximumObjectFields || !fields.Add(field.Name))
            {
                throw new InvalidDataException("Duplicate catalog envelope or row property.");
            }
        }
    }
}
