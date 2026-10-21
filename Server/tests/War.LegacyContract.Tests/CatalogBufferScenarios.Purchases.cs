using War.Backend.Legacy;
using static War.LegacyContract.Tests.CatalogBufferRequests;

namespace War.LegacyContract.Tests;

internal static partial class CatalogBufferScenarios
{
    private static IEnumerable<CatalogBufferScenario> Purchases()
    {
        foreach (DatabaseAction action in new[] { DatabaseAction.BuyWeapon, DatabaseAction.BuyUnit })
        {
            string prefix = action == DatabaseAction.BuyWeapon ? "fixture-weapon-" : "fixture-unit-";
            yield return new(action + " WarBucks shortage", Create(action, prefix + "wb"),
                DatabaseResult.NotEnoughWarbucks, fixture => fixture.Player.WarBucks = 0);
            yield return new(action + " Gold shortage", Create(action, prefix + "gold"),
                DatabaseResult.NotEnoughGold, fixture => fixture.Player.Gold = 0);
            yield return new(action + " locked level", Create(action, prefix + "locked"),
                DatabaseResult.NotEnoughLevel, fixture => fixture.Player.Level = 1);
            yield return new(action + " unsupported delivery", Create(action, prefix + "delivery"),
                DatabaseResult.ServerMaintenance);
            yield return new(action + " paid purchase", Create(action, prefix + "wb"), DatabaseResult.Success);
            yield return new(action + " owned no-op", Create(action, prefix + "free"), DatabaseResult.Success);
        }

        yield return new("Non-shop weapon", Create(DatabaseAction.BuyWeapon, "fixture-weapon-noshop"),
            DatabaseResult.WeaponNotBought);
        foreach (string suffix in new[] { "wb", "gold", "locked", "vip" })
        {
            DatabaseResult expected = suffix switch
            {
                "wb" => DatabaseResult.NotEnoughWarbucks,
                "gold" => DatabaseResult.NotEnoughGold,
                "locked" => DatabaseResult.NotEnoughLevel,
                _ => DatabaseResult.DecalOnlyForVip
            };
            yield return new("BuyDecal " + suffix, Create(DatabaseAction.BuyDecal, "fixture-visual-" + suffix),
                expected, fixture =>
                {
                    fixture.Player.Gold = 0;
                    fixture.Player.WarBucks = 0;
                    fixture.Player.Level = 1;
                    fixture.Player.Vip = 0;
                });
        }

        yield return new("Non-shop cosmetic", Create(DatabaseAction.BuyDecal, "fixture-visual-noshop"),
            DatabaseResult.PriceNotFound);
        yield return new("Missing cosmetic", Create(DatabaseAction.BuyDecal, "fixture-visual-missing"),
            DatabaseResult.PriceNotFound);
        yield return new("Paid cosmetic purchase", Create(DatabaseAction.BuyDecal, "fixture-visual-wb"),
            DatabaseResult.Success);
    }
}
