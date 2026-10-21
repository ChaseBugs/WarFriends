using System.Collections.Frozen;

namespace War.Backend.Legacy.Catalog;

/// <summary>Binds priced upgrade rows to base-item identities without treating helper combat rows as economy.</summary>
internal static class LegacyCatalogUpgradeBindings
{
    internal static FrozenDictionary<string, LegacyUpgradeTrack> Create(LegacyCatalog catalog)
    {
        var seen = new HashSet<string>(StringComparer.Ordinal);
        var priced = new Dictionary<string, LegacyUpgradeTrack>(StringComparer.Ordinal);
        foreach (string type in new[] { "Google2u.WeaponUpgrades", "Google2u.ArmyUpgrades" })
        {
            bool isUnit = type == "Google2u.ArmyUpgrades";
            foreach (LegacyCatalogRow item in catalog.Sheet(type))
            {
                string identity = item["NAME"]!.Value.GetValue<string>();
                if (!seen.Add(identity))
                {
                    throw new InvalidDataException("One catalog identity belongs to multiple item kinds.");
                }

                // The three recovered starting-tier-zero turret helpers have combat rows without upgrade prices.
                if (isUnit && item["STARTINGTIER"]!.Value.GetValue<int>() == 0)
                {
                    continue;
                }

                IReadOnlyList<LegacyCatalogRow> rows = catalog.Sheet(identity);
                foreach (LegacyCatalogRow row in rows)
                {
                    ValidateStage(row, isUnit);
                }

                if (rows.Count != 0)
                {
                    LegacyUpgradeTrack track = isUnit
                        ? LegacyUnitUpgradeLayout.Build(item, rows)
                        : BuildWeapon(identity, rows);
                    priced.Add(identity, track);
                }
            }
        }

        return priced.ToFrozenDictionary(StringComparer.Ordinal);
    }

    private static LegacyUpgradeTrack BuildWeapon(string identity, IReadOnlyList<LegacyCatalogRow> rows)
    {
        if (rows.Count < 2 || rows.Any(row => row.ContainsKey("TIER")))
        {
            throw new InvalidDataException(
                "Weapon upgrades need their source state/extra rows and cannot have unit tiers.");
        }

        return new LegacyUpgradeTrack(new LegacyUpgradeTrackDefinition
        {
            Identity = identity,
            Kind = LegacyCatalogItemKind.Weapon,
            Rows = rows,
            NormalRows = rows
        });
    }

    private static void ValidateStage(LegacyCatalogRow row, bool isUnit)
    {
        foreach (string field in new[] { "NEXTUPGRADEPRICE", "NEXTUPGRADEPRICEGOLD", "DELIVERYTIME" })
        {
            if (row[field]?.GetValue<int>() is not >= 0)
            {
                throw new InvalidDataException("Linked upgrade stage lacks a valid price or duration.");
            }
        }

        if (isUnit && row["TIER"]?.GetValue<int>() == null)
        {
            throw new InvalidDataException("Player unit upgrade stage lacks its source track identity.");
        }
    }
}
