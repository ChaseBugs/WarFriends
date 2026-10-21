using War.Backend.Legacy;
using War.Backend.Legacy.Catalog;
using War.LegacyContract.Tests.Recovered;

namespace War.LegacyContract.Tests;

internal static class UpgradeTrackRulesTests
{
    internal static void Run()
    {
        LegacyCatalog catalog = RecoveredCatalogFixture.Catalog;
        foreach (LegacyCatalogRow weapon in catalog.Sheet("Google2u.WeaponUpgrades"))
        {
            string name = weapon["NAME"]!.Value.GetValue<string>();
            LegacyUpgradeTrack track = catalog.WeaponUpgrades(name)!;
            foreach (int index in new[] { 0, track.MaximumNormalIndex - 1, track.MaximumNormalIndex,
                track.MaximumNormalIndex + 1 })
            {
                Require(track.CanUpgradeNormal(index) ==
                    RecoveredUpgradeOracle.WeaponCanUpgrade(track.Rows.Count, index),
                    "Weapon boundary differs: " + name);
            }

            Require(catalog.UnitUpgrades(name) == null, "Weapon rows became unit upgrade authority.");
        }

        int players = 0;
        int helpers = 0;
        foreach (LegacyCatalogRow unit in catalog.Sheet("Google2u.ArmyUpgrades"))
        {
            string name = unit["NAME"]!.Value.GetValue<string>();
            if (unit["STARTINGTIER"]!.Value.GetValue<int>() == 0)
            {
                Require(catalog.PlayerUnit(name) == null && catalog.UnitUpgrades(name) == null &&
                    catalog.Sheet(name).Count > 0, "Helper rows were admitted or removed from source evidence.");
                helpers++;
                continue;
            }

            LegacyUpgradeTrack track = catalog.UnitUpgrades(name)!;
            Require(catalog.PlayerUnit(name) == unit && catalog.WeaponUpgrades(name) == null,
                "Player unit kind/identity was lost.");
            CheckUnit(track, unit);
            players++;
        }

        Require(players == 24 && helpers == 3, "Active 1.4.0 player/helper roster changed without review.");
    }

    private static void CheckUnit(LegacyUpgradeTrack track, LegacyCatalogRow unit)
    {
        int[] tiers = track.Rows.Select(row => row["TIER"]!.Value.GetValue<int>()).ToArray();
        for (int tier = track.StartingTier; tier <= 6; tier++)
        {
            int eligibleRows = track.NormalRows.Count(row => row["TIER"]!.Value.GetValue<int>() % 10 < tier);
            int tierMaximum = Math.Max(0, eligibleRows - 1);
            foreach (int index in new[] { 0, Math.Max(0, tierMaximum - 1), tierMaximum,
                Math.Min(track.MaximumNormalIndex, tierMaximum + 1), track.MaximumNormalIndex })
            {
                bool expected = RecoveredUpgradeOracle.UnitCanUpgrade(tiers, tier, index);
                Require(track.CanUpgradeNormal(index, tier) == expected, "Unit boundary differs: " + track.Identity);
            }
        }

        int[] eliteIndexes = [0, Math.Max(0, track.EliteRows.Count - 2), Math.Max(0, track.EliteRows.Count - 1)];
        foreach (int index in eliteIndexes)
        {
            bool expected = RecoveredUpgradeOracle.EliteCanUpgrade(tiers,
                unit["STARTINGELITE"]!.Value.GetValue<int>(), index);
            Require(track.CanUpgradeElite(index) == expected, "Elite boundary differs: " + track.Identity);
        }

        Require(!track.CanUpgradeNormal(-1) && !track.CanUpgradeNormal(int.MaxValue) && !track.CanUpgradeElite(-1),
            "Invalid authority selected a valid successor index.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
