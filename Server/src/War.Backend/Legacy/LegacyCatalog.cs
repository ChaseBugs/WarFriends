using System.Collections.Frozen;
using System.Text;
using War.Backend.Legacy.Catalog;

namespace War.Backend.Legacy;

/// <summary>Owns immutable source rows, validated numeric cells and explicit ordinal identity indexes.</summary>
/// <remarks>
/// LoadConfigured is the host startup boundary. Parse/Load also support small partial catalogs for
/// pure use cases; missing entries remain absent, and every supplied consumed row must validate.
/// Source metadata records export claims, not proof that the current Unity scene matches that export.
/// </remarks>
public sealed class LegacyCatalog
{
    private static readonly UTF8Encoding StrictUtf8 = new(false, true);
    private readonly FrozenDictionary<string, LegacyCatalogSheet> _sheets;
    private readonly FrozenDictionary<string, LegacyCatalogValue> _constants;
    private readonly FrozenDictionary<string, LegacyUpgradeTrack> _upgradeTracks;

    internal LegacyCatalog(Dictionary<string, LegacyCatalogSheet> sheets, LegacyCatalogSource? source)
    {
        _sheets = sheets.ToFrozenDictionary(StringComparer.Ordinal);
        Source = source;
        var constants = new Dictionary<string, LegacyCatalogValue>(StringComparer.Ordinal);
        foreach (LegacyCatalogRow row in Sheet("Google2u.Constants"))
        {
            constants.Add(row["DBKEY"]!.Value.GetValue<string>(), row["FLOATVALUE"]!.Value);
        }

        _constants = constants.ToFrozenDictionary(StringComparer.Ordinal);
        _upgradeTracks = LegacyCatalogUpgradeBindings.Create(this);
    }

    public static LegacyCatalog Empty { get; } = new([], null);

    public bool IsLoaded => _sheets.Count != 0;

    public LegacyCatalogSource? Source { get; }

    internal IReadOnlyCollection<string> SheetTypes => _sheets.Keys;

    /// <summary>Only an omitted path selects compatibility mode; configured damage fails before traffic.</summary>
    public static LegacyCatalog LoadConfigured(string? path)
    {
        if (path == null)
        {
            return Empty;
        }

        return ValidateConfigured(Load(path));
    }

    /// <summary>Validates a complete configured release in memory using the same host startup boundary.</summary>
    public static LegacyCatalog ParseConfigured(string json) => ValidateConfigured(Parse(json));

    private static LegacyCatalog ValidateConfigured(LegacyCatalog catalog)
    {
        if (!catalog.IsLoaded || catalog.Source == null)
        {
            throw new InvalidDataException("Configured catalog needs nonempty source data and provenance metadata.");
        }

        LegacyCatalogDependencies.Validate(catalog);
        LegacyCatalogReleaseProfile.Validate(catalog);

        return catalog;
    }

    /// <summary>Reads one bounded file and validates every row before publishing its immutable snapshot.</summary>
    public static LegacyCatalog Load(string path)
    {
        using FileStream stream = File.OpenRead(path);
        if (stream.Length > LegacyCatalogReader.MaximumContentBytes)
        {
            throw new InvalidDataException("Catalog file exceeds its resource bound.");
        }

        var bytes = new byte[(int)stream.Length];
        stream.ReadExactly(bytes);
        if (stream.ReadByte() != -1)
        {
            throw new InvalidDataException("Catalog file grew while being read.");
        }

        return LegacyCatalogReader.Read(bytes);
    }

    /// <summary>Parses bounded UTF-8 source text through the same validation used by file loading.</summary>
    public static LegacyCatalog Parse(string json)
    {
        if (json.Length > LegacyCatalogReader.MaximumContentBytes)
        {
            throw new InvalidDataException("Catalog text exceeds its resource bound.");
        }

        return LegacyCatalogReader.Read(StrictUtf8.GetBytes(json));
    }

    public double? Constant(string key) => _constants.TryGetValue(key, out var value) ? value.GetValue<double>() : null;

    public int? ConstantInt(string key) => _constants.TryGetValue(key, out var value) ? value.GetValue<int>() : null;

    public IReadOnlyList<LegacyCatalogRow> Sheet(string type) =>
        _sheets.TryGetValue(type, out LegacyCatalogSheet? sheet) ? sheet.Rows : Array.Empty<LegacyCatalogRow>();

    public LegacyCatalogRow? Row(string type, string identityField, string identity) =>
        _sheets.TryGetValue(type, out LegacyCatalogSheet? sheet) ? sheet.Find(identityField, identity) : null;

    /// <summary>Only base-catalog item identities may select upgrade-row authority.</summary>
    public IReadOnlyList<LegacyCatalogRow> UpgradeStages(string identity) =>
        _upgradeTracks.TryGetValue(identity, out LegacyUpgradeTrack? track) ? track.Rows : Array.Empty<LegacyCatalogRow>();

    public LegacyUpgradeTrack? WeaponUpgrades(string identity) =>
        FindUpgradeTrack(identity, LegacyCatalogItemKind.Weapon);

    public LegacyUpgradeTrack? UnitUpgrades(string identity) => FindUpgradeTrack(identity, LegacyCatalogItemKind.Unit);

    /// <summary>Retains helper source rows for audit while refusing them as player purchases or promotions.</summary>
    public LegacyCatalogRow? PlayerUnit(string identity)
    {
        LegacyCatalogRow? row = Row("Google2u.ArmyUpgrades", "NAME", identity);
        return row?["STARTINGTIER"]?.GetValue<int>() is >= 1 and <= 6 ? row : null;
    }

    private LegacyUpgradeTrack? FindUpgradeTrack(string identity, LegacyCatalogItemKind kind) =>
        _upgradeTracks.TryGetValue(identity, out LegacyUpgradeTrack? track) && track.Kind == kind ? track : null;
}
