namespace War.Backend.Legacy.Catalog;

/// <summary>Internal construction data published only after complete lane validation.</summary>
internal sealed record LegacyUpgradeTrackDefinition
{
    internal required string Identity { get; init; }
    internal required LegacyCatalogItemKind Kind { get; init; }
    internal int StartingTier { get; init; }
    internal bool IsEliteEnabled { get; init; }
    internal required IReadOnlyList<LegacyCatalogRow> Rows { get; init; }
    internal required IReadOnlyList<LegacyCatalogRow> NormalRows { get; init; }
    internal IReadOnlyList<LegacyCatalogRow> SpecialRows { get; init; } = Array.Empty<LegacyCatalogRow>();
    internal IReadOnlyList<LegacyCatalogRow> EliteRows { get; init; } = Array.Empty<LegacyCatalogRow>();
}
