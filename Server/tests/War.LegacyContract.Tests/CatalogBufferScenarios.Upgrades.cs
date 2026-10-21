using War.Backend.Legacy;
using static War.LegacyContract.Tests.CatalogBufferRequests;

namespace War.LegacyContract.Tests;

internal static partial class CatalogBufferScenarios
{
    private static IEnumerable<CatalogBufferScenario> Upgrades()
    {
        return UpgradePurchases().Concat(DeliveryCompletions());
    }

    private static IEnumerable<CatalogBufferScenario> UpgradePurchases()
    {
        foreach (bool isWeapon in new[] { true, false })
        {
            DatabaseAction action = isWeapon ? DatabaseAction.BuyWeaponUpgrade : DatabaseAction.BuyUnitUpgrade;
            string prefix = isWeapon ? "fixture-weapon-" : "fixture-unit-";
            yield return new(action + " unrelated sheet cannot supply upgrade authority",
                Create(action, "Google2u.Constants"), DatabaseResult.PriceNotFound,
                fixture => Own(fixture, isWeapon, "Google2u.Constants"));
            yield return new(action + " unowned", Create(action, prefix + "wb"),
                isWeapon ? DatabaseResult.WeaponNotBought : DatabaseResult.WrongIndexToActivate);
            yield return new(action + " stale index", Create(action, prefix + "wb", ("BoughtIndex", 1)),
                DatabaseResult.WrongIndexToActivate, fixture => Own(fixture, isWeapon, prefix + "wb"));
            yield return new(action + " maximum", Create(action, prefix + "wb", ("BoughtIndex", 2)),
                DatabaseResult.AlreadyMaximumUpgrade, fixture => SetUpgradeIndex(fixture, isWeapon, 2));
            yield return new(action + " occupied delivery", Create(action, prefix + "wb"),
                DatabaseResult.AlreadyUpgrading, fixture =>
                {
                    Own(fixture, isWeapon, prefix + "wb");
                    Delivery(fixture, isWeapon).ItemId = prefix + "gold";
                });
            yield return new(action + " WarBucks shortage", Create(action, prefix + "wb"),
                DatabaseResult.NotEnoughWarbucks, fixture =>
                {
                    Own(fixture, isWeapon, prefix + "wb");
                    fixture.Player.WarBucks = 0;
                });
            yield return new(action + " Gold shortage", Create(action, prefix + "gold"),
                DatabaseResult.NotEnoughGold, fixture =>
                {
                    Own(fixture, isWeapon, prefix + "gold");
                    fixture.Player.Gold = 0;
                });
            yield return new(action + " starts delivery", Create(action, prefix + "wb"),
                DatabaseResult.Success, fixture => Own(fixture, isWeapon, prefix + "wb"));
        }

        yield return new("Special unit upgrade stays closed",
            Create(DatabaseAction.BuyUnitUpgrade, CatalogBufferFixture.UnitName, ("IsSpecial", "1")),
            DatabaseResult.ServerMaintenance);
    }

    private static IEnumerable<CatalogBufferScenario> DeliveryCompletions()
    {
        foreach (DatabaseAction action in new[] { DatabaseAction.ActivateWeapon, DatabaseAction.ActivateUnit,
            DatabaseAction.ActivateWeaponUpgrade, DatabaseAction.ActivateUnitUpgrade, DatabaseAction.InstantBuyWeapon,
            DatabaseAction.InstantBuyUnit, DatabaseAction.InstantWeaponUpgrade, DatabaseAction.InstantUnitUpgrade })
        {
            bool isWeapon = action.ToString().Contains("Weapon", StringComparison.Ordinal);
            bool isInstant = action.ToString().StartsWith("Instant", StringComparison.Ordinal);
            string name = isWeapon ? CatalogBufferFixture.WeaponName : CatalogBufferFixture.UnitName;
            yield return new(action + " completes delivery", Create(action, name), DatabaseResult.Success,
                fixture => SetDelivery(fixture, action, false));
            if (isInstant)
            {
                yield return new(action + " missing immutable price policy", Create(action, name),
                    DatabaseResult.ServerMaintenance, fixture =>
                    {
                        SetDelivery(fixture, action, true);
                        fixture.Catalog = CatalogBufferFixture.MissingPolicyCatalog;
                    });
                yield return new(action + " Gold shortage", Create(action, name), DatabaseResult.NotEnoughGold,
                    fixture =>
                    {
                        SetDelivery(fixture, action, true);
                        fixture.Player.Gold = 0;
                    });
            }
            else
            {
                yield return new(action + " early activation", Create(action, name), DatabaseResult.TooSoonToActivate,
                    fixture => SetDelivery(fixture, action, true));
            }

            if (action.ToString().Contains("Upgrade", StringComparison.Ordinal))
            {
                yield return new(action + " stale delivery index", Create(action, name, ("BoughtIndex", 1)),
                    DatabaseResult.WrongIndexToActivate, fixture => SetDelivery(fixture, action, false));
            }
            else
            {
                yield return new(action + " no matching delivery", Create(action, name),
                    DatabaseResult.WrongIndexToActivate);
                yield return new(action + " already owned", Create(action, name), DatabaseResult.Success,
                    fixture => Own(fixture, isWeapon, name));
            }
        }
    }

    private static void Own(CatalogBufferFixture fixture, bool isWeapon, string name)
    {
        if (isWeapon)
        {
            fixture.OwnWeapon(name);
        }
        else
        {
            fixture.OwnUnit(name);
        }
    }

    private static void SetUpgradeIndex(CatalogBufferFixture fixture, bool isWeapon, int index)
    {
        if (isWeapon)
        {
            fixture.OwnWeapon();
            fixture.Levels.SavedWeapons[CatalogBufferFixture.WeaponName].BoughtIndex = index;
        }
        else
        {
            fixture.OwnUnit();
            fixture.Levels.SavedArmies[CatalogBufferFixture.UnitName].BoughtIndex = index;
        }
    }

    private static ItemDelivery Delivery(CatalogBufferFixture fixture, bool isWeapon) =>
        isWeapon ? fixture.Levels.WeaponDelivery : fixture.Levels.UnitDelivery;

    private static void SetDelivery(CatalogBufferFixture fixture, DatabaseAction action, bool isFuture)
    {
        bool isWeapon = action.ToString().Contains("Weapon", StringComparison.Ordinal);
        if (action.ToString().Contains("Upgrade", StringComparison.Ordinal))
        {
            string name = isWeapon ? CatalogBufferFixture.WeaponName : CatalogBufferFixture.UnitName;
            Own(fixture, isWeapon, name);
        }

        ItemDelivery delivery = Delivery(fixture, isWeapon);
        delivery.ItemId = isWeapon ? CatalogBufferFixture.WeaponName : CatalogBufferFixture.UnitName;
        delivery.Start = CatalogBufferFixture.Now - 120;
        delivery.End = CatalogBufferFixture.Now + (isFuture ? 60 : -10);
        delivery.ActivationNeeded = true;
    }
}
