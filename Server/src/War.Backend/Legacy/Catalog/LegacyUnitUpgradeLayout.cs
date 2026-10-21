namespace War.Backend.Legacy.Catalog;

/// <summary>Binds the source's contiguous normal/special/Elite lanes and explicitly trailing padding.</summary>
internal static class LegacyUnitUpgradeLayout
{
    internal static LegacyUpgradeTrack Build(LegacyCatalogRow item, IReadOnlyList<LegacyCatalogRow> rows)
    {
        var lanes = new[] { new List<LegacyCatalogRow>(), new List<LegacyCatalogRow>(), new List<LegacyCatalogRow>() };
        int previousTier = -1;
        bool hasPadding = false;
        foreach (LegacyCatalogRow row in rows)
        {
            int tier = row["TIER"]!.Value.GetValue<int>();
            if (tier == -1)
            {
                hasPadding = true;
                continue;
            }

            if (hasPadding || tier < previousTier || tier is < 0 or > 29 ||
                tier / 10 == 0 && tier % 10 > 5 || tier / 10 == 1 && tier % 10 > 6)
            {
                throw new InvalidDataException("Unit upgrade lanes are invalid, unordered or split by padding.");
            }

            lanes[tier / 10].Add(row);
            previousTier = tier;
        }

        ValidateOffsets(item, lanes);
        return new LegacyUpgradeTrack(new LegacyUpgradeTrackDefinition
        {
            Identity = item["NAME"]!.Value.GetValue<string>(),
            Kind = LegacyCatalogItemKind.Unit,
            StartingTier = item["STARTINGTIER"]!.Value.GetValue<int>(),
            IsEliteEnabled = item["STARTINGELITE"]!.Value.GetValue<int>() > 0,
            Rows = rows,
            NormalRows = lanes[0].AsReadOnly(),
            SpecialRows = lanes[1].AsReadOnly(),
            EliteRows = lanes[2].AsReadOnly()
        });
    }

    private static void ValidateOffsets(LegacyCatalogRow item, List<LegacyCatalogRow>[] lanes)
    {
        int startingTier = item["STARTINGTIER"]!.Value.GetValue<int>();
        int eliteStart = item["STARTINGELITE"]!.Value.GetValue<int>();
        if (startingTier is < 1 or > 6 || lanes[0].Count == 0 ||
            lanes[0][0]["TIER"]!.Value.GetValue<int>() != startingTier - 1 ||
            item["STARTINGSPECIAL"]?.GetValue<int>() != lanes[0].Count ||
            eliteStart != -1 && (eliteStart != lanes[0].Count + lanes[1].Count || lanes[2].Count == 0))
        {
            throw new InvalidDataException("Unit base identity disagrees with its upgrade-lane offsets.");
        }
    }
}
