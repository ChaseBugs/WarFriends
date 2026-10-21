using War.Backend.Legacy;
using static War.LegacyContract.Tests.CatalogBufferRequests;

namespace War.LegacyContract.Tests;

internal static partial class CatalogBufferScenarios
{
    private static IEnumerable<CatalogBufferScenario> EliteAndCards()
    {
        return EliteUpgrades().Concat(PartsConversions()).Concat(CardPacks());
    }

    private static IEnumerable<CatalogBufferScenario> EliteUpgrades()
    {
        DatabaseAction action = DatabaseAction.UpgradeEliteSlot;
        string unit = CatalogBufferFixture.UnitName;
        yield return new("Elite closed unit", Create(action, "fixture-unit-elite-closed"),
            DatabaseResult.WrongIndexToActivate);
        yield return new("Elite wrong index", Create(action, unit, ("BoughtIndex", 1)),
            DatabaseResult.WrongIndexToActivate);
        yield return new("Elite maximum", Create(action, unit), DatabaseResult.WrongIndexToActivate, fixture =>
        {
            fixture.OwnUnit();
            fixture.Levels.SavedArmies[unit].EliteSlot = 1;
        });
        yield return new("Elite wrong part assertion", Create(action, unit, ("SpentParts", 4)),
            DatabaseResult.IncorrectValuesOnClient);
        yield return new("Elite wrong currency assertion", Create(action, unit,
            ("SpentParts", 5), ("SpentWarbucks", 1)), DatabaseResult.IncorrectValuesOnClient);
        yield return new("Elite WarBucks shortage", Create(action, unit, ("SpentParts", 5), ("SpentWarbucks", 100)),
            DatabaseResult.NotEnoughWarbucks, fixture => fixture.Player.WarBucks = 0);
        yield return new("Elite parts shortage", Create(action, unit, ("SpentParts", 5)),
            DatabaseResult.NotEnoughParts);
        yield return new("Elite paid upgrade", Create(action, unit, ("SpentParts", 5), ("SpentWarbucks", 100)),
            DatabaseResult.Success, fixture => fixture.OwnUnit());
        yield return new("Elite earned upgrade", Create(action, unit, ("SpentParts", 5)), DatabaseResult.Success,
            fixture => SetParts(fixture, 5));
    }

    private static IEnumerable<CatalogBufferScenario> PartsConversions()
    {
        string unit = CatalogBufferFixture.UnitName;
        yield return new("Sell parts from closed unit",
            Create(DatabaseAction.ConvertPartsToScraps, "fixture-unit-elite-closed"), DatabaseResult.EliteSlotLocked);
        yield return new("Sell parts missing policy", Create(DatabaseAction.ConvertPartsToScraps, unit),
            DatabaseResult.ServerMaintenance, fixture => fixture.Catalog = CatalogBufferFixture.MissingPolicyCatalog);
        yield return new("Sell empty parts", Create(DatabaseAction.ConvertPartsToScraps, unit),
            DatabaseResult.IncorrectPartsAmount);
        yield return new("Sell mismatched parts", Create(DatabaseAction.ConvertPartsToScraps, unit,
            ("PartsToConvert", 4), ("Scraps", 15)), DatabaseResult.IncorrectPartsAmount,
            fixture => SetParts(fixture, 3));
        yield return new("Sell mismatched proceeds", Create(DatabaseAction.ConvertPartsToScraps, unit,
            ("PartsToConvert", 3), ("Scraps", 10)), DatabaseResult.IncorrectPartsAmount,
            fixture => SetParts(fixture, 3));
        yield return new("Sell earned parts", Create(DatabaseAction.ConvertPartsToScraps, unit,
            ("PartsToConvert", 3), ("Scraps", 15)), DatabaseResult.Success, fixture => SetParts(fixture, 3));

        DatabaseAction action = DatabaseAction.ConvertScrapsToParts;
        yield return new("Buy parts closed unit", Create(action, "fixture-unit-elite-closed"),
            DatabaseResult.WrongIndexToActivate);
        yield return new("Buy parts missing rows", Create(action, "fixture-unit-gold"),
            DatabaseResult.WrongIndexToActivate,
            fixture => fixture.Catalog = CatalogBufferFixture.MissingPolicyCatalog);
        yield return new("Buy parts already full", Create(action, unit), DatabaseResult.WrongIndexToActivate,
            fixture => SetParts(fixture, 5));
        yield return new("Buy parts missing policy", Create(action, unit), DatabaseResult.ServerMaintenance,
            fixture => fixture.Catalog = CatalogBufferFixture.MissingPolicyCatalog);
        yield return new("Buy parts Scraps shortage", Create(action, unit), DatabaseResult.NotEnoughScraps,
            fixture => fixture.Player.Scraps = 0);
        yield return new("Buy missing parts", Create(action, unit), DatabaseResult.Success,
            fixture => fixture.OwnUnit());
    }

    private static IEnumerable<CatalogBufferScenario> CardPacks()
    {
        DatabaseAction action = DatabaseAction.BuyCardPack;
        yield return new("Pack composition missing", Create(action, "fixture-unknown-pack"),
            DatabaseResult.CardPackNotFound);
        yield return new("Pack rarity pool missing", Create(action, "BRONZE_CARDPACK"),
            DatabaseResult.CardPackNotFound, fixture => fixture.Catalog = CatalogBufferFixture.MissingPolicyCatalog);
        yield return new("Pack grant would overflow stock", Create(action, "BRONZE_CARDPACK"),
            DatabaseResult.CardPackNotFound, fixture =>
            {
                foreach (SavedCardData card in fixture.Cards.CardData.Values)
                {
                    card.Amount = int.MaxValue;
                }
            });
        yield return new("Pack stock damaged", Create(action, "BRONZE_CARDPACK"), DatabaseResult.ServerMaintenance,
            fixture => fixture.Cards.CardData["fixture-card-bronze"].Amount = -1);
        yield return new("Gold pack shortage uses recovered WarBucks code", Create(action, "BRONZE_CARDPACK"),
            DatabaseResult.NotEnoughWarbucks, fixture => fixture.Player.Gold = 0);
        yield return new("Three-card WarBucks shortage", Create(action, "THREE_CARDS"),
            DatabaseResult.NotEnoughWarbucks, fixture => fixture.Player.WarBucks = 0);
        yield return new("Gold pack purchase", Create(action, "BRONZE_CARDPACK"), DatabaseResult.Success);
        yield return new("Three-card purchase", Create(action, "THREE_CARDS"), DatabaseResult.Success);
    }

    private static void SetParts(CatalogBufferFixture fixture, int amount)
    {
        fixture.OwnUnit();
        fixture.Levels.SavedArmies[CatalogBufferFixture.UnitName].Parts = amount;
    }
}
