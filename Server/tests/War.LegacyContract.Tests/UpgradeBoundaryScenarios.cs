using War.Backend.Legacy;
using static War.LegacyContract.Tests.CatalogBufferRequests;

namespace War.LegacyContract.Tests;

internal static partial class UpgradeBoundaryScenarios
{
    internal static IEnumerable<CatalogBufferScenario> All()
    {
        return PurchaseBounds().Concat(CompletionBounds()).Concat(EliteBounds()).Concat(HelperAdmission());
    }

    private static IEnumerable<CatalogBufferScenario> PurchaseBounds()
    {
        foreach (bool isWeapon in new[] { true, false })
        {
            DatabaseAction action = isWeapon ? DatabaseAction.BuyWeaponUpgrade : DatabaseAction.BuyUnitUpgrade;
            string name = isWeapon ? CatalogBufferFixture.WeaponName : CatalogBufferFixture.UnitName;
            foreach (int index in new[] { -1, 1, int.MaxValue })
            {
                yield return new(action + " rejects boundary " + index, Create(action, name, ("BoughtIndex", index)),
                    DatabaseResult.AlreadyMaximumUpgrade, fixture => OwnAt(fixture, isWeapon, name, index));
            }

            string wrongKind = isWeapon ? CatalogBufferFixture.UnitName : CatalogBufferFixture.WeaponName;
            yield return new(action + " rejects another item kind", Create(action, wrongKind),
                DatabaseResult.PriceNotFound, fixture => OwnAt(fixture, isWeapon, wrongKind, 0));
        }

        const string tiered = "fixture-unit-tiered";
        foreach (int tier in new[] { 1, 2 })
        {
            yield return new("Normal upgrade at tier " + tier,
                Create(DatabaseAction.BuyUnitUpgrade, tiered, ("BoughtIndex", 1)),
                tier == 1 ? DatabaseResult.AlreadyMaximumUpgrade : DatabaseResult.Success, fixture =>
                {
                    fixture.OwnUnit(tiered);
                    fixture.Levels.SavedArmies[tiered].BoughtIndex = 1;
                    fixture.Levels.SavedArmies[tiered].Tier = tier;
                });
        }
    }

    private static IEnumerable<CatalogBufferScenario> EliteBounds()
    {
        foreach (int index in new[] { -1, 1, int.MaxValue })
        {
            yield return new("Elite purchase rejects terminal/index " + index,
                Create(DatabaseAction.UpgradeEliteSlot, CatalogBufferFixture.UnitName,
                    ("BoughtIndex", index), ("SpentParts", 5), ("SpentWarbucks", 100)),
                DatabaseResult.WrongIndexToActivate, fixture =>
                {
                    fixture.OwnUnit();
                    fixture.Levels.SavedArmies[CatalogBufferFixture.UnitName].EliteSlot = index;
                });
            yield return new("Parts purchase rejects terminal/index " + index,
                Create(DatabaseAction.ConvertScrapsToParts, CatalogBufferFixture.UnitName),
                DatabaseResult.WrongIndexToActivate, fixture =>
                {
                    fixture.OwnUnit();
                    fixture.Levels.SavedArmies[CatalogBufferFixture.UnitName].EliteSlot = index;
                });
        }
    }

    private static IEnumerable<CatalogBufferScenario> HelperAdmission()
    {
        foreach (string name in new[] { "Google2u.DBUpgradeSlotsTurret", "Google2u.DBUpgradeSlotsHeavyTurret",
            "Google2u.DBUpgradeSlotsRockyTurret" })
        {
            yield return new("Helper cannot be bought: " + name, Create(DatabaseAction.BuyUnit, name),
                DatabaseResult.PriceNotFound, fixture => fixture.Catalog = RecoveredCatalogFixture.Catalog);
            yield return new("Helper cannot be promoted: " + name, Create(DatabaseAction.PromoteUnit, name),
                DatabaseResult.PriceNotFound, fixture =>
                {
                    fixture.Catalog = RecoveredCatalogFixture.Catalog;
                    fixture.OwnUnit(name);
                });
            foreach (DatabaseAction action in new[] { DatabaseAction.ActivateUnit, DatabaseAction.InstantBuyUnit,
                DatabaseAction.UpdateEquippedUnits })
            {
                yield return new("Helper rejected by " + action + ": " + name, Create(action, name),
                    action == DatabaseAction.UpdateEquippedUnits ? DatabaseResult.CantEquipUnit :
                        DatabaseResult.WrongIndexToActivate, fixture =>
                    {
                        fixture.Catalog = RecoveredCatalogFixture.Catalog;
                        fixture.OwnUnit(name);
                    });
            }
        }
    }

    private static void OwnAt(CatalogBufferFixture fixture, bool isWeapon, string name, int index)
    {
        if (isWeapon)
        {
            fixture.OwnWeapon(name);
            fixture.Levels.SavedWeapons[name].BoughtIndex = index;
        }
        else
        {
            fixture.OwnUnit(name);
            fixture.Levels.SavedArmies[name].BoughtIndex = index;
        }
    }
}
