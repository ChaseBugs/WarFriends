using System.Collections.Frozen;
using System.Collections.ObjectModel;

namespace War.Backend.Legacy.Catalog;

/// <summary>Keeps source row order and exposes only explicitly owned, unique identity indexes.</summary>
internal sealed class LegacyCatalogSheet
{
    private readonly ReadOnlyCollection<LegacyCatalogRow> _rows;
    private readonly FrozenDictionary<string, LegacyCatalogRow> _identity;
    private readonly string? _identityField;

    internal LegacyCatalogSheet(string type, List<LegacyCatalogRow> rows)
    {
        _rows = rows.AsReadOnly();
        _identityField = LegacyCatalogValidation.IdentityField(type);
        var identity = new Dictionary<string, LegacyCatalogRow>(StringComparer.Ordinal);
        if (_identityField != null)
        {
            foreach (LegacyCatalogRow row in rows)
            {
                string? key = row[_identityField]?.GetValue<string>();
                if (string.IsNullOrWhiteSpace(key) || key.Length > 256 || key.Any(char.IsControl) ||
                    !identity.TryAdd(key, row))
                {
                    throw new InvalidDataException("Missing, damaged or duplicate catalog identity in " + type);
                }
            }
        }

        _identity = identity.ToFrozenDictionary(StringComparer.Ordinal);
    }

    internal IReadOnlyList<LegacyCatalogRow> Rows => _rows;

    internal LegacyCatalogRow? Find(string field, string identity)
    {
        if (field != _identityField)
        {
            // Packs and bots have source-backed duplicate NAME rows. They cannot become arbitrary First() authority.
            throw new InvalidDataException("Catalog identity lookup has no reviewed unique index.");
        }

        return _identity.GetValueOrDefault(identity);
    }
}
