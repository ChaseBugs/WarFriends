using War.Backend.Legacy;

namespace War.LegacyContract.Tests;

internal static partial class CatalogBufferScenarios
{
    internal static IEnumerable<CatalogBufferScenario> All()
    {
        return InputShapes().Concat(MissingPricesAndDiscounts()).Concat(Purchases()).Concat(Upgrades())
            .Concat(Equipment()).Concat(EliteAndCards());
    }

    private static IEnumerable<CatalogBufferScenario> InputShapes()
    {
        var bareActions = new HashSet<DatabaseAction>
        {
            DatabaseAction.WeaponWasShown, DatabaseAction.ArmyUnitWasShown, DatabaseAction.VisualWasShown,
            DatabaseAction.EquipDecal, DatabaseAction.ConvertScrapsToParts,
            DatabaseAction.SaveLastSeenSquadChatTimeStamp
        };
        foreach (DatabaseAction action in LegacyBufferProcessor.SupportedActions)
        {
            string? payload = bareActions.Contains(action) ? null : "{}";
            yield return new(action + " missing canonical fields", new BufferedRequest(0, action, payload),
                DatabaseResult.WrongPlayerData);
        }
    }

    private static IEnumerable<CatalogBufferScenario> MissingPricesAndDiscounts()
    {
        foreach (DatabaseAction action in new[] { DatabaseAction.BuyWeapon, DatabaseAction.BuyUnit,
            DatabaseAction.BuyWeaponUpgrade, DatabaseAction.BuyUnitUpgrade })
        {
            yield return new(action + " missing catalog identity",
                CatalogBufferRequests.Create(action, "fixture-missing"), DatabaseResult.PriceNotFound);
            yield return new(action + " unavailable discount",
                CatalogBufferRequests.Create(action, "fixture-missing", ("discount", 1)),
                DatabaseResult.NoDiscountFound);
        }

        foreach (DatabaseAction action in new[] { DatabaseAction.BuyCardPack, DatabaseAction.BuyDecal })
        {
            yield return new(action + " unavailable discount",
                CatalogBufferRequests.Create(action, "fixture-missing", ("discount", 1)),
                DatabaseResult.NoDiscountFound);
        }
    }
}
