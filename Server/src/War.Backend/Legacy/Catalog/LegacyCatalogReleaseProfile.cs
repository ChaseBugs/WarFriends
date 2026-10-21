using System.Text.Json;

namespace War.Backend.Legacy.Catalog;

/// <summary>Checks configured source releases against the compiled, reviewed Client schema/snapshot profile.</summary>
internal static class LegacyCatalogReleaseProfile
{
    private const string ResourceName = "War.Backend.LegacyCatalogProfile";

    internal static void Validate(LegacyCatalog catalog)
    {
        using Stream stream = typeof(LegacyCatalogReleaseProfile).Assembly.GetManifestResourceStream(ResourceName)
            ?? throw new InvalidDataException("The reviewed catalog release profile is missing.");
        using JsonDocument document = JsonDocument.Parse(stream);
        JsonElement profile = document.RootElement;
        JsonElement sheets = profile.GetProperty("sheets");
        if (catalog.SheetTypes.Count != sheets.GetArrayLength())
        {
            throw new InvalidDataException("Configured catalog contains an incomplete or unknown sheet set.");
        }

        foreach (JsonElement sheet in sheets.EnumerateArray())
        {
            ValidateSheet(catalog, sheet);
        }

        LegacyCatalogSource source = catalog.Source!;
        if (source.Client != profile.GetProperty("client").GetString() ||
            source.UnityExportVersion != profile.GetProperty("exportUnityLabel").GetString() ||
            source.MainSceneSha256 != profile.GetProperty("claimedMainSceneSha256").GetString() ||
            source.ContentSha256 != profile.GetProperty("artifactSha256").GetString())
        {
            throw new InvalidDataException("Configured catalog does not match the reviewed source snapshot.");
        }
    }

    private static void ValidateSheet(LegacyCatalog catalog, JsonElement sheet)
    {
        string type = sheet.GetProperty("type").GetString()!;
        IReadOnlyList<LegacyCatalogRow> rows = catalog.Sheet(type);
        if (!catalog.SheetTypes.Contains(type) || rows.Count != sheet.GetProperty("exportedRows").GetInt32())
        {
            throw new InvalidDataException("Configured sheet row count disagrees with its recovered source.");
        }

        JsonElement fields = sheet.GetProperty("fields");
        string? identity = sheet.GetProperty("identityField").GetString();
        JsonElement orderedIdentities = sheet.GetProperty("orderedIdentities");
        for (int index = 0; index < rows.Count; index++)
        {
            LegacyCatalogRow row = rows[index];
            if (row.Fields.Count() != fields.EnumerateObject().Count())
            {
                throw new InvalidDataException("Configured row field set differs from the recovered row class.");
            }

            foreach (JsonProperty field in fields.EnumerateObject())
            {
                LegacyCatalogValue value = row[field.Name]
                    ?? throw new InvalidDataException("Configured row lacks a recovered source field.");
                ValidateCell(value, field.Value.GetString()!);
            }

            if (identity != null && row[identity]!.Value.GetValue<string>() != orderedIdentities[index].GetString())
            {
                throw new InvalidDataException("Configured row identity/order differs from the reviewed source.");
            }
        }
    }

    private static void ValidateCell(LegacyCatalogValue value, string type)
    {
        switch (type)
        {
            case "int32":
                _ = value.GetValue<int>();
                break;
            case "int64":
                _ = value.GetValue<long>();
                break;
            case "string":
                _ = value.GetValue<string>();
                break;
            case "boolean":
                _ = value.GetValue<bool>();
                break;
            case "float32":
                double number = value.GetValue<double>();
                float converted = (float)number;
                if (!float.IsFinite(converted) || number != 0 && converted == 0)
                {
                    throw new InvalidDataException("Configured source float exceeds its recovered binary32 domain.");
                }
                break;
            default:
                throw new InvalidDataException("Unsupported reviewed catalog field type.");
        }
    }
}
