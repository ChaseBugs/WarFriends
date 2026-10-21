using System.Text.Json;
using War.Backend.Legacy.Catalog;

namespace War.Backend.Legacy.Accounts;

/// <summary>Reads bounded starting authority from the immutable constant identity index.</summary>
internal static class LegacyStarterConstants
{
    internal static long Read(LegacyCatalog catalog, string key, long maximum)
    {
        LegacyCatalogRow? row = catalog.Row("Google2u.Constants", "DBKEY", key);
        if (row?["FLOATVALUE"] is not LegacyCatalogValue value || value.GetValueKind() != JsonValueKind.Number ||
            value.ToJsonString().StartsWith('-'))
        {
            throw new InvalidDataException("Missing or invalid nonnegative source starter integer: " + key);
        }

        long result = value.GetValue<long>();
        if (result < 0 || result > maximum)
        {
            throw new InvalidDataException("Source starter integer exceeds its domain: " + key);
        }

        return result;
    }
}
