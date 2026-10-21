namespace War.Backend.Legacy.Catalog;

/// <summary>Owns validated ordered lanes and the recovered Client's next-upgrade boundaries.</summary>
public sealed class LegacyUpgradeTrack
{
    private const int MaximumUnitTier = 6;
    private readonly int[] _maximumNormalByTier = new int[MaximumUnitTier + 1];

    internal LegacyUpgradeTrack(LegacyUpgradeTrackDefinition definition)
    {
        Identity = definition.Identity;
        Kind = definition.Kind;
        StartingTier = definition.StartingTier;
        IsEliteEnabled = definition.IsEliteEnabled;
        Rows = definition.Rows;
        NormalRows = definition.NormalRows;
        SpecialRows = definition.SpecialRows;
        EliteRows = definition.EliteRows;
        if (Kind == LegacyCatalogItemKind.Weapon)
        {
            return;
        }

        for (int tier = 1; tier <= MaximumUnitTier; tier++)
        {
            int count = NormalRows.Count(row => row["TIER"]?.GetValue<int>() % 10 < tier);
            _maximumNormalByTier[tier] = Math.Max(0, count - 1);
        }
    }

    public string Identity { get; }
    public LegacyCatalogItemKind Kind { get; }
    public int StartingTier { get; }
    public bool IsEliteEnabled { get; }
    public IReadOnlyList<LegacyCatalogRow> Rows { get; }
    public IReadOnlyList<LegacyCatalogRow> NormalRows { get; }
    public IReadOnlyList<LegacyCatalogRow> SpecialRows { get; }
    public IReadOnlyList<LegacyCatalogRow> EliteRows { get; }

    /// <summary>The weapon Client reserves an extra row; unit lanes retain their last state row.</summary>
    public int MaximumNormalIndex => Kind == LegacyCatalogItemKind.Weapon ? NormalRows.Count - 2 : NormalRows.Count - 1;

    public bool CanUpgradeNormal(int currentIndex, int tier = 0)
    {
        if (currentIndex < 0)
        {
            return false;
        }

        if (Kind == LegacyCatalogItemKind.Weapon)
        {
            // WeaponLevelsSetup.CanUpgrade: (Rows.Count - 1) > (boughtIndex + 1).
            return currentIndex < MaximumNormalIndex;
        }

        int currentTier = tier == 0 ? StartingTier : tier;
        return currentTier >= StartingTier && currentTier <= MaximumUnitTier && currentTier > 0 &&
            currentIndex < _maximumNormalByTier[currentTier];
    }

    public bool CanUpgradeElite(int currentIndex) =>
        IsEliteEnabled && currentIndex >= 0 && currentIndex < EliteRows.Count - 1;
}
