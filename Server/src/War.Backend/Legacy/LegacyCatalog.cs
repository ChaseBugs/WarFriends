using System.Text.Json;
using System.Text.Json.Nodes;

namespace War.Backend.Legacy;

/// <summary>
/// Loads the recovered Google2u sheet data — the client's economy/balance catalog — and exposes
/// typed lookups.
/// </summary>
/// <remarks>
/// <para><b>Source and provenance.</b> The Google2u row <em>schema</em> classes are fully recovered
/// as C# source under
/// <c>Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Google2u/*Row.cs</c> (e.g.
/// <c>WeaponUpgradesRow</c>) — an earlier pass of this work searched only
/// <c>Assets/Scripts</c> and wrongly concluded they were missing. The row <em>data</em> — actual
/// prices, unlock levels, balance constants — was separately exported by the Battle Server effort's
/// <c>SelfHostedBattleExport.Run</c> Unity Editor tool into
/// <c>Server/content/recovered-battle-content.json</c>'s <c>sheets</c> array: 132 sheet instances,
/// each <c>{ "type": "Google2u.&lt;Name&gt;", "path": "&lt;scene GameObject path&gt;", "rows": [...] }</c>,
/// with row field names matching the recovered row classes exactly (all-caps: <c>PRICE</c>,
/// <c>PRICEGOLD</c>, <c>DBKEY</c>, …). This loader reads that JSON directly rather than depending on
/// a Unity-only assembly, so any field used here can be cross-checked against the recovered row
/// class source at any time.</para>
/// <para><b>This is a read-only reference catalog, not authoritative game balance.</b>
/// <c>content/README.md</c> is explicit: "Source sheet rows are not yet a validated combat catalog
/// and must not authorize purchases or rewards" — that caveat was written for the Battle Server's
/// use of the same file for combat. For Backend economy actions (shop purchases, rewards), the
/// values here are the same numbers <c>ServerResponseHandler</c>'s original PHP counterpart would
/// have priced against, so they are the correct source to build shop pricing from — but each new
/// consumer should still cross-check its specific row shape against the row class before trusting
/// a field.</para>
/// <para><b>Missing file is not an error.</b> Unset <c>Legacy:ContentPath</c> or a missing file
/// leaves the catalog empty; callers that need a specific entry get <c>null</c> and must fail
/// closed (return <c>ServerMaintenance</c>), exactly as they did before this loader existed.</para>
/// </remarks>
public sealed class LegacyCatalog
{
    private readonly Dictionary<string, IReadOnlyList<JsonObject>> sheetsByType;

    /// <summary>The GameVariables/Constants sheet, indexed by <c>DBKEY</c> for direct lookup.</summary>
    private readonly Dictionary<string, double> constants;

    private LegacyCatalog(Dictionary<string, IReadOnlyList<JsonObject>> sheetsByType, Dictionary<string, double> constants)
    {
        this.sheetsByType = sheetsByType;
        this.constants = constants;
    }

    /// <summary>An empty catalog: every lookup returns null/false. Used when no content path is configured.</summary>
    public static LegacyCatalog Empty { get; } = new([], []);

    public bool IsLoaded => sheetsByType.Count > 0;

    /// <summary>
    /// Loads from the exported content JSON. Throws on a malformed file — a configured path is an
    /// explicit operator choice, so a bad file should fail startup loudly rather than silently
    /// leave every priced action refusing forever.
    /// </summary>
    public static LegacyCatalog Load(string path)
    {
        using var stream = File.OpenRead(path);
        var root = JsonNode.Parse(stream) as JsonObject
            ?? throw new InvalidDataException($"'{path}' is not a JSON object.");
        if (root["sheets"] is not JsonArray sheets)
            throw new InvalidDataException($"'{path}' has no top-level 'sheets' array.");

        var byType = new Dictionary<string, IReadOnlyList<JsonObject>>(StringComparer.Ordinal);
        foreach (var entry in sheets)
        {
            if (entry is not JsonObject sheet) continue;
            string? type = sheet["type"]?.GetValue<string>();
            if (string.IsNullOrEmpty(type) || sheet["rows"] is not JsonArray rows) continue;
            var rowList = rows.OfType<JsonObject>().ToList();
            // The exporter guarantees unique types (verified against the current export: 132
            // sheets, 132 distinct type strings). A duplicate is unexpected content drift, not a
            // reason to silently drop half the data — merge rather than overwrite.
            if (byType.TryGetValue(type, out var existing)) rowList.InsertRange(0, existing);
            byType[type] = rowList;
        }

        var constants = new Dictionary<string, double>(StringComparer.Ordinal);
        if (byType.TryGetValue("Google2u.Constants", out var constantRows))
        {
            foreach (var row in constantRows)
            {
                string? key = row["DBKEY"]?.GetValue<string>();
                if (key != null && row["FLOATVALUE"] != null && row["FLOATVALUE"]!.AsValue().TryGetValue(out double value))
                    constants[key] = value;
            }
        }

        return new LegacyCatalog(byType, constants);
    }

    /// <summary>
    /// A GameVariables constant by its <c>Constants.rowIds</c> name (e.g. <c>"SecondRenameGoldCost"</c>,
    /// <c>"StartingGold"</c>). Null if the catalog is empty or the key does not exist — never a
    /// default value, since a wrong default here is a fabricated game-balance number.
    /// </summary>
    public double? Constant(string dbKey) => constants.TryGetValue(dbKey, out double value) ? value : null;

    /// <summary>Convenience for a constant that is conceptually an integer (levels, counts, caps).</summary>
    public int? ConstantInt(string dbKey) => Constant(dbKey) is double value ? (int)value : null;

    /// <summary>All rows of one sheet type (e.g. <c>"Google2u.WeaponUpgrades"</c>), or empty if absent.</summary>
    public IReadOnlyList<JsonObject> Sheet(string type) => sheetsByType.GetValueOrDefault(type, []);

    /// <summary>
    /// One row of a sheet matched by a string field (most sheets key rows by <c>NAME</c>;
    /// <c>Constants</c> uses <c>DBKEY</c>). Null if the sheet or the row is absent.
    /// </summary>
    public JsonObject? Row(string type, string keyField, string keyValue) =>
        Sheet(type).FirstOrDefault(row => string.Equals(row[keyField]?.GetValue<string>(), keyValue, StringComparison.Ordinal));
}
