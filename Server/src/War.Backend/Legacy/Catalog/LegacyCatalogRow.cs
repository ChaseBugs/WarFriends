using System.Collections.Frozen;
using System.Text.Json;

namespace War.Backend.Legacy.Catalog;

/// <summary>Owns immutable JSON storage and an ordinal field index for one validated source row.</summary>
public sealed class LegacyCatalogRow
{
    private readonly JsonElement _json;
    private readonly FrozenDictionary<string, LegacyCatalogValue> _fields;

    internal LegacyCatalogRow(JsonElement row)
    {
        _json = row.Clone();
        var fields = new Dictionary<string, LegacyCatalogValue>(StringComparer.Ordinal);
        foreach (JsonProperty field in _json.EnumerateObject())
        {
            if (!fields.TryAdd(field.Name, new LegacyCatalogValue(field.Value)))
            {
                throw new InvalidDataException("Duplicate catalog row field: " + field.Name);
            }
        }

        _fields = fields.ToFrozenDictionary(StringComparer.Ordinal);
    }

    public LegacyCatalogValue? this[string field] => _fields.TryGetValue(field, out var value) ? value : null;

    public bool ContainsKey(string field) => _fields.ContainsKey(field);

    public string ToJsonString() => _json.GetRawText();

    internal IEnumerable<KeyValuePair<string, LegacyCatalogValue>> Fields => _fields;
}
