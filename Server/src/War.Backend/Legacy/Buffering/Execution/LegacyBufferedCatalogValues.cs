using System.Text.Json.Nodes;
using War.Backend.Legacy.Catalog;

namespace War.Backend.Legacy.Buffering;

internal static class LegacyBufferedCatalogValues
{
    /// <summary>A sheet-row numeric field, tolerant of the JSON number being written as an integer
    /// or a double. Internal (not private): also used by <c>LegacyCraftingEndpoint</c>.</summary>
    internal static long RowLong(JsonObject row, string field) =>
        row[field]?.AsValue().TryGetValue(out double value) == true ? (long)value : 0;

    internal static int RowInt(JsonObject row, string field) => (int)RowLong(row, field);

    internal static string? RowString(JsonObject row, string field) => row[field]?.GetValue<string>();

    internal static long RowLong(LegacyCatalogRow row, string field) =>
        (row[field] ?? throw new InvalidDataException("Required catalog integer is absent: " + field)).GetValue<long>();

    internal static int RowInt(LegacyCatalogRow row, string field) =>
        (row[field] ?? throw new InvalidDataException("Required catalog integer is absent: " + field)).GetValue<int>();

    internal static string? RowString(LegacyCatalogRow row, string field) => row[field]?.GetValue<string>();
}
