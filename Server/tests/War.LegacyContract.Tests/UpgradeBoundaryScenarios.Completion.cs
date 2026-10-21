using War.Backend.Legacy;
using static War.LegacyContract.Tests.CatalogBufferRequests;

namespace War.LegacyContract.Tests;

internal static partial class UpgradeBoundaryScenarios
{
    private static IEnumerable<CatalogBufferScenario> CompletionBounds()
    {
        foreach (DatabaseAction action in new[]
        {
            DatabaseAction.ActivateWeaponUpgrade, DatabaseAction.InstantWeaponUpgrade,
            DatabaseAction.ActivateUnitUpgrade, DatabaseAction.InstantUnitUpgrade })
        {
            bool isWeapon = action.ToString().Contains("Weapon", StringComparison.Ordinal);
            string name = isWeapon ? CatalogBufferFixture.WeaponName : CatalogBufferFixture.UnitName;
            yield return new(action + " reaches last legal state", Create(action, name), DatabaseResult.Success,
                fixture =>
                {
                    SeedDelivery(fixture, isWeapon, name, 0);
                    fixture.CheckMutation = mutation => CheckLastState(mutation, isWeapon, name);
                });
            foreach (int index in new[] { -1, 1, int.MaxValue })
            {
                yield return new(action + " terminal delivery index " + index,
                    Create(action, name, ("BoughtIndex", index)), DatabaseResult.WrongIndexToActivate,
                    fixture => SeedDelivery(fixture, isWeapon, name, index));
            }

            yield return new(action + " stale current slot", Create(action, name), DatabaseResult.WrongIndexToActivate,
                fixture =>
                {
                    SeedDelivery(fixture, isWeapon, name, 0);
                    OwnAt(fixture, isWeapon, name, 1);
                });
            yield return new(action + " wrong delivery lane", Create(action, name), DatabaseResult.WrongIndexToActivate,
                fixture =>
                {
                    SeedDelivery(fixture, isWeapon, name, 0);
                    Delivery(fixture, isWeapon).SlotId = 1;
                });
            yield return new(action + " inactive proof", Create(action, name), DatabaseResult.WrongIndexToActivate,
                fixture =>
                {
                    SeedDelivery(fixture, isWeapon, name, 0);
                    Delivery(fixture, isWeapon).ActivationNeeded = false;
                });
            yield return new(action + " lost ownership", Create(action, name), DatabaseResult.WrongIndexToActivate,
                fixture =>
                {
                    SeedDelivery(fixture, isWeapon, name, 0);
                    if (isWeapon)
                    {
                        fixture.Levels.SavedWeapons[name].Bought = false;
                    }
                    else
                    {
                        fixture.Levels.SavedArmies[name].Bought = false;
                    }
                });
        }
    }

    private static void SeedDelivery(CatalogBufferFixture fixture, bool isWeapon, string name, int index)
    {
        OwnAt(fixture, isWeapon, name, index);
        ItemDelivery delivery = Delivery(fixture, isWeapon);
        delivery.ItemId = name;
        delivery.BoughtIndex = index;
        delivery.Start = CatalogBufferFixture.Now - 60;
        delivery.End = CatalogBufferFixture.Now - 1;
        delivery.ActivationNeeded = true;
    }

    private static ItemDelivery Delivery(CatalogBufferFixture fixture, bool isWeapon) =>
        isWeapon ? fixture.Levels.WeaponDelivery : fixture.Levels.UnitDelivery;

    private static void CheckLastState(
        War.Persistence.Legacy.Buffers.LegacyBufferedMutation mutation, bool isWeapon, string name)
    {
        LevelManagerData state = PlayerState.Read<LevelManagerData>(mutation.Serialized["LevelManagerData"]);
        int index = isWeapon ? state.SavedWeapons[name].BoughtIndex : state.SavedArmies[name].BoughtIndex;
        ItemDelivery delivery = isWeapon ? state.WeaponDelivery : state.UnitDelivery;
        if (index != 1 || delivery.ItemId != null || delivery.SlotId != 0 || delivery.ActivationNeeded ||
            delivery.Start != 0 || delivery.End != 0)
        {
            throw new InvalidOperationException(
                "Last legal upgrade failed to advance once and clear its delivery proof.");
        }
    }
}
